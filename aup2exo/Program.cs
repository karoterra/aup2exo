using System.Text;
using Karoterra.AupDotNet;
using Karoterra.AupDotNet.ExEdit;
using CommandLine;

namespace aup2exo;

class Program
{
    static int Main(string[] args)
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        var res = Parser.Default.ParseArguments<Options>(args)
            .MapResult(opt => Run(opt), err => 1);
        return res;
    }

    static AviUtlProject? ReadAup(string path)
    {
        try
        {
            return new AviUtlProject(path);
        }
        catch (FileNotFoundException)
        {
            Console.Error.WriteLine($"\"{path}\" が見つかりませんでした。");
            return null;
        }
        catch (UnauthorizedAccessException)
        {
            Console.Error.WriteLine($"\"{path}\" はディレクトリであるか、アクセス許可がありません。");
            return null;
        }
        catch (PathTooLongException)
        {
            Console.Error.WriteLine("パスが長すぎます。");
            return null;
        }
        catch (Exception e) when (
            e is ArgumentException or
            ArgumentNullException or
            DirectoryNotFoundException or
            NotSupportedException)
        {
            Console.Error.WriteLine("有効なパスを指定してください。");
            return null;
        }
        catch (FileFormatException e)
        {
            Console.Error.WriteLine($"\"{path}\" は AviUtl プロジェクトファイルでないか破損している可能性があります。");
            Console.Error.WriteLine(e.Message);
            return null;
        }
        catch (EndOfStreamException)
        {
            Console.Error.WriteLine($"\"{path}\" は AviUtl プロジェクトファイルでないか破損している可能性があります。");
            Console.Error.WriteLine("ファイルの読み込み中に終端に達しました。");
            return null;
        }
        catch (IOException)
        {
            Console.Error.WriteLine("IOエラーが発生しました。");
            return null;
        }
    }

    static string CreateOutputPath(string basePath, int scene)
    {
        string dirname = Path.GetDirectoryName(basePath) ?? "";
        string filename = $"{Path.GetFileNameWithoutExtension(basePath)}_{scene}.exo";
        return Path.Combine(dirname, filename);
    }

    static bool ExportExo(string path, ExeditObjectFile exo)
    {
        try
        {
            using FileStream fs = File.Create(path);
            using StreamWriter sw = new(fs, Encoding.GetEncoding("shift-jis"));
            sw.NewLine = "\r\n";
            exo.Write(sw);
        }
        catch (UnauthorizedAccessException)
        {
            Console.Error.WriteLine($"{path} へのアクセス許可がありません。");
            return false;
        }
        catch (PathTooLongException)
        {
            Console.Error.WriteLine("出力パスが長すぎます。");
            return false;
        }
        catch (Exception e) when (
            e is ArgumentException or
            ArgumentNullException or
            DirectoryNotFoundException or
            NotSupportedException)
        {
            Console.Error.WriteLine("有効な出力パスを指定してください。");
            return false;
        }
        catch (IOException)
        {
            Console.Error.WriteLine("ファイル作成中にIOエラーが発生しました。");
            return false;
        }
        return true;
    }

    static int Run(Options opt)
    {
        var aup = ReadAup(opt.Filename);
        if (aup == null) return 1;

        var filter = aup.FilterProjects.Where(f => f.Name == "拡張編集").FirstOrDefault();
        if (filter == null)
        {
            Console.Error.WriteLine("拡張編集のデータが見つかりません。");
            return 1;
        }
        ExEditProject exedit = new(filter as RawFilterProject);

        if (opt.OutputPath == opt.Filename)
        {
            Console.Error.WriteLine("入力ファイルと出力ファイルのパスが同じです。");
            return 1;
        }

        if (opt.Scene.HasValue)
        {
            var scene = exedit.Scenes.Where(s => s.SceneIndex == opt.Scene.Value).FirstOrDefault();
            if (scene == null)
            {
                Console.Error.WriteLine($"シーン番号 {opt.Scene.Value} が見つかりません。");
                return 1;
            }
            if (string.IsNullOrEmpty(opt.OutputPath))
            {
                opt.OutputPath = CreateOutputPath(opt.Filename, opt.Scene.Value);
            }

            var exo = exedit.ExportObject(opt.Scene.Value, aup.EditHandle);
            if (!ExportExo(opt.OutputPath, exo)) return 1;
        }
        else
        {
            foreach (var scene in exedit.Scenes)
            {
                string outputPath = CreateOutputPath(
                    string.IsNullOrEmpty(opt.OutputPath) ? opt.Filename : opt.OutputPath,
                    (int)scene.SceneIndex);
                var exo = exedit.ExportObject((int)scene.SceneIndex, aup.EditHandle);
                if (!ExportExo(outputPath, exo)) return 1;
            }
        }

        return 0;
    }
}

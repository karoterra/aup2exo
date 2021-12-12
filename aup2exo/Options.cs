using CommandLine;
using CommandLine.Text;

namespace aup2exo
{
    public class Options
    {
        [Value(0, Required = true, MetaName = "Filename", HelpText = "aupファイルのパス")]
        public string Filename { get; set; } = string.Empty;

        [Option('o', "out", HelpText = "出力するexoファイルのパス")]
        public string? OutputPath { get; set; } = string.Empty;

        [Option('s', "scene", HelpText = "出力するシーンの番号(Rootなら0)")]
        public int? Scene { get; set; } = null;

        [Usage]
        public static IEnumerable<Example> Examples
        {
            get
            {
                yield return new Example("全てのシーンを出力", new Options() { Filename = @"C:\path\to\project.aup" });
                yield return new Example("出力先を指定", new Options() { Filename = @"C:\path\to\project.aup", OutputPath = @"C:\path\to\objects.exo" });
                yield return new Example("Rootのみ出力", new Options() { Filename = @"C:\path\to\project.aup", OutputPath = @"C:\path\to\objects.exo", Scene = 0 });
            }
        }
    }
}

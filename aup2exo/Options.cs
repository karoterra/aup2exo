using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

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
    }
}

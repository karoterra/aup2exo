using System.Text.Json;
using System.Reflection;

namespace aup2exo
{
    class Setting
    {
        public List<FilterDescription> Filters { get; }

        public Setting()
        {
            string exePath = Assembly.GetExecutingAssembly().Location;
            string exedir = Path.GetDirectoryName(exePath) ?? string.Empty;
            string settingPath = Path.Combine(exedir, "setting.json");
            string setting = File.ReadAllText(settingPath);

            var filters = JsonSerializer.Deserialize<List<FilterDescription>>(setting);
            if (filters != null)
                Filters = filters;
            else
                Filters = new List<FilterDescription>();
        }
    }
}

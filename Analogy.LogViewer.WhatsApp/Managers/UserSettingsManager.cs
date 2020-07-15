using System;
using System.Collections.Generic;
using System.IO;
using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using Newtonsoft.Json;

namespace Analogy.LogViewer.WhatsApp.Managers
{
    public class UserSettingsManager
    {

        private static readonly Lazy<UserSettingsManager> _instance =
            new Lazy<UserSettingsManager>(() => new UserSettingsManager());
        public static UserSettingsManager UserSettings { get; set; } = _instance.Value;
        private string WhatsAppFileSetting { get; } = "AnalogyWhatsAppParserTextSettings.json";
        public ILogParserSettings LogParserSettings { get; set; }


        public UserSettingsManager()
        {
            if (File.Exists(WhatsAppFileSetting))
            {
                try
                {
                    string data = File.ReadAllText(WhatsAppFileSetting);
                    LogParserSettings = JsonConvert.DeserializeObject<LogParserSettings>(data);
                }
                catch (Exception ex)
                {
                    LogManager.Instance.LogException(ex, "WhatsApp Text Provider", "Error loading user setting file");
                    LogParserSettings = new LogParserSettings();
                    LogParserSettings.Splitter = "|";
                    LogParserSettings.SupportedFilesExtensions = new List<string> { "*.txt" };
                }
            }
            else
            {
                LogParserSettings = new LogParserSettings();
                LogParserSettings.Splitter = "|";
                LogParserSettings.SupportedFilesExtensions = new List<string> { "*.txt" };

            }

        }

        public void Save()
        {
            try
            {
                File.WriteAllText(WhatsAppFileSetting, JsonConvert.SerializeObject(LogParserSettings));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }


        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using Analogy.LogViewer.WhatsApp.Properties;
using Newtonsoft.Json;

namespace Analogy.LogViewer.WhatsApp.Managers
{
    public class UserSettingsManager
    {

        private static readonly Lazy<UserSettingsManager> _instance =
            new Lazy<UserSettingsManager>(() => new UserSettingsManager());
        public static UserSettingsManager UserSettings { get; set; } = _instance.Value;
        public CultureInfo CultureInfo { get; set; }

        public UserSettingsManager()
        {
            if (Settings.Default.UpgradeRequired)
            {
                Settings.Default.Upgrade();
                Settings.Default.UpgradeRequired = false;
                Settings.Default.Save();
            }

            CultureInfo = string.IsNullOrEmpty(Settings.Default.CultureInfo)
                ? CultureInfo.CurrentCulture
                : new CultureInfo(Settings.Default.CultureInfo);
        }

        public void Save()
        {
            Settings.Default.CultureInfo = CultureInfo.Name;
            Settings.Default.Save();


        }
        private T ParseSettings<T>(string data) where T : new()
        {
            try
            {
                return string.IsNullOrEmpty(data) ?
                    new T() :
                    JsonConvert.DeserializeObject<T>(data);
            }
            catch (Exception e)
            {
                LogManager.Instance.LogError("Error during parsing: " + e, nameof(UserSettingsManager));
                return new T();
            }


        }

    }
}

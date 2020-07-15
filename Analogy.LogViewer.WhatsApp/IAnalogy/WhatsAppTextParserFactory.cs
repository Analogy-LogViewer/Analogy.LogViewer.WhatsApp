using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Analogy.DataProviders.Extensions;
using Analogy.Interfaces;
using Analogy.Interfaces.Factories;
using Analogy.LogViewer.WhatsApp.Managers;
using Analogy.LogViewer.WhatsApp.Properties;

namespace Analogy.LogViewer.WhatsApp.IAnalogy
{

    public class WhatsAppTextParserFactory : IAnalogyFactory
    {
        internal static Guid AnalogyWhatsAppGuid { get; } = new Guid("4C062AC5-0349-4A60-A69F-4C0272D05CA7");
        public Guid FactoryId { get; } = AnalogyWhatsAppGuid;
        public string Title { get; } = "Analogy WhatsApp Text Parser";
        public IEnumerable<IAnalogyChangeLog> ChangeLog => WhatsApp.ChangeLog.GetChangeLog();
        public IEnumerable<string> Contributors { get; } = new List<string> { "Lior Banai" };
        public string About { get; } = "Analogy WhatsApp Text Parser";

    }

    public class AnalogyPlainTextDataProviderFactory : IAnalogyDataProvidersFactory
    {
        public virtual Guid FactoryId { get; } = WhatsAppTextParserFactory.AnalogyWhatsAppGuid;
        public virtual string Title { get; } = "Analogy WhatsApp Text Provider";
        public IEnumerable<IAnalogyDataProvider> DataProviders { get; }

        public AnalogyPlainTextDataProviderFactory()
        {
            DataProviders = new List<IAnalogyDataProvider> { new WhatsAppDataProvider(UserSettingsManager.UserSettings.LogParserSettings) };
        }
    }

    //public class AnalogyCustomActionFactory : IAnalogyCustomActionsFactory
    //{
    //    public Guid FactoryId { get; set; } = WhatsAppTextParserFactory.AnalogyWhatsAppGuid;

    //    public string Title { get; } = "Analogy WhatsApp Text tools";
    //    public IEnumerable<IAnalogyCustomAction> Actions { get; }

    //    public AnalogyCustomActionFactory()
    //    {
    //        Actions = new List<IAnalogyCustomAction>(0);
    //    }
    //}

    //public class AnalogyPlainTextParserSettings : IAnalogyDataProviderSettings
    //{
    //    public virtual Guid FactoryId { get; set; } = WhatsAppTextParserFactory.AnalogyWhatsAppGuid;
    //    public Guid ID { get; set; } = new Guid("110D2B6C-82C4-4475-AA7D-B57FB821FFE5");

    //    public string Title { get; } = "WhatsApp Parser Settings";
    //    public UserControl DataProviderSettings { get; } = new PlainTextSettingSettings();
    //    public Image SmallImage { get; } = Resources.Analogy_small_16x16;
    //    public Image LargeImage { get; } = null;

    //    public Task SaveSettingsAsync()
    //    {
    //        UserSettingsManager.UserSettings.Save();
    //        return Task.CompletedTask;
    //    }

    //}
}

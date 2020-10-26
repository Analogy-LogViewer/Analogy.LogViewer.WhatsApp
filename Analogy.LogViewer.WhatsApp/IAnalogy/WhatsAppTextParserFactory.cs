using System;
using System.Collections.Generic;
using System.Drawing;
using Analogy.Interfaces;
using Analogy.Interfaces.Factories;
using Analogy.LogViewer.WhatsApp.Managers;
using Analogy.LogViewer.WhatsApp.Properties;

namespace Analogy.LogViewer.WhatsApp.IAnalogy
{

    public class WhatsAppTextParserFactory : IAnalogyFactory
    {
        internal static Guid Id { get; } = new Guid("4C062AC5-0349-4A60-A69F-4C0272D05CA7");
        public void RegisterNotificationCallback(INotificationReporter notificationReporter)
        {
            
        }

        public Guid FactoryId { get; set; } = Id;
        public string Title { get; set; } = "WhatsApp Text Parser";
        public Image SmallImage { get; set; } = Resources.Analogy_small_16x16;
        public Image LargeImage { get; set; } = Resources.Analogy_small_16x16;
        public IEnumerable<IAnalogyChangeLog> ChangeLog { get; set; } = WhatsApp.ChangeLog.GetChangeLog();
        public IEnumerable<string> Contributors { get; set; } = new List<string> { "Lior Banai" };
        public string About { get; set; } = "WhatsApp Text Parser";

    }

    public class AnalogyPlainTextDataProviderFactory : IAnalogyDataProvidersFactory
    {
        public virtual Guid FactoryId { get; set; } = WhatsAppTextParserFactory.Id;
        public virtual string Title { get; set; } = "WhatsApp Text Provider";
        public IEnumerable<IAnalogyDataProvider> DataProviders { get; }

        public AnalogyPlainTextDataProviderFactory()
        {
            DataProviders = new List<IAnalogyDataProvider> { new WhatsAppDataProvider() };
        }
    }

    //public class AnalogyCustomActionFactory : IAnalogyCustomActionsFactory
    //{
    //    public Guid FactoryId { get; set; } = WhatsAppTextParserFactory.Id;

    //    public string Title { get; } = "Analogy WhatsApp Text tools";
    //    public IEnumerable<IAnalogyCustomAction> Actions { get; }

    //    public AnalogyCustomActionFactory()
    //    {
    //        Actions = new List<IAnalogyCustomAction>(0);
    //    }
    //}

    //public class AnalogyPlainTextParserSettings : IAnalogyDataProviderSettings
    //{
    //    public virtual Guid FactoryId { get; set; } = WhatsAppTextParserFactory.Id;
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

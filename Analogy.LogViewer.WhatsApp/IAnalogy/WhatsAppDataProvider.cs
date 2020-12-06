using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Analogy.Interfaces;
using Analogy.LogViewer.WhatsApp.Managers;

namespace Analogy.LogViewer.WhatsApp.IAnalogy
{
    public class WhatsAppDataProvider : Template.OfflineDataProvider
    {
        public override string OptionalTitle { get; set; } = "WhatsApp Text Parser";
        public override Guid Id { get; set; } = new Guid("57CBE5A8-8FBF-4D26-A8A4-F39BBE5CF78F");
        public override Image? LargeImage { get; set; } = null;
        public override Image? SmallImage { get; set; } = null;

        public override bool CanSaveToLogFile { get; set; } = false;
        public override string FileOpenDialogFilters { get; set; } = "WhatsApp Exported Text files|*.txt";
        public override string FileSaveDialogFilters { get; set; } = string.Empty;
        public override IEnumerable<string> SupportFormats { get; set; } = new[] { "*.txt" };
        public override bool DisableFilePoolingOption { get; set; } = false;
        public override string InitialFolderFullPath => Environment.CurrentDirectory;

        public WhatsAppTextLogFileLoader WhatsAppTextLogFileParser { get; set; }

        public override bool UseCustomColors { get; set; } = false;
        public override IEnumerable<(string originalHeader, string replacementHeader)> GetReplacementHeaders()
            => Array.Empty<(string, string)>();

        public override (Color backgroundColor, Color foregroundColor) GetColorForMessage(IAnalogyLogMessage logMessage)
            => (Color.Empty, Color.Empty);
        public WhatsAppDataProvider()
        {
        }

        public override Task InitializeDataProviderAsync(IAnalogyLogger logger)
        {
            LogManager.Instance.SetLogger(logger);
            WhatsAppTextLogFileParser = new WhatsAppTextLogFileLoader();
            return base.InitializeDataProviderAsync(logger);
        }

        public override async Task<IEnumerable<AnalogyLogMessage>> Process(string fileName, CancellationToken token,
            ILogMessageCreatedHandler messagesHandler)
        {
            if (CanOpenFile(fileName))
            {
                return await WhatsAppTextLogFileParser.Process(fileName, token, messagesHandler);
            }

            return new List<AnalogyLogMessage>(0);

        }


        public override bool CanOpenFile(string fileName) => CanOpenFileInternal(fileName);

        private bool CanOpenFileInternal(string fileName) => fileName.EndsWith(".txt");

        protected override List<FileInfo> GetSupportedFilesInternal(DirectoryInfo dirInfo, bool recursive)
        {

            List<FileInfo> files = dirInfo.GetFiles("*.txt").ToList();
            if (!recursive)
            {
                return files;
            }

            try
            {
                foreach (DirectoryInfo dir in dirInfo.GetDirectories())
                {
                    files.AddRange(GetSupportedFilesInternal(dir, true));
                }
            }
            catch (Exception)
            {
                return files;
            }

            return files;
        }
    }
}

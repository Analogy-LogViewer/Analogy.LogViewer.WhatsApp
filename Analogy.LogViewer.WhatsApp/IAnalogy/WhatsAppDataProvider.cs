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
    public class WhatsAppDataProvider : IAnalogyOfflineDataProvider
    {
        public string OptionalTitle { get; set; } = "WhatsApp Text Parser";
        public Guid Id { get; set; } = new Guid("57CBE5A8-8FBF-4D26-A8A4-F39BBE5CF78F");
        public Image LargeImage { get; set; } = null;
        public Image SmallImage { get; set; } = null;

        public bool CanSaveToLogFile { get; } = false;
        public string FileOpenDialogFilters { get; } = "WhatsApp Exported Text files|*.txt";
        public string FileSaveDialogFilters { get; } = string.Empty;
        public IEnumerable<string> SupportFormats { get; } = new[] { "*.txt" };
        public bool DisableFilePoolingOption { get; } = false;
        public string InitialFolderFullPath => Environment.CurrentDirectory;

        public WhatsAppTextLogFileLoader WhatsAppTextLogFileParser { get; set; }

        public bool UseCustomColors { get; set; } = false;
        public IEnumerable<(string originalHeader, string replacementHeader)> GetReplacementHeaders()
            => Array.Empty<(string, string)>();

        public (Color backgroundColor, Color foregroundColor) GetColorForMessage(IAnalogyLogMessage logMessage)
            => (Color.Empty, Color.Empty);
        public WhatsAppDataProvider()
        {
        }

        public Task InitializeDataProviderAsync(IAnalogyLogger logger)
        {
            LogManager.Instance.SetLogger(logger);
            WhatsAppTextLogFileParser = new WhatsAppTextLogFileLoader();
            return Task.CompletedTask;
        }

        public void MessageOpened(AnalogyLogMessage message)
        {
            //nop
        }

        public async Task<IEnumerable<AnalogyLogMessage>> Process(string fileName, CancellationToken token,
            ILogMessageCreatedHandler messagesHandler)
        {
            if (CanOpenFile(fileName))
                return await WhatsAppTextLogFileParser.Process(fileName, token, messagesHandler);
            return new List<AnalogyLogMessage>(0);

        }

        public IEnumerable<FileInfo> GetSupportedFiles(DirectoryInfo dirInfo, bool recursiveLoad)
            => GetSupportedFilesInternal(dirInfo, recursiveLoad);

        public Task SaveAsync(List<AnalogyLogMessage> messages, string fileName)
        {
            throw new NotSupportedException("Saving is not supported for WhatsApp Text");
        }

        public bool CanOpenFile(string fileName) => CanOpenFileInternal(fileName);

        private bool CanOpenFileInternal(string fileName) => fileName.EndsWith(".txt");
        public bool CanOpenAllFiles(IEnumerable<string> fileNames) => fileNames.All(CanOpenFile);

        private List<FileInfo> GetSupportedFilesInternal(DirectoryInfo dirInfo, bool recursive)
        {

            List<FileInfo> files = dirInfo.GetFiles("*.txt").ToList();
            if (!recursive)
                return files;
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

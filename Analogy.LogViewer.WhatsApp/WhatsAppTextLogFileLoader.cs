using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Analogy.DataProviders.Extensions;
using Analogy.Interfaces;

namespace Analogy.LogViewer.WhatsApp
{
    public class WhatsAppTextLogFileLoader
    {
        private string source = "";
        //private ILogParserSettings _logFileSettings;
        //private GeneralFileParser _parser;
        public WhatsAppTextLogFileLoader()
        {

        }
        public WhatsAppTextLogFileLoader(ILogParserSettings logFileSettings)
        {
            //_logFileSettings = logFileSettings;
            //_parser = new GeneralFileParser(_logFileSettings);
        }

        public async Task<IEnumerable<AnalogyLogMessage>> Process(string fileName, CancellationToken token,
            ILogMessageCreatedHandler messagesHandler)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                AnalogyLogMessage empty = new AnalogyLogMessage($"File is null or empty. Aborting.",
                    AnalogyLogLevel.Critical, AnalogyLogClass.General, source, "None")
                {
                    Source = source,
                    Module = System.Diagnostics.Process.GetCurrentProcess().ProcessName
                };
                messagesHandler.AppendMessage(empty, GetFileNameAsDataSource(fileName));
                return new List<AnalogyLogMessage> { empty };
            }

            List<AnalogyLogMessage> messages = new List<AnalogyLogMessage>();
            try
            {
                var messagesInternal = new List<Message>();

                var chatLog = File.ReadAllLines(fileName);
                foreach (var chatLine in chatLog)
                {
                    var messageInternal = GetMessage(messagesInternal, chatLine, CultureInfo.CurrentCulture);
                    if (messageInternal != null)
                        messagesInternal.Add(messageInternal);
                }

                foreach (var mi in messagesInternal)
                {
                    AnalogyLogMessage m = new AnalogyEventMessage(mi.Text);
                    m.Date = mi.TimeStamp;
                    m.User = mi.MessageBy ?? "";
                    m.Source = m.User;
                    messages.Add(m);

                }
                messagesHandler.AppendMessages(messages,fileName);
                return messages;

            }
            catch (Exception e)
            {
                AnalogyLogMessage empty = new AnalogyLogMessage(
                    $"Error occured processing file {fileName}. Reason: {e.Message}",
                    AnalogyLogLevel.Critical, AnalogyLogClass.General, source, "None")
                {
                    Source = source,
                    Module = System.Diagnostics.Process.GetCurrentProcess().ProcessName
                };
                messagesHandler.AppendMessage(empty, GetFileNameAsDataSource(fileName));
                return new List<AnalogyLogMessage> { empty };
            }


        }

        private static Message GetMessage(List<Message> messages, string chatLine, CultureInfo culture)
        {
            var message = Message.Parse(chatLine, culture);
            if (message.TimeStamp == default && message.MessageBy == null)
            {
                var lastMessage = messages.Last();
                lastMessage.Text += Environment.NewLine + message.Text;
                return null;
            }

            return message;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetFileNameAsDataSource(string fileName)
        {
            string file = Path.GetFileName(fileName);
            return fileName.Equals(file) ? fileName : $"{file} ({fileName})";
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
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
                return new List<AnalogyLogMessage> {empty};
            }

            List<AnalogyLogMessage> messages = new List<AnalogyLogMessage>();
            try
            {
                using (var stream = File.OpenRead(fileName))
                {
                    using (var reader = new StreamReader(stream))
                    {
                        string firstLine = string.Empty;
                        string otherdata = string.Empty;
                        while (!reader.EndOfStream)
                        {
                            if (string.IsNullOrEmpty(firstLine))
                                firstLine = await reader.ReadLineAsync();
                            if (reader.EndOfStream)
                            {

                                var m = Parse(firstLine);
                                messages.Add(m);
                                messagesHandler.AppendMessage(m, GetFileNameAsDataSource(fileName));
                                continue;
                            }

                            var line = await reader.ReadLineAsync();

                            if (line.Contains(" - "))
                            {
                                string lineToProcess = string.IsNullOrEmpty(firstLine)
                                    ? otherdata
                                    : firstLine + Environment.NewLine + otherdata;
                                var m = Parse(lineToProcess);
                                messages.Add(m);
                                messagesHandler.AppendMessage(m, GetFileNameAsDataSource(fileName));
                                firstLine = line;
                                otherdata = string.Empty;
                            }
                            else
                            {
                                otherdata += line + Environment.NewLine;
                            }
                        }

                        if (!string.IsNullOrEmpty(firstLine))
                        {
                            var m = Parse(firstLine);
                            messages.Add(m);
                            messagesHandler.AppendMessage(m, GetFileNameAsDataSource(fileName));
                        }
                    }
                }

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
                return new List<AnalogyLogMessage> {empty};
            }


        }

        private AnalogyLogMessage Parse(string line)
        {
            int first = line.IndexOf(" - ", StringComparison.InvariantCultureIgnoreCase);
            AnalogyLogMessage m = new AnalogyLogMessage();
            m.Source = source;
            m.Module = source;
            string datetime = line.Substring(0, first);
            if (DateTime.TryParse(datetime, out DateTime dateVal))
            {
                m.Date = dateVal;
            }

            string sub = line.Substring(first + 1);
            int firstSpace = sub.IndexOf(':');
            string level = sub.Substring(0, firstSpace);
            if (level.StartsWith("Info"))
            {
                m.Level = AnalogyLogLevel.Event;
            }
            else if (level.StartsWith("Debug"))
            {
                m.Level = AnalogyLogLevel.Debug;
            }
            else if (level.StartsWith("Warning"))
            {
                m.Level = AnalogyLogLevel.Warning;
            }

            sub = sub.Substring(level.Length);
            //int sourceIndex = sub.IndexOf(']') + 2;
            //m.Source = sub.Substring(2, sourceIndex);
            m.Source = source;
            m.Text = sub; //.Substring(sourceIndex);
            return m;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetFileNameAsDataSource(string fileName)
        {
            string file = Path.GetFileName(fileName);
            return fileName.Equals(file) ? fileName : $"{file} ({fileName})";

        }
    }
}
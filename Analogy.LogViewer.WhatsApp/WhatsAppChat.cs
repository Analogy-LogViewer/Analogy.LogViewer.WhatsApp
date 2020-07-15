using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Analogy.LogViewer.WhatsApp
{
    /// <summary>
    /// A provider to parse WhatsApp chats
    /// </summary>
    public static class WhatsAppChat
    {
        /// <summary>
        /// Parses the exported WhatsApp chat and return a list of messages
        /// </summary>
        /// <param name="filePath">Path to the WhatsApp chat</param>
        /// <param name="culture">The culture to parse the timestamp in the chat</param>
        /// <returns>An enumerable of messages</returns>
        public static IEnumerable<Message> Parse(string filePath, CultureInfo culture)
        {
            var messages = new List<Message>();

            var chatLog = File.ReadAllLines(filePath);
            foreach(var chatLine in chatLog)
            {
                var message = GetMessage(messages, chatLine, culture);
                messages.Add(message);
            }
         
            return messages;
        }

        /// <summary>
        /// Parses the exported WhatsApp chat stream and return a list of messages
        /// </summary>
        /// <param name="fileStream">Stream of the chat file</param>
        /// <param name="culture">The culture to parse the timestamp in the chat</param>
        /// <returns>An enumerable of messages</returns>
        public static IEnumerable<Message> Parse(Stream fileStream, CultureInfo culture)
        {
            var messages = new List<Message>();

            using(var reader = new StreamReader(fileStream))
            {
                while(!reader.EndOfStream)
                {
                    var chatLine = reader.ReadLine();
                    var message = GetMessage(messages, chatLine, culture);
                    messages.Add(message);
                }
            }

            return messages;
        }

        /// <summary>
        /// Parses the exported WhatsApp chat and return a list of messages
        /// </summary>
        /// <param name="filePath">Path to the WhatsApp chat</param>
        /// <returns>An enumerable of messages</returns>
        public static IEnumerable<Message> Parse(string filePath)
        {
            return Parse(filePath, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Parses the exported WhatsApp chat stream and return a list of messages
        /// </summary>
        /// <param name="fileStream">Stream of the chat file</param>
        /// <returns>An enumerable of messages</returns>
        public static IEnumerable<Message> Parse(Stream fileStream)
        {
            return Parse(fileStream, CultureInfo.CurrentCulture);
        }

        private static Message GetMessage(List<Message> messages, string chatLine, CultureInfo culture)
        {
            var message = Message.Parse(chatLine, culture);
            if (message.TimeStamp == default && message.MessageBy == null)
            {
                var lastMessage = messages.Last();
                message.TimeStamp = lastMessage.TimeStamp;
                message.MessageBy = lastMessage.MessageBy;
            }

            return message;
        }
    }
}

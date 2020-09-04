using System;
using System.Drawing;
using Analogy.Interfaces;
using Analogy.LogViewer.WhatsApp.Properties;

namespace Analogy.LogViewer.WhatsApp.IAnalogy
{
    public class ComponentImages : IAnalogyComponentImages
    {
        public Image GetLargeImage(Guid analogyComponentId)
        {
            if (analogyComponentId == WhatsAppTextParserFactory.AnalogyWhatsAppGuid)
                return Resources.whatsappicon32x32;
            return null;
        }

        public Image GetSmallImage(Guid analogyComponentId)
        {
            if (analogyComponentId == WhatsAppTextParserFactory.AnalogyWhatsAppGuid)
                return Resources.whatsappicon16x16;
            return null;
        }

        public Image GetOnlineConnectedLargeImage(Guid analogyComponentId) => null;

        public Image GetOnlineConnectedSmallImage(Guid analogyComponentId) => null;

        public Image GetOnlineDisconnectedLargeImage(Guid analogyComponentId) => null;

        public Image GetOnlineDisconnectedSmallImage(Guid analogyComponentId) => null;
    }
}
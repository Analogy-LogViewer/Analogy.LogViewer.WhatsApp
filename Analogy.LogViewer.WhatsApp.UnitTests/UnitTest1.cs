using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Analogy.LogViewer.WhatsApp.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        public string fileName = "Test1.txt";
        [TestMethod]
        public  async Task TestMethod1()
        {
            WhatsAppTextLogFileLoader parser = new WhatsAppTextLogFileLoader();
            CancellationTokenSource cts = new CancellationTokenSource();
            MessageHandlerForTesting forTesting = new MessageHandlerForTesting();
            var messages = await parser.Process(fileName, cts.Token, forTesting);
            Assert.IsTrue(messages.Count() == 13);
        }
    }
}

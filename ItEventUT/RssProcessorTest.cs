using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Buisness;
using System.IO;
using System.IO.IsolatedStorage;
using Windows.Storage;
using System.Windows.Resources;

namespace ItEventUT
{
    [TestClass]
    public class RssProcessorTest
    {
        string testFileName = @"Assets/TestData.xml";

        [TestMethod]
        public void RssProcessor_UpdtateFeedList_Test()
        {
            string content = null;

            StreamResourceInfo res = App.GetResourceStream(new Uri(testFileName, UriKind.Relative));
            content = new StreamReader(res.Stream).ReadToEnd();

            RssProcessor rssProcessor = new RssProcessor(string.Empty);
            rssProcessor.UpdtateFeedList(content);
        }
    }
}
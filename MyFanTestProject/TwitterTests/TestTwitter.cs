using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyFan.App_Code.Twitter;

namespace MyFanTestProject.TwitterTests
{
    /// <summary>
    /// Tests the Twitter API
    /// </summary>
    [TestClass]
    public class TestTwitter
    {
        TwitterClient twitterClient;

        [TestInitialize]
        public void setUp()
        {
            twitterClient = new TwitterClient();
        }
        
        [TestMethod]
        public void testUpdate()
        {
            if (twitterClient != null)
            {
                Assert.IsTrue(twitterClient.tweet("Hello from test: " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")));
            }
        }
    }
}

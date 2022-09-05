using System;
using System.Diagnostics.Tracing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlickrStream.Infrastructure.Test
{
    [TestClass]
    public class UrlHelperTest
    {
        [TestMethod]
        public void GetPublicFeedUrl_TagsIsEmpty_DoesNotAppendsTags()
        {
            var url = UrlHelper.GetPublicFeedUrl(string.Empty, "all", "en-us", "testId");

            Assert.IsFalse(url.Contains("&tags="));
        }

        [TestMethod]
        public void GetPublicFeedUrl_TagsValidValue_AppendsTags()
        {
            const string tag = "testTag";
            var url = UrlHelper.GetPublicFeedUrl(tag, "all", "en-us", "testId");

            Assert.IsTrue(url.Contains("&tags="));
            Assert.IsTrue(url.Contains(tag));
        }

        [TestMethod]
        public void GetPublicFeedUrl_TagModeIsEmpty_DoesNotAppendsTagMode()
        {
            var url = UrlHelper.GetPublicFeedUrl(string.Empty, string.Empty, "en-us", "testId");

            Assert.IsFalse(url.Contains("&tagmode="));
        }

        [TestMethod]
        public void GetPublicFeedUrl_TagmodeValidValue_AppendsTagmode()
        {
            const string tagmode = "all";
            var url = UrlHelper.GetPublicFeedUrl(string.Empty, tagmode, "en-us", "testId");

            Assert.IsTrue(url.Contains("&tagmode="));
            Assert.IsTrue(url.Contains(tagmode));
        }

        [TestMethod]
        public void GetPublicFeedUrl_LangIsEmpty_DoesNotAppendsLang()
        {
            var url = UrlHelper.GetPublicFeedUrl(string.Empty, "all", string.Empty, "testId");

            Assert.IsFalse(url.Contains("&lang="));
        }

        [TestMethod]
        public void GetPublicFeedUrl_LangValidValue_AppendsLang()
        {
            const string lang = "en-us";
            var url = UrlHelper.GetPublicFeedUrl(string.Empty, "all", lang, "testId");

            Assert.IsTrue(url.Contains("&lang="));
            Assert.IsTrue(url.Contains(lang));
        }

        [TestMethod]
        public void GetPublicFeedUrl_IDsIsEmpty_DoesNotAppendsIDs()
        {
            var url = UrlHelper.GetPublicFeedUrl(string.Empty, "all", "en-us", string.Empty);

            Assert.IsFalse(url.Contains("&id="));
            Assert.IsFalse(url.Contains("&ids="));
        }

        [TestMethod]
        public void GetPublicFeedUrl_SingleIDValidValue_AppendsID()
        {
            const string id = "testId";
            var url = UrlHelper.GetPublicFeedUrl(string.Empty, "all", "en-us", id);

            Assert.IsTrue(url.Contains("&id="));
            Assert.IsFalse(url.Contains("&ids="));
            Assert.IsTrue(url.Contains(id));
        }

        [TestMethod]
        public void GetPublicFeedUrl_MultipleIDsValidValue_AppendsIDs()
        {
            const string id = "testId1,testID2";
            var url = UrlHelper.GetPublicFeedUrl(string.Empty, "all", "en-us", id);

            Assert.IsTrue(url.Contains("&ids="));
            Assert.IsFalse(url.Contains("&id="));
            Assert.IsTrue(url.Contains(id));
        }
    }
}

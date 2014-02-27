using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpNTCIP.DMS;

namespace SharpNtcipTests
{
    [TestClass]
    public class Test_Multi
    {
        const string BASE_MULTI_STRING = @"THIS IS [cb3]A TEST [cb]WITH COLOR CHANGE";
        const string BASE_XML_EXPECT = @"<multi>THIS IS <cb3 />A TEST <cb />WITH COLOR CHANGE</multi>";
        const string BASE_TOSTRING_EXPECT = @"THIS IS A TEST WITH COLOR CHANGE";

        [TestMethod]
        public void MultiInstantiation()
        {
            MultiString multi = new MultiString(BASE_MULTI_STRING);
            Assert.AreEqual(BASE_MULTI_STRING, multi.Multi, 
                @"MULTI Instantiation failed");
        }

        [TestMethod]
        public void MultiXml()
        {
            MultiString multi = new MultiString(BASE_MULTI_STRING);
            Assert.AreEqual(BASE_XML_EXPECT, multi.MultiDocument.ToString(), 
                @"MULTI --> HTML Conversion failed");
        }

        [TestMethod]
        public void MultiToString()
        {
            MultiString multi = new MultiString(BASE_MULTI_STRING);
            Assert.AreEqual(BASE_TOSTRING_EXPECT, multi.ToString(), 
                @"MULTI --> ToString Conversion failed");
        }
    }
}

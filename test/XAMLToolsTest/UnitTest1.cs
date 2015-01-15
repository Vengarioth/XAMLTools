using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XAMLTools;

namespace XAMLToolsTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var parser = new XAMLParser();

            parser.Parse("<a x:Name=\"ATag\">Test</a><element /><x:Test></x:Test><withBinding Property=\"{}\" />");
        }
    }
}

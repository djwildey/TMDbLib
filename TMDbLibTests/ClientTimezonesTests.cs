using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TMDbLib.Objects.Timezones;
using TMDbLibTests.JsonHelpers;

namespace TMDbLibTests
{
    [TestClass]
    public class ClientTimezonesTests : TestBase
    {
        private TestConfig _config;

        /// <summary>
        /// Run once, on every test
        /// </summary>
        [TestInitialize]
        public override void Initiator()
        {
            base.Initiator();

            _config = new TestConfig();
        }

        [TestMethod]
        public void TestTimezonesList()
        {
            Timezones result = _config.Client.GetTimezonesAsync().Result;

            Assert.IsNotNull(result);
            Assert.IsTrue(result.List.Count > 200);

            List<string> item = result.List["DK"];
            Assert.IsNotNull(item);
            Assert.AreEqual(1, item.Count);
            Assert.AreEqual("Europe/Copenhagen", item[0]);
        }
    }
}
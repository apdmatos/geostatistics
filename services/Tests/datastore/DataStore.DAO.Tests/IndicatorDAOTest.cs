using DataStore.DAO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataStore.Common.Model;
using System.Collections.Generic;
using System.Linq;

namespace DataStore.DAO.Tests
{
    /// <summary>
    ///This is a test class for IndicatorDAOTest and is intended
    ///to contain all IndicatorDAOTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IndicatorDAOTest : BaseTestClass
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        /// <summary>
        ///A test for IndicatorDAO Constructor
        ///</summary>
        [TestMethod()]
        public void IndicatorDAOConstructorTest()
        {
            IndicatorDAO target = new IndicatorDAO(connnetion);
            Assert.AreNotEqual(target, null);
        }

        /// <summary>
        ///A test for GetIndicatorById
        ///</summary>
        [TestMethod()]
        public void GetIndicatorByIdTest()
        {
            IndicatorDAO target = new IndicatorDAO(connnetion);
            int providerId = 1;
            int indicatorId = 1;
            Indicator expected = new Indicator
            {
                ID = 1,
                Name = "Densidade populacional (N.º/ km²) por Local de residência; Anual",
                NameAbbr = "Densidade populacional (N.º/ km²)",
                Provider = new Provider
                {
                    ID = 1,
                    Name = "Instituto Nacional de Estatística",
                    NameAbbr = "INE",
                    ServiceURL = "http://localhost:42136/INEStatisticsProvider.svc",
                    URL = "http://www.ine.pt"
                },
                SourceID = "0000009",
                SubThemeID = 1,
                ThemeID = 1
            };
            Indicator actual;
            actual = target.GetIndicatorById(providerId, indicatorId);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetIndicatorsByProviderId
        ///</summary>
        [TestMethod()]
        public void GetIndicatorsByProviderIdTest()
        {
            IndicatorDAO target = new IndicatorDAO(connnetion);
            int providerId = 1;
            Nullable<int> page = new Nullable<int>(1);
            Nullable<int> recordsPerPage = new Nullable<int>(1);
            IEnumerable<Indicator> actual;
            actual = target.GetIndicatorsByProviderId(providerId, page, recordsPerPage);
            Assert.AreNotEqual(actual, null);
            Assert.AreEqual(actual.Count(), 1);
        }

        /// <summary>
        ///A test for GetIndicatorsBySubThemeId
        ///</summary>
        [TestMethod()]
        public void GetIndicatorsBySubThemeIdTest()
        {
            IndicatorDAO target = new IndicatorDAO(connnetion); 
            int providerId = 1;
            int themeId = 1;
            int subthemeId = 1;
            Nullable<int> page = new Nullable<int>(1);
            Nullable<int> recordsPerPage = new Nullable<int>(1);
            IEnumerable<Indicator> actual = target.GetIndicatorsBySubThemeId(providerId, themeId, subthemeId, page, recordsPerPage);
            Assert.AreNotEqual(actual, null);
            Assert.AreEqual(actual.Count(), 1);
        }

        /// <summary>
        ///A test for GetTotalIndicators
        ///</summary>
        [TestMethod()]
        public void GetTotalIndicatorsByThemesTest()
        {
            IndicatorDAO target = new IndicatorDAO(connnetion);
            int providerId = 1;
            Nullable<int> themeId = new Nullable<int>(1);
            Nullable<int> subThemeId = new Nullable<int>(1);
            long expected = 1;
            long actual;
            actual = target.GetTotalIndicators(providerId, themeId, subThemeId);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetTotalIndicators
        ///</summary>
        [TestMethod()]
        public void GetTotalIndicatorsTest()
        {
            IndicatorDAO target = new IndicatorDAO(connnetion);
            int providerId = 1;
            long expected = 1;
            long actual;
            actual = target.GetTotalIndicators(providerId, null, null);
            Assert.AreEqual(expected, actual);
        }
    }
}

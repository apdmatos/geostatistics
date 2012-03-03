using DataStore.DAO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataStore.Model;
using System.Collections.Generic;
using System.Linq;

namespace DataStore.DAO.Tests
{
    /// <summary>
    ///This is a test class for ThemesDAOTest and is intended
    ///to contain all ThemesDAOTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ThemesDAOTest : BaseTestClass
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
        ///A test for ThemesDAO Constructor
        ///</summary>
        [TestMethod()]
        public void ThemesDAOConstructorTest()
        {
            ThemesDAO target = new ThemesDAO();
            Assert.AreNotEqual(target, null);
        }

        /// <summary>
        ///A test for GetProviderSubThemes
        ///</summary>
        [TestMethod()]
        public void GetProviderSubThemesTest()
        {
            ThemesDAO target = new ThemesDAO();
            int providerId = 1;
            int themeId = 1;
            SubTheme expected = new SubTheme
            {
                ID = 1,
                Name = "Ordenamento do território",
                NameAbbr = "Ordenamento do território",
                ProviderID = 1,
                ThemeID = 1
            };
            IEnumerable<SubTheme> actual;
            actual = target.GetProviderSubThemes(providerId, themeId);
            Assert.AreEqual(1, actual.Count());
            Assert.AreEqual(expected, actual.ElementAt(0));
        }

        /// <summary>
        ///A test for GetProviderThemes
        ///</summary>
        [TestMethod()]
        public void GetProviderThemesTest()
        {
            ThemesDAO target = new ThemesDAO();
            int providerId = 1;
            Theme expected = new Theme 
            { 
                ID = 1,
                Name = "Território",
                NameAbbr = "Território",
                ProviderID = 1
            }; 
            IEnumerable<Theme> actual = target.GetProviderThemes(providerId);
            Assert.AreEqual(1, actual.Count());
            Assert.AreEqual(expected, actual.ElementAt(0));
        }
    }
}

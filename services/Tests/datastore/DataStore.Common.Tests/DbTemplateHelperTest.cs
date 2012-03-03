﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using DataStore.DbHelpers.templates;

namespace DataStore.DbHelpers.Tests
{
    /// <summary>
    /// Summary description for DbTemplateHelperTest
    /// </summary>
    [TestClass]
    public class DbTemplateHelperTest : BaseTestClass
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

        [TestMethod]
        public void GetListBySQLQuery()
        {
            IEnumerable<int> config = DbTemplateHelper<int>.GetListBySQLQuery(
                                    (reader) =>
                                    {
                                        return (int)reader["configuration_id"];
                                    },
                                    "select configuration_id from config.configurationview limit 2",
                                    null);


            Assert.AreEqual(config.Count(), 2);
            Assert.AreNotEqual(config.ElementAt(0), default(int));
            Assert.AreNotEqual(config.ElementAt(1), default(int));
        }

        [TestMethod]
        public void GetListByProcedure()
        {
            IEnumerable<int> providers = DbTemplateHelper<int>.GetListByProcedure(
                                            (reader) =>
                                            {
                                                return (int)reader["provider_id"];
                                            },
                                            "config.getProviders",
                                            new DbParameterHelper[]
                                            {
                                                new DbParameterHelper(DbType.Int32, "p_page", 1),
                                                new DbParameterHelper(DbType.Int32, "p_recordsPerPage", 1),
                                            });


            Assert.AreEqual(providers.Count(), 1);
            Assert.AreEqual(providers.ElementAt(0), 1);
        }

        [TestMethod]
        public void GetObjectByProcedure()
        {
            int providerId = DbTemplateHelper<int>.GetObjectByProcedure(
                                    (reader) =>
                                    {
                                        return (int)reader["provider_id"];
                                    },
                                    "config.getProviders",
                                    new DbParameterHelper[]
                                    {
                                        new DbParameterHelper(DbType.Int32, "p_page", 1),
                                        new DbParameterHelper(DbType.Int32, "p_recordsPerPage", 1),
                                    });

            Assert.AreNotEqual(providerId, default(int));
        }

        [TestMethod]
        public void GetObjectBySQLQuery()
        {
            int providerId = DbTemplateHelper<int>.GetObjectBySQLQuery(
                                    (reader) =>
                                    {
                                        return (int)reader["provider_id"];
                                    },
                                    "select * from config.providerview limit 1",
                                    null);


            Assert.AreNotEqual(providerId, default(int));
        }

        [TestMethod]
        public void GetValueBySQLQuery()
        {
            int providerId = DbTemplateHelper<int>.GetValueBySQLQuery(
                                    "select provider_id from config.providerview limit 1",
                                    null);

            Assert.AreNotEqual(providerId, default(int));
        }

        [TestMethod]
        public void GetValueByProcedure()
        {
            string url = DbTemplateHelper<string>.GetValueByProcedure(
                                    "config.getShapefileConfigurarionURL", 
                                    new DbParameterHelper[]{
                                        new DbParameterHelper(DbType.Int32, "p_indicatorId", 1),
                                        new DbParameterHelper(DbType.String, "p_geolevel", "NUTS1"),
                                    });

            Assert.AreNotEqual(url, null);
        }

        [TestMethod]
        public void GetValuesBySQLQuery()
        {
            IEnumerable<int> providers = DbTemplateHelper<int>.GetValuesBySQLQuery(
                                            "select provider_id from config.providerview limit 1",
                                            null);

            Assert.AreNotEqual(providers.Count(), 1);
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyFan.Account;
using MyFan.App_Data;
using System.Configuration;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace MyFanTestProject.ConnectionTests
{
    [TestClass]
    public class TestConnection
    {
        Connection connection;
        

        [TestInitialize]
        public void setUp()
        {
            connection = new Connection(ConfigurationManager.ConnectionStrings["MyFanConnection"].ConnectionString);
        }


        [TestMethod]
        public void TestOpen()
        {
            Assert.IsTrue(connection.openConnection());
        }

        [TestMethod]
        public void TestStoredProcedure()
        {
            connection.openConnection();
            Object result = connection.executeStoredProcedure("TestProcedure");
            Assert.IsInstanceOfType(result, typeof(SqlDataReader));
        }

        [TestCleanup]
        public void reset()
        {
            connection.closeConnection();
            connection = null;
        }
    }
}

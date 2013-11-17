/*
 * Nombre del Archivo: TestConnection
 */

/*
 * Descripción: Clase de testing para realizar pruebas sobre los métodos de la clase 
 * de conexión de MyFan
 */

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
        /// <summary>
        /// Objeto de la clase Conecction, empleada en MyFan para las operaciones con la Base de Datos.
        /// </summary>
        Connection connection;
        

        /// <summary>
        /// Inicializa los objetos en común que van a utilizar los métodos de la clase.
        /// </summary>
        [TestInitialize]
        public void setUp()
        {
            connection = new Connection(ConfigurationManager.ConnectionStrings["MyFanConnection"].ConnectionString);
        }

        /// <summary>
        /// Prueba el método openConnection de la clase Connection.
        /// </summary>
        [TestMethod]
        public void TestOpen()
        {
            Assert.IsTrue(connection.openConnection());
        }

        /// <summary>
        /// Prueba el método executeStoredProcedure de la clase Connection.
        /// </summary>
        [TestMethod]
        public void TestStoredProcedure()
        {
            connection.openConnection();
            Object result = connection.executeStoredProcedure("TestProcedure");
            Assert.IsInstanceOfType(result, typeof(SqlDataReader));
        }

        /// <summary>
        /// Al finalizar las pruebas, se ejecuta este método para cerrar la conexión.
        /// </summary>
        [TestCleanup]
        public void reset()
        {
            connection.closeConnection();
            connection = null;
        }
    }
}

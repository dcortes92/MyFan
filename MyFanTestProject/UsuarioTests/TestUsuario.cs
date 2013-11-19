using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyFan.App_Code.Usuario;
using MyFan.App_Code.Negocio;

namespace MyFanTestProject.UsuarioTests
{
    [TestClass]
    public class TestUsuario
    {
        Usuario usuario;
        String JSon;
        Deserializer ds;

        [TestInitialize]
        public void setUp()
        {
            usuario = new Usuario("daniel", "123456", "dcortes92@hotmail.com", "18-06-1992");
            ds = new Deserializer();
        }

        [TestMethod]
        public void TestJSon()
        {
            JSon = usuario.toJSon();
            Console.WriteLine("Resultado: " + JSon);
            Assert.IsInstanceOfType(JSon, typeof(String));
        }

        [TestMethod]
        public void TestDeserializer()
        {
            JSon = usuario.toJSon();
            Usuario temp = (Usuario)ds.deserialize(JSon, typeof(Usuario));
            Console.WriteLine("Restulado: " + temp.Nombre_Usuario + " " + temp.Contrasenia + " " + temp.Correo_Electronico
                    + " " + temp.Fecha_Creacion);
            Assert.IsInstanceOfType(temp, typeof(Usuario));
        }
    }
}

#region Header

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using _3PwdLibrary;
using G = _3PwdLibrary.Global;
using MR = _3PwdLibrary.ManejadorRegistros;

namespace _3PwdMSTests
{

#endregion

    [TestClass]
    public class MR_DeleteRegPwd
    {
        [TestMethod]
        public void ConCamposNulos()
        {
            // Preparar
            var regPwd = new RegistroPwd
            {
                Categoria = null
            };

            // Ejecutar
            bool deleteOk = MR.DeleteRegPwd(regPwd);

            // Probar
            Assert.IsFalse(deleteOk);
            Assert.IsTrue(MR.HayError);
            Assert.AreEqual($"*** Error(MR.DeleteRegPwd): key invalida: '{MR.KeyVacia}'! ***", MR.MensajeError);
        }

        [TestMethod]
        public void NoInicializado()
        {
            // Preparar
            var regPwd = new RegistroPwd();

            // Ejecutar
            bool deleteOk = MR.DeleteRegPwd(regPwd, enMaestro: false);

            // Probar
            Assert.IsFalse(deleteOk);
            Assert.IsTrue(MR.HayError);
            Assert.AreEqual($"*** Error(MR.DeleteRegPwd): key invalida: '{MR.KeyVacia}'! ***", MR.MensajeError);
        }

        [TestMethod]
        public void Nulo()
        {
            // Preparar
            RegistroPwd regPwd = null;

            // Ejecutar
            bool deleteOk = MR.DeleteRegPwd(regPwd, enMaestro: false);

            // Probar
            Assert.IsFalse(deleteOk);
            Assert.IsTrue(MR.HayError);
            Assert.AreEqual($"*** Error(MR.DeleteRegPwd): key invalida: '{G.RegNull}'! ***", MR.MensajeError);
        }

        [TestMethod]
        public void Ok()
        {
            // Preparar
            var regPwd = new RegistroPwd
            {
                UserNombre = "Luis",
                Categoria = "Licencias",
                Producto = "Audaciti",
                UserId = "luigi_alberto",
                UserPwd = "illimani",
                UserEMail = "luigi@gmail.com"
            };
            MR.ClearTableMaestro();
            RegistroPwd regPwdAdd = MR.CreateRegPwd(regPwd, enMaestro: false);
            var regPwdDel = new RegistroPwd
            {
                UserNombre = "Luis",
                Categoria = "Licencias",
                Producto = "Audaciti"
            };

            // Ejecutar
            bool deleteOk = MR.DeleteRegPwd(regPwdDel, enMaestro: false);

            // Probar
            Assert.IsTrue(deleteOk);
            Assert.IsFalse(MR.HayError);
            Assert.AreEqual("", MR.MensajeError);
        }

        [TestMethod]
        public void Ok_enMaestro()
        {
            // Preparar
            MR.NameMaestro = "_FileDelete_Ok";
            MR.EmptyMaestro();
            var regPwd = new RegistroPwd
            {
                UserNombre = "Erick",
                Categoria = "Programas",
                Producto = "SharePoint",
                UserId = "erick_ronald",
                UserPwd = "Xanadu",
                UserEMail = "erick@gmail.com"
            };
            RegistroPwd regPwdAdd = MR.CreateRegPwd(regPwd);
            var regPwdDel = new RegistroPwd
            {
                UserNombre = "Erick",
                Categoria = "Programas",
                Producto = "SharePoint"
            };

            // Ejecutar
            bool deleteOk = MR.DeleteRegPwd(regPwdDel);  // == MR.CreateRegPwd(regPwd, enMaestro: true);

            // Probar
            var regPwdGet = MR.RetrieveRegPwd(regPwdDel);
            Assert.IsTrue(deleteOk);
            Assert.IsNull(regPwdGet);
            Assert.IsFalse(MR.HayError);
            Assert.AreEqual("", MR.MensajeError);
            MR.NameMaestro = MR.NameMaestro_Default;
        }

        [TestMethod]
        public void Row_noInicializado()
        {
            // Preparar
            var regPwd = new RegistroPwd();
            string rowPwd = MR.RegistroPwdToRow(regPwd);

            // Ejecutar
            bool deleteOk = MR.DeleteRegPwd(rowPwd, enMaestro: false);

            // Probar
            Assert.IsFalse(deleteOk);
            Assert.IsTrue(MR.HayError);
            Assert.AreEqual($"*** Error(MR.DeleteRegPwd): key invalida: '{MR.KeyVacia}'! ***", MR.MensajeError);
        }

        [TestMethod]
        public void Row_nulo()
        {
            // Preparar
            string rowPwd = null;

            // Ejecutar
            bool deleteOk = MR.DeleteRegPwd(rowPwd, enMaestro: false);

            // Probar
            Assert.IsFalse(deleteOk);
            Assert.IsTrue(MR.HayError);
            Assert.AreEqual($"*** Error(MR.DeleteRegPwd): key invalida: '{G.RegNull}'! ***", MR.MensajeError);
        }

        [TestMethod]
        public void Row_vacia()
        {
            // Preparar
            string rowPwd = "";

            // Ejecutar
            bool deleteOk = MR.DeleteRegPwd(rowPwd, enMaestro: false);

            // Probar
            Assert.IsFalse(deleteOk);
            Assert.IsTrue(MR.HayError);
            Assert.AreEqual($"*** Error(MR.DeleteRegPwd): key invalida: '{MR.KeyVacia}'! ***", MR.MensajeError);
        }

        [TestMethod]
        public void Row_ok()
        {
            // Preparar
            var regPwd = new RegistroPwd
            {
                UserNombre = "Maria",
                Categoria = "Soft",
                Producto = "Kitchen",
                UserId = "maria",
                UserPwd = "clave secreta",
                UserEMail = "maria@gmail.com"
            };
            string rowPwd = MR.RegistroPwdToRow(regPwd);
            MR.ClearTableMaestro();
            string rowPwdAdd = MR.CreateRegPwd(rowPwd, enMaestro: false);

            // Ejecutar
            bool deleteOk = MR.DeleteRegPwd(rowPwdAdd, enMaestro: false);

            // Probar
            Assert.IsTrue(deleteOk);
            Assert.IsFalse(MR.HayError);
            Assert.AreEqual("", MR.MensajeError);
        }

        [TestMethod]
        public void Row_ok_enMaestro()
        {
            // Preparar
            MR.NameMaestro = "_FileDelete_RowOk";
            MR.EmptyMaestro();
            var regPwd = new RegistroPwd
            {
                UserNombre = "Xime_" + Guid.NewGuid().ToString()[0..8],
                Categoria = "Tools",
                Producto = "Photo",
                UserId = "ximenita",
                UserPwd = "clave ULTRA secreta",
                UserEMail = "xime@gmail.com"
            };
            string rowPwd = MR.RegistroPwdToRow(regPwd);
            MR.CreateRegPwd(rowPwd);

            // Ejecutar
            bool deleteOk = MR.DeleteRegPwd(rowPwd); // == MR.DeleteRegPwd(rowPwd, enMaestro: true);

            // Probar
            Assert.IsTrue(deleteOk);
            Assert.IsFalse(MR.HayError);
            Assert.AreEqual("", MR.MensajeError);
            string rowPwdGet = MR.RetrieveRegPwd(rowPwd);
            Assert.AreEqual("", rowPwdGet);
            MR.NameMaestro = MR.NameMaestro_Default;
        }
    }

    #region Footer
}
#endregion

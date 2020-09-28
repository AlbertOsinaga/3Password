#region Header

using Microsoft.VisualStudio.TestTools.UnitTesting;

using _3PwdLibrary;
using G = _3PwdLibrary.Global;
using MR = _3PwdLibrary.ManejadorRegistros;

namespace _3PwdMSTests
{

#endregion

    [TestClass]
    public class MR_RetrieveRegPwd
    {
        #region RetrieveRegistro

        [TestMethod]
        public void ConCamposNulos()
        {
            // Preparar
            var regPwd = new RegistroPwd
            {
                Categoria = null
            };

            // Ejecutar
            RegistroPwd regPwdGet = MR.RetrieveRegPwd(regPwd, enMaestro: false);

            // Probar
            Assert.IsNull(regPwdGet);
            Assert.IsTrue(MR.HayError);
            Assert.AreEqual($"*** Error(MR.RetrieveRegPwd): key invalida: '{MR.KeyVacia}'! ***", MR.MensajeError);
        }

        [TestMethod]
        public void NoInicializado()
        {
            // Preparar
            var regPwd = new RegistroPwd();

            // Ejecutar
            RegistroPwd regPwdGet = MR.RetrieveRegPwd(regPwd, enMaestro: false);

            // Probar
            Assert.IsNull(regPwdGet);
            Assert.IsTrue(MR.HayError);
            Assert.AreEqual($"*** Error(MR.RetrieveRegPwd): key invalida: '{MR.KeyVacia}'! ***", MR.MensajeError);
        }

        [TestMethod]
        public void Nulo()
        {
            // Preparar
            RegistroPwd regPwd = null;

            // Ejecutar
            RegistroPwd regPwdGet = MR.RetrieveRegPwd(regPwd, enMaestro: false);

            // Probar
            Assert.IsNull(regPwdGet);
            Assert.IsTrue(MR.HayError);
            Assert.AreEqual($"*** Error(MR.RetrieveRegPwd): key invalida: '{G.RegNull}'! ***", MR.MensajeError);
        }

        [TestMethod]
        public void Ok()
        {
            // Preparar
            var regPwdAdd = new RegistroPwd
            {
                Categoria = "Softw",
                Empresa = "Adobe",
                Producto = "Photosho",
                UserId = "lu_alberto",
                UserPwd = "illampu",
                UserEMail = "lu@gmail.com",
                UserNota = "Licencia 534535353"
            };
            var regPwd = new RegistroPwd
            {
                Categoria = "Softw",
                Empresa = "Adobe",
                Producto = "Photosho"
            };
            MR.ClearTableMaestro();
            MR.CreateRegPwd(regPwdAdd, enMaestro: false);

            // Ejecutar
            RegistroPwd regPwdGet = MR.RetrieveRegPwd(regPwd, enMaestro: false);

            // Probar
            Assert.IsNotNull(regPwdGet);
            Assert.IsFalse(MR.HayError);
            Assert.AreEqual("", MR.MensajeError);
        }

        [TestMethod]
        public void Ok_enMaestro()
        {
            // Preparar
            MR.EmptyMaestro();
            var regPwdAdd = new RegistroPwd
            {
                Categoria = "Keys",
                Empresa = "Adobe",
                Producto = "Photosho",
                UserId = "lu_alberto",
                UserPwd = "illampu",
                UserEMail = "lu@gmail.com",
                UserNota = "Licencia 534535353"
            };
            var regPwd = new RegistroPwd
            {
                Categoria = "Keys",
                Empresa = "Adobe",
                Producto = "Photosho"
            };
            MR.CreateRegPwd(regPwdAdd);
            MR.WriteMaestro();

            // Ejecutar
            RegistroPwd regPwdGet = MR.RetrieveRegPwd(regPwd); // == MR.RetrieveRegPwd(regPwd, enMaestro: true);

            // Probar
            Assert.IsNotNull(regPwdGet);
            Assert.AreEqual(regPwdAdd.UserId, regPwdGet.UserId);
            Assert.IsFalse(MR.HayError);
            Assert.AreEqual("", MR.MensajeError);
        }

        [TestMethod]
        public void Row_noInicializado()
        {
            // Preparar
            var regPwd = new RegistroPwd();
            string rowPwd = MR.RegistroPwdToRow(regPwd);

            // Ejecutar
            string rowPwdGet = MR.RetrieveRegPwd(rowPwd, enMaestro: false);

            // Probar
            Assert.AreEqual("", rowPwdGet);
            Assert.IsTrue(MR.HayError);
            Assert.AreEqual($"*** Error(MR.RetrieveRegPwd): key invalida: '{MR.KeyVacia}'! ***", MR.MensajeError);
        }

        [TestMethod]
        public void Row_nulo()
        {
            // Preparar
            string rowPwd = null;

            // Ejecutar
            string rowPwdGet = MR.RetrieveRegPwd(rowPwd, enMaestro: false);

            // Probar
            Assert.AreEqual("", rowPwdGet);
            Assert.IsTrue(MR.HayError);
            Assert.AreEqual($"*** Error(MR.RetrieveRegPwd): key invalida: '{G.RegNull}'! ***", MR.MensajeError);
        }

        [TestMethod]
        public void Row_vacia()
        {
            // Preparar
            string rowPwd = "";

            // Ejecutar
            string rowPwdGet = MR.RetrieveRegPwd(rowPwd, enMaestro: false);

            // Probar
            Assert.AreEqual("", rowPwdGet);
            Assert.IsTrue(MR.HayError);
            Assert.AreEqual($"*** Error(MR.RetrieveRegPwd): key invalida: '{MR.KeyVacia}'! ***", MR.MensajeError);
        }

        [TestMethod]
        public void Row_ok()
        {
            // Preparar
            var regPwd = new RegistroPwd
            {
                UserNombre = "LALOS",
                Categoria = "Varios",
                Producto = "Excel",
                UserId = "luis alberto",
                UserPwd = "clave secreta",
                UserEMail = "luis@gmail.com"
            };
            string rowPwd = MR.RegistroPwdToRow(regPwd);
            var regPwdAdd = new RegistroPwd
            {
                UserNombre = "LALOS",
                Categoria = "Varios",
                Producto = "Excel",
            };
            MR.ClearTableMaestro();
            MR.CreateRegPwd(regPwd, enMaestro: false);

            // Ejecutar
            string rowPwdGet = MR.RetrieveRegPwd(rowPwd, enMaestro: false);

            // Probar
            Assert.IsNotNull(rowPwdGet);
            Assert.IsFalse(MR.HayError);
            Assert.AreEqual("", MR.MensajeError);
        }

        [TestMethod]
        public void Row_ok_enMaestro()
        {
            // Preparar
            MR.EmptyMaestro();
            var regPwd = new RegistroPwd
            {
                UserNombre = "PILATOS",
                Categoria = "Varios",
                Producto = "Excel",
                UserId = "luis alberto",
                UserPwd = "clave secreta",
                UserEMail = "luis@gmail.com"
            };
            string rowPwd = MR.RegistroPwdToRow(regPwd);
            string rowPwdAdd = MR.CreateRegPwd(rowPwd);
            MR.WriteMaestro();

            // Ejecutar
            string rowPwdGet = MR.RetrieveRegPwd(rowPwd); // == MR.RetrieveRegPwd(rowPwd, enMaestro: true);

            // Probar
            Assert.IsNotNull(rowPwdGet);
            Assert.AreEqual(rowPwdGet, rowPwdAdd);
            Assert.IsFalse(MR.HayError);
            Assert.AreEqual("", MR.MensajeError);
        }

        #endregion
    }

#region Footer
}
#endregion

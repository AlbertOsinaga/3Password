#region Header

using Microsoft.VisualStudio.TestTools.UnitTesting;

using _3PwdLibrary;
using G = _3PwdLibrary.Global;
using MR = _3PwdLibrary.ManejadorRegistros;

namespace _3PwdMSTests
{

#endregion

   [TestClass]
    public class MR_UpdateRegPwd
    {
        #region UpdateRegistro

        [TestMethod]
        public void ConCamposNulos()
        {
            // Preparar
            var regPwd = new RegistroPwd
            {
                Categoria = null
            };

            // Ejecutar
            RegistroPwd regPwdUpd = MR.UpdateRegPwd(regPwd, enMaestro: false);

            // Probar
            Assert.IsNull(regPwdUpd);
            Assert.IsTrue(MR.HayError);
            Assert.AreEqual($"Error: key invalida: '{MR.KeyVacia}', en ManejadorRegistros.UpdateRegPwd!", MR.MensajeError);
        }

        [TestMethod]
        public void NoInicializado()
        {
            // Preparar
            var regPwd = new RegistroPwd();

            // Ejecutar
            RegistroPwd regPwdAdd = MR.UpdateRegPwd(regPwd, enMaestro: false);

            // Probar
            Assert.IsNull(regPwdAdd);
            Assert.IsTrue(MR.HayError);
            Assert.AreEqual($"Error: key invalida: '{MR.KeyVacia}', en ManejadorRegistros.UpdateRegPwd!", MR.MensajeError);
        }

        [TestMethod]
        public void Nulo()
        {
            // Preparar
            RegistroPwd regPwd = null;

            // Ejecutar
            RegistroPwd regPwdAdd = MR.UpdateRegPwd(regPwd, enMaestro: false);

            // Probar
            Assert.IsNull(regPwdAdd);
            Assert.IsTrue(MR.HayError);
            Assert.AreEqual($"Error: key invalida: '{G.RegNull}', en ManejadorRegistros.UpdateRegPwd!", MR.MensajeError);
        }

        [TestMethod]
        public void Ok()
        {
            // Preparar
            var regPwd = new RegistroPwd
            {
                UserNombre = "Pedro",
                Categoria = "Cosas",
                Producto = "Audacity",
                UserId = "luigi_alberto",
                UserPwd = "illimani",
                UserEMail = "luigi@gmail.com"
            };
            MR.ClearTableMaestro();
            RegistroPwd regPwdAdd = MR.CreateRegPwd(regPwd, enMaestro: false);
            regPwdAdd.UserId = "mario_bross";
            regPwdAdd.UserPwd = "la@clave*mas$secreta";

            // Ejecutar
            RegistroPwd regPwdUpd = MR.UpdateRegPwd(regPwdAdd, enMaestro: false);

            // Probar
            Assert.IsNotNull(regPwdUpd);
            Assert.AreEqual(regPwdAdd.UserId, regPwdUpd.UserId);
            Assert.AreEqual(regPwdAdd.UserPwd, regPwdUpd.UserPwd);
            Assert.IsFalse(MR.HayError);
            Assert.AreEqual("", MR.MensajeError);
        }

        [TestMethod]
        public void Ok_enMaestro()
        {
            // Preparar
            MR.EmptyMaestro();
            var regPwd = new RegistroPwd
            {
                UserNombre = "Peter Pan",
                Categoria = "Misteriosos",
                Producto = "1Password",
                UserId = "peter ustinov",
                UserPwd = "frase dificil",
                UserEMail = "peter@gmail.com"
            };
            RegistroPwd regPwdAdd = MR.CreateRegPwd(regPwd);
            regPwdAdd.UserId = "mario_bross";
            regPwdAdd.UserPwd = "la@clave*mas$secreta";

            // Ejecutar
            RegistroPwd regPwdUpd = MR.UpdateRegPwd(regPwdAdd); // == MR.UpdateRegPwd(regPwdAdd, enMaestro: true);

            // Probar
            Assert.IsNotNull(regPwdUpd);
            Assert.AreEqual(regPwdAdd.UserId, regPwdUpd.UserId);
            Assert.AreEqual(regPwdAdd.UserPwd, regPwdUpd.UserPwd);
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
            string rowPwdUpd = MR.UpdateRegPwd(rowPwd, enMaestro: false);

            // Probar
            Assert.IsNull(rowPwdUpd);
            Assert.IsTrue(MR.HayError);
            Assert.AreEqual($"Error: reg null, en ManejadorRegistros.RegistroPwdToRow!", MR.MensajeError);
        }

        [TestMethod]
        public void Row_nulo()
        {
            // Preparar
            string rowPwd = null;

            // Ejecutar
            string rowPwdUpd = MR.UpdateRegPwd(rowPwd, enMaestro: false);

            // Probar
            Assert.IsNull(rowPwdUpd);
            Assert.IsTrue(MR.HayError);
            Assert.AreEqual($"Error: reg null, en ManejadorRegistros.RegistroPwdToRow!", MR.MensajeError);
        }

        [TestMethod]
        public void Row_vacia()
        {
            // Preparar
            string rowPwd = "";

            // Ejecutar
            string rowPwdUpd = MR.UpdateRegPwd(rowPwd, enMaestro: false);

            // Probar
            Assert.IsNull(rowPwdUpd);
            Assert.IsTrue(MR.HayError);
            Assert.AreEqual($"Error: reg null, en ManejadorRegistros.RegistroPwdToRow!", MR.MensajeError);
        }

        [TestMethod]
        public void Row_ok()
        {
            // Preparar
            var regPwd = new RegistroPwd
            {
                UserNombre = "LAOSTRA",
                Categoria = "Tarjetas",
                Producto = "Visa",
                UserId = "luis alberto",
                UserPwd = "3433",
                UserEMail = "luis@gmail.com"
            };
            MR.ClearTableMaestro();
            var regPwdAdd = MR.CreateRegPwd(regPwd, enMaestro: false);
            regPwdAdd.UserId = "luis";
            regPwdAdd.UserPwd = "4523";
            string rowPwdAdd = MR.RegistroPwdToRow(regPwdAdd);


            // Ejecutar
            string rowPwdUpd = MR.UpdateRegPwd(rowPwdAdd, enMaestro: false);

            // Probar
            var regPwdUpd = MR.RowToRegistroPwd(rowPwdUpd);
            Assert.IsNotNull(rowPwdUpd);
            Assert.AreEqual(regPwdAdd.UserId, regPwdUpd.UserId);
            Assert.AreEqual(regPwdAdd.UserPwd, regPwdUpd.UserPwd);
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
                UserNombre = "Amelia",
                Categoria = "Kards",
                Producto = "MasterCard",
                UserId = "Amalia Cadena",
                UserPwd = "8835",
                UserEMail = "acadena@gmail.com"
            };
            var regPwdAdd = MR.CreateRegPwd(regPwd);
            regPwdAdd.UserId = "Amalita";
            regPwdAdd.UserPwd = "1476";
            string rowPwdAdd = MR.RegistroPwdToRow(regPwdAdd);

            // Ejecutar
            string rowPwdUpd = MR.UpdateRegPwd(rowPwdAdd); // == MR.UpdateRegPwd(rowPwdAdd, enMaestro: true);

            // Probar
            var regPwdUpd = MR.RowToRegistroPwd(rowPwdUpd);
            Assert.IsNotNull(rowPwdUpd);
            Assert.AreEqual(regPwdAdd.UserId, regPwdUpd.UserId);
            Assert.AreEqual(regPwdAdd.UserPwd, regPwdUpd.UserPwd);
            Assert.IsFalse(MR.HayError);
            Assert.AreEqual("", MR.MensajeError);
        }

        #endregion
    }

#region Footer
}
#endregion

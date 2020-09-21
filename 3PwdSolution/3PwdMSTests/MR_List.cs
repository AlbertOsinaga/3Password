#region Header

using Microsoft.VisualStudio.TestTools.UnitTesting;

using _3PwdLibrary;
using G = _3PwdLibrary.Global;
using MR = _3PwdLibrary.ManejadorRegistros;
using System.Collections.Generic;

namespace _3PwdMSTests
{

#endregion

    [TestClass]
    public class MR_List
    {
        [TestMethod]
        public void ListRegPwd_Ok()
        {
            // Preparar
            MR.ClearTableMaestro();
            var regPwdAdd1 = new RegistroPwd
            {
                Categoria = "Softa",
                Empresa = "Adobe",
                Producto = "Photosho",
                UserId = "lu_alberto",
                UserPwd = "illampu",
                UserEMail = "lu@gmail.com",
                UserNota = "Licencia 534535353"
            };
            MR.CreateRegPwd(regPwdAdd1, enMaestro: false);
            var regPwdAdd2 = new RegistroPwd
            {
                Categoria = "Softb",
                Empresa = "Adobe",
                Producto = "Photosho",
                UserId = "lu_alberto",
                UserPwd = "illampu",
                UserEMail = "lu@gmail.com",
                UserNota = "Licencia 534535353"
            };
            MR.CreateRegPwd(regPwdAdd2, enMaestro: false);
            var regPwdAdd3 = new RegistroPwd
            {
                Categoria = "Softc",
                Empresa = "Adobe",
                Producto = "Photosho",
                UserId = "lu_alberto",
                UserPwd = "illampu",
                UserEMail = "lu@gmail.com",
                UserNota = "Licencia 534535353"
            };
            MR.CreateRegPwd(regPwdAdd3, enMaestro: false);
            var regPwdAdd4 = new RegistroPwd
            {
                Categoria = "Softd",
                Empresa = "Adobe",
                Producto = "Photosho",
                UserId = "lu_alberto",
                UserPwd = "illampu",
                UserEMail = "lu@gmail.com",
                UserNota = "Licencia 534535353"
            };
            MR.CreateRegPwd(regPwdAdd4, enMaestro: false);

            // Ejecutar
            List<RegistroPwd> regsPwd = MR.ListRegsPwd(enMaestro: false) as List<RegistroPwd>;

            // Probar
            Assert.IsNotNull(regsPwd);
            Assert.IsFalse(MR.HayError);
            Assert.AreEqual("", MR.MensajeError);
            Assert.AreEqual(4, regsPwd.Count);
            Assert.IsTrue(regsPwd[0].ToString().Contains(regPwdAdd1.ToString()));
            Assert.IsTrue(regsPwd[1].ToString().Contains(regPwdAdd2.ToString()));
            Assert.IsTrue(regsPwd[2].ToString().Contains(regPwdAdd3.ToString()));
            Assert.IsTrue(regsPwd[3].ToString().Contains(regPwdAdd4.ToString()));
        }

        [TestMethod]
        public void ListRegPwd_Ok_enMaestro()
        {
            // Preparar
            MR.EmptyMaestro();
            var regPwdAdd1 = new RegistroPwd
            {
                Categoria = "ProgramasA",
                Empresa = "Adobe",
                Producto = "Photosho",
                UserId = "lu_alberto",
                UserPwd = "illampu",
                UserEMail = "lu@gmail.com",
                UserNota = "Licencia 534535353"
            };
            MR.CreateRegPwd(regPwdAdd1);
            var regPwdAdd2 = new RegistroPwd
            {
                Categoria = "ProgramasB",
                Empresa = "Adobe",
                Producto = "Photosho",
                UserId = "lu_alberto",
                UserPwd = "illampu",
                UserEMail = "lu@gmail.com",
                UserNota = "Licencia 534535353"
            };
            MR.CreateRegPwd(regPwdAdd2);
            var regPwdAdd3 = new RegistroPwd
            {
                Categoria = "ProgramasC",
                Empresa = "Adobe",
                Producto = "Photosho",
                UserId = "lu_alberto",
                UserPwd = "illampu",
                UserEMail = "lu@gmail.com",
                UserNota = "Licencia 534535353"
            };
            MR.CreateRegPwd(regPwdAdd3);
            var regPwdAdd4 = new RegistroPwd
            {
                Categoria = "ProgramasD",
                Empresa = "Adobe",
                Producto = "Photosho",
                UserId = "lu_alberto",
                UserPwd = "illampu",
                UserEMail = "lu@gmail.com",
                UserNota = "Licencia 534535353"
            };
            MR.CreateRegPwd(regPwdAdd4);

            // Ejecutar
            List<RegistroPwd> regsPwd = MR.ListRegsPwd() as List<RegistroPwd>;

            // Probar
            Assert.IsNotNull(regsPwd);
            Assert.IsFalse(MR.HayError);
            Assert.AreEqual("", MR.MensajeError);
            Assert.AreEqual(4, regsPwd.Count);
            Assert.IsTrue(regsPwd[0].ToString().Contains(regPwdAdd1.ToString()));
            Assert.IsTrue(regsPwd[1].ToString().Contains(regPwdAdd2.ToString()));
            Assert.IsTrue(regsPwd[2].ToString().Contains(regPwdAdd3.ToString()));
            Assert.IsTrue(regsPwd[3].ToString().Contains(regPwdAdd4.ToString()));
        }

        [TestMethod]
        public void ListRowsPwd_Ok()
        {
            // Preparar
            MR.ClearTableMaestro();
            var regPwdAdd1 = new RegistroPwd
            {
                Categoria = "Softwa",
                Empresa = "Adobe",
                Producto = "Photosho",
                UserId = "lu_alberto",
                UserPwd = "illampu",
                UserEMail = "lu@gmail.com",
                UserNota = "Licencia 534535353"
            };
            MR.CreateRegPwd(regPwdAdd1, enMaestro: false);
            var regPwdAdd2 = new RegistroPwd
            {
                Categoria = "Softwb",
                Empresa = "Adobe",
                Producto = "Photosho",
                UserId = "lu_alberto",
                UserPwd = "illampu",
                UserEMail = "lu@gmail.com",
                UserNota = "Licencia 534535353"
            };
            MR.CreateRegPwd(regPwdAdd2, enMaestro: false);
            var regPwdAdd3 = new RegistroPwd
            {
                Categoria = "Softwc",
                Empresa = "Adobe",
                Producto = "Photosho",
                UserId = "lu_alberto",
                UserPwd = "illampu",
                UserEMail = "lu@gmail.com",
                UserNota = "Licencia 534535353"
            };
            MR.CreateRegPwd(regPwdAdd3, enMaestro: false);
            var regPwdAdd4 = new RegistroPwd
            {
                Categoria = "Softwd",
                Empresa = "Adobe",
                Producto = "Photosho",
                UserId = "lu_alberto",
                UserPwd = "illampu",
                UserEMail = "lu@gmail.com",
                UserNota = "Licencia 534535353"
            };
            MR.CreateRegPwd(regPwdAdd4, enMaestro: false);

            // Ejecutar
            List<string> rowsPwd = MR.ListRowsPwd(enMaestro: false) as List<string>;

            // Probar
            Assert.IsNotNull(rowsPwd);
            Assert.IsFalse(MR.HayError);
            Assert.AreEqual("", MR.MensajeError);
            Assert.AreEqual(4, rowsPwd.Count);
            Assert.IsTrue(rowsPwd[0].Contains(regPwdAdd1.ToString()));
            Assert.IsTrue(rowsPwd[1].Contains(regPwdAdd2.ToString()));
            Assert.IsTrue(rowsPwd[2].Contains(regPwdAdd3.ToString()));
            Assert.IsTrue(rowsPwd[3].Contains(regPwdAdd4.ToString()));
        }

        [TestMethod]
        public void ListRowsPwd_Ok_enMaestro()
        {
            // Preparar
            MR.EmptyMaestro();
            var regPwdAdd1 = new RegistroPwd
            {
                Categoria = "SoftwareA",
                Empresa = "Adobe",
                Producto = "Photosho",
                UserId = "lu_alberto",
                UserPwd = "illampu",
                UserEMail = "lu@gmail.com",
                UserNota = "Licencia 534535353"
            };
            MR.CreateRegPwd(regPwdAdd1);
            var regPwdAdd2 = new RegistroPwd
            {
                Categoria = "SoftwareB",
                Empresa = "Adobe",
                Producto = "Photosho",
                UserId = "lu_alberto",
                UserPwd = "illampu",
                UserEMail = "lu@gmail.com",
                UserNota = "Licencia 534535353"
            };
            MR.CreateRegPwd(regPwdAdd2);
            var regPwdAdd3 = new RegistroPwd
            {
                Categoria = "SoftwareC",
                Empresa = "Adobe",
                Producto = "Photosho",
                UserId = "lu_alberto",
                UserPwd = "illampu",
                UserEMail = "lu@gmail.com",
                UserNota = "Licencia 534535353"
            };
            MR.CreateRegPwd(regPwdAdd3);
            var regPwdAdd4 = new RegistroPwd
            {
                Categoria = "SoftwareD",
                Empresa = "Adobe",
                Producto = "Photosho",
                UserId = "lu_alberto",
                UserPwd = "illampu",
                UserEMail = "lu@gmail.com",
                UserNota = "Licencia 534535353"
            };
            MR.CreateRegPwd(regPwdAdd4);

            // Ejecutar
            List<string> rowsPwd = MR.ListRowsPwd() as List<string>;

            // Probar
            Assert.IsNotNull(rowsPwd);
            Assert.IsFalse(MR.HayError);
            Assert.AreEqual("", MR.MensajeError);
            Assert.AreEqual(4, rowsPwd.Count);
            Assert.IsTrue(rowsPwd[0].Contains(regPwdAdd1.ToString()));
            Assert.IsTrue(rowsPwd[1].Contains(regPwdAdd2.ToString()));
            Assert.IsTrue(rowsPwd[2].Contains(regPwdAdd3.ToString()));
            Assert.IsTrue(rowsPwd[3].Contains(regPwdAdd4.ToString()));
        }

        [TestMethod]
        public void ListRowsPwdAsString_ListStrings_Ok()
        {
            // Preparar
            MR.ClearTableMaestro();
            var regPwdAdd1 = new RegistroPwd
            {
                Categoria = "Licsa",
                Empresa = "Adobe",
                Producto = "Photosho",
                UserId = "lu_alberto",
                UserPwd = "illampu",
                UserEMail = "lu@gmail.com",
                UserNota = "Licencia 534535353"
            };
            MR.CreateRegPwd(regPwdAdd1, enMaestro: false);
            var regPwdAdd2 = new RegistroPwd
            {
                Categoria = "Licsb",
                Empresa = "Adobe",
                Producto = "Photosho",
                UserId = "lu_alberto",
                UserPwd = "illampu",
                UserEMail = "lu@gmail.com",
                UserNota = "Licencia 534535353"
            };
            MR.CreateRegPwd(regPwdAdd2, enMaestro: false);
            var regPwdAdd3 = new RegistroPwd
            {
                Categoria = "Licsc",
                Empresa = "Adobe",
                Producto = "Photosho",
                UserId = "lu_alberto",
                UserPwd = "illampu",
                UserEMail = "lu@gmail.com",
                UserNota = "Licencia 534535353"
            };
            MR.CreateRegPwd(regPwdAdd3, enMaestro: false);
            var regPwdAdd4 = new RegistroPwd
            {
                Categoria = "LIcsd",
                Empresa = "Adobe",
                Producto = "Photosho",
                UserId = "lu_alberto",
                UserPwd = "illampu",
                UserEMail = "lu@gmail.com",
                UserNota = "Licencia 534535353"
            };
            MR.CreateRegPwd(regPwdAdd4, enMaestro: false);
            List<string> rowsPwd = MR.ListRowsPwd(enMaestro: false) as List<string>;

            // Ejecutar
            string texto = MR.ListRowsPwdAsString(rowsPwd);

            // Probar
            Assert.IsNotNull(texto);
            Assert.IsFalse(MR.HayError);
            Assert.AreEqual("", MR.MensajeError);
            Assert.IsTrue(texto.Contains(regPwdAdd1.ToString()));
            Assert.IsTrue(texto.Contains(regPwdAdd2.ToString()));
            Assert.IsTrue(texto.Contains(regPwdAdd3.ToString()));
            Assert.IsTrue(texto.Contains(regPwdAdd4.ToString()));
        }

        [TestMethod]
        public void ListRowsPwdAsString_ListStrings_Ok_enMaestro()
        {
            // Preparar
            MR.EmptyMaestro();
            var regPwdAdd1 = new RegistroPwd
            {
                Categoria = "Licesa",
                Empresa = "Adobe",
                Producto = "Photosho",
                UserId = "lu_alberto",
                UserPwd = "illampu",
                UserEMail = "lu@gmail.com",
                UserNota = "Licencia 534535353"
            };
            MR.CreateRegPwd(regPwdAdd1);
            var regPwdAdd2 = new RegistroPwd
            {
                Categoria = "Licesb",
                Empresa = "Adobe",
                Producto = "Photosho",
                UserId = "lu_alberto",
                UserPwd = "illampu",
                UserEMail = "lu@gmail.com",
                UserNota = "Licencia 534535353"
            };
            MR.CreateRegPwd(regPwdAdd2);
            var regPwdAdd3 = new RegistroPwd
            {
                Categoria = "Licesc",
                Empresa = "Adobe",
                Producto = "Photosho",
                UserId = "lu_alberto",
                UserPwd = "illampu",
                UserEMail = "lu@gmail.com",
                UserNota = "Licencia 534535353"
            };
            MR.CreateRegPwd(regPwdAdd3);
            var regPwdAdd4 = new RegistroPwd
            {
                Categoria = "LIcesd",
                Empresa = "Adobe",
                Producto = "Photosho",
                UserId = "lu_alberto",
                UserPwd = "illampu",
                UserEMail = "lu@gmail.com",
                UserNota = "Licencia 534535353"
            };
            MR.CreateRegPwd(regPwdAdd4);
            List<string> rowsPwd = MR.ListRowsPwd() as List<string>;

            // Ejecutar
            string texto = MR.ListRowsPwdAsString(rowsPwd);

            // Probar
            Assert.IsNotNull(texto);
            Assert.IsFalse(MR.HayError);
            Assert.AreEqual("", MR.MensajeError);
            Assert.IsTrue(texto.Contains(regPwdAdd1.ToString()));
            Assert.IsTrue(texto.Contains(regPwdAdd2.ToString()));
            Assert.IsTrue(texto.Contains(regPwdAdd3.ToString()));
            Assert.IsTrue(texto.Contains(regPwdAdd4.ToString()));
        }

        [TestMethod]
        public void ListRowsPwdAsString_Ok()
        {
            // Preparar
            MR.ClearTableMaestro();
            var regPwdAdd1 = new RegistroPwd
            {
                Categoria = "Licensa",
                Empresa = "Adobe",
                Producto = "Photosho",
                UserId = "lu_alberto",
                UserPwd = "illampu",
                UserEMail = "lu@gmail.com",
                UserNota = "Licencia 534535353"
            };
            MR.CreateRegPwd(regPwdAdd1, enMaestro: false);
            var regPwdAdd2 = new RegistroPwd
            {
                Categoria = "Licensb",
                Empresa = "Adobe",
                Producto = "Photosho",
                UserId = "lu_alberto",
                UserPwd = "illampu",
                UserEMail = "lu@gmail.com",
                UserNota = "Licencia 534535353"
            };
            MR.CreateRegPwd(regPwdAdd2, enMaestro: false);
            var regPwdAdd3 = new RegistroPwd
            {
                Categoria = "Licensc",
                Empresa = "Adobe",
                Producto = "Photosho",
                UserId = "lu_alberto",
                UserPwd = "illampu",
                UserEMail = "lu@gmail.com",
                UserNota = "Licencia 534535353"
            };
            MR.CreateRegPwd(regPwdAdd3, enMaestro: false);
            var regPwdAdd4 = new RegistroPwd
            {
                Categoria = "Licensd",
                Empresa = "Adobe",
                Producto = "Photosho",
                UserId = "lu_alberto",
                UserPwd = "illampu",
                UserEMail = "lu@gmail.com",
                UserNota = "Licencia 534535353"
            };
            MR.CreateRegPwd(regPwdAdd4, enMaestro: false);

            // Ejecutar
            string texto = MR.ListRowsPwdAsString(enMaestro: false);

            // Probar
            Assert.IsNotNull(texto);
            Assert.IsFalse(MR.HayError);
            Assert.AreEqual("", MR.MensajeError);
            Assert.IsTrue(texto.Contains(regPwdAdd1.ToString()));
            Assert.IsTrue(texto.Contains(regPwdAdd2.ToString()));
            Assert.IsTrue(texto.Contains(regPwdAdd3.ToString()));
            Assert.IsTrue(texto.Contains(regPwdAdd4.ToString()));
        }

        [TestMethod]
        public void ListRowsPwdAsString_Ok_enMaestro()
        {
            // Preparar
            MR.EmptyMaestro();
            var regPwdAdd1 = new RegistroPwd
            {
                Categoria = "Licenciasa",
                Empresa = "Adobe",
                Producto = "Photosho",
                UserId = "lu_alberto",
                UserPwd = "illampu",
                UserEMail = "lu@gmail.com",
                UserNota = "Licencia 534535353"
            };
            MR.CreateRegPwd(regPwdAdd1);
            var regPwdAdd2 = new RegistroPwd
            {
                Categoria = "Licenciasb",
                Empresa = "Adobe",
                Producto = "Photosho",
                UserId = "lu_alberto",
                UserPwd = "illampu",
                UserEMail = "lu@gmail.com",
                UserNota = "Licencia 534535353"
            };
            MR.CreateRegPwd(regPwdAdd2);
            var regPwdAdd3 = new RegistroPwd
            {
                Categoria = "Licenciasc",
                Empresa = "Adobe",
                Producto = "Photosho",
                UserId = "lu_alberto",
                UserPwd = "illampu",
                UserEMail = "lu@gmail.com",
                UserNota = "Licencia 534535353"
            };
            MR.CreateRegPwd(regPwdAdd3);
            var regPwdAdd4 = new RegistroPwd
            {
                Categoria = "Licenciasd",
                Empresa = "Adobe",
                Producto = "Photosho",
                UserId = "lu_alberto",
                UserPwd = "illampu",
                UserEMail = "lu@gmail.com",
                UserNota = "Licencia 534535353"
            };
            MR.CreateRegPwd(regPwdAdd4);

            // Ejecutar
            string texto = MR.ListRowsPwdAsString();

            // Probar
            Assert.IsNotNull(texto);
            Assert.IsFalse(MR.HayError);
            Assert.AreEqual("", MR.MensajeError);
            Assert.IsTrue(texto.Contains(regPwdAdd1.ToString()));
            Assert.IsTrue(texto.Contains(regPwdAdd2.ToString()));
            Assert.IsTrue(texto.Contains(regPwdAdd3.ToString()));
            Assert.IsTrue(texto.Contains(regPwdAdd4.ToString()));
        }
    }

    #region Footer
}
#endregion

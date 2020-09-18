#region Header
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using _3PwdLibrary;
using G = _3PwdLibrary.Global;
using MR = _3PwdLibrary.ManejadorRegistros;
using System.IO;

namespace _3PwdMSTests
{
#endregion

    [TestClass]
    public class MR_Varios
    {
        #region EmptyMaestro

        [TestMethod]
        public void EmptyMaestro_Ok()
        {
            // Prepara
            MR.DirMaestro = MR.DirMaestro_Default;
            MR.NameMaestro = MR.NameMaestro_Default;

            // Ejecuta
            bool ok = MR.EmptyMaestro();

            // Prueba
            Assert.IsTrue(ok);
            Assert.AreEqual(MR.StatusMaestro, MR.StatusWrited);
            Assert.IsFalse(MR.Updated);
            var texto = File.ReadAllText(MR.PathMaestro);
            Assert.AreEqual(MR.KeyMaestro, texto);
        }

        #endregion

        #region KeyOfRegistro

        [TestMethod]
        public void KeyOfRegistroPwd_conCamposNulos()
        {
            // Prepara
            RegistroPwd regPwd = new RegistroPwd();
            regPwd.Categoria = null;
            regPwd.Empresa = null;
            string keyEsperada = MR.KeyVacia;

            // Ejecuta
            string key = MR.KeyOfRegistroPwd(regPwd);

            // Prueba
            Assert.AreEqual(keyEsperada, key);
        }

        [TestMethod]
        public void KeyOfRegistroPwd_conCamposVacios()
        {
            // Prepara
            RegistroPwd regPwd = new RegistroPwd();
            regPwd.Categoria = "Software   ";
            regPwd.Empresa = "Microsoft    ";
            regPwd.Producto = "";
            regPwd.UserNombre = "Juana";
            string keyEsperada = "juana|software|microsoft|||";

            // Ejecuta
            string key = MR.KeyOfRegistroPwd(regPwd);

            // Prueba
            Assert.AreEqual(keyEsperada, key);
        }

        [TestMethod]
        public void KeyOfRegistroPwd_full()
        {
            // Prepara
            RegistroPwd regPwd = new RegistroPwd();
            regPwd.UserNombre = " Juan M  ";
            regPwd.Categoria = "Software   ";
            regPwd.Empresa = "Microsoft    ";
            regPwd.Producto = " OFFICE  ";
            string keyEsperada = "juan m|software|microsoft|office||";

            // Ejecuta
            string key = MR.KeyOfRegistroPwd(regPwd);

            // Prueba
            Assert.AreEqual(keyEsperada, key);
        }

        [TestMethod]
        public void KeyOfRegistroPwd_regNulo()
        {
            // Prepara
            string keyEsperada = G.RegNull;

            // Ejecuta
            string key = MR.KeyOfRegistroPwd(null);

            // Prueba
            Assert.AreEqual(keyEsperada, key);
        }

        #endregion

        #region ReadMaestro

        [TestMethod]
        public void ReadMaestro_blanco()
        {
            // Prepara
            MR.DirMaestro = string.Empty;
            MR.NameMaestro = string.Empty;

            // Ejecuta
            MR.StatusMaestro = MR.StatusWrited;
            bool readedOk = MR.ReadMaestro();
            MR.DirMaestro = MR.DirMaestro_Default;
            MR.NameMaestro = MR.NameMaestro_Default;

            // Prueba
            Assert.IsFalse(readedOk);
            Assert.IsTrue(MR.HayError);
            Assert.AreEqual("Nombre de archivo Maestro en blanco!", MR.MensajeError);
        }

        [TestMethod]
        public void ReadMaestro_noExiste()
        {
            // Prepara
            MR.NameMaestro = "_MasterFileNoExiste";
            if(File.Exists(MR.PathMaestro))
                File.Delete(MR.PathMaestro);

            // Ejecuta
            bool readedOk = MR.ReadMaestro();

            // Prueba
            Assert.IsFalse(readedOk);
            Assert.IsTrue(MR.HayError);
            Assert.AreEqual($"Archivo Maestro '{MR.PathMaestro}' no existe!", MR.MensajeError);
            MR.NameMaestro = MR.NameMaestro_Default;
        }

        [TestMethod]
        public void ReadMaestro_nulo()
        {
            // Prepara
            MR.PathMaestro = null;

            // Ejecuta
            bool readedOk = MR.ReadMaestro();
            MR.NameMaestro = MR.NameMaestro_Default;

            // Prueba
            Assert.IsFalse(readedOk);
            Assert.IsTrue(MR.HayError);
            Assert.AreEqual("Nombre de archivo Maestro nulo!", MR.MensajeError);
        }

        [TestMethod]
        public void ReadMaestro_ok()
        {
            // Prepara
            var key1 = "laos|software|google|cuenta|1234|";
            var key2 = "mickey|software|google|cuenta||";
            var key3 = "laos|software|microsoft|cuenta|9876|";
            var key4 = "|software|adobe|readers||";
            var rowEsperada1 = "LAOS|Software|Google|Cuenta|1234|www.google.com|luis.osinaga@gmail.com|password|||0001/01/01 00:00:00|0001/01/01 00:00:00|";
            var rowEsperada2 = "Mickey|Software|Google|Cuenta||www.google.com|luis.osinaga@gmail.com|password|||0001/01/01 00:00:00|0001/01/01 00:00:00|";
            var rowEsperada3 = "LAOS|Software|Microsoft|Cuenta|9876|www.microsoft.com|luis.osinaga@gmail.com|password|||0001/01/01 00:00:00|0001/01/01 00:00:00|";
            var rowEsperada4 = "|Software|Adobe|Readers||www.adobe.com|luisalberto|clave|||2019/03/12 10:15:20|2020/08/13 16:49:10|";
            MR.EmptyMaestro();
            MR.NameMaestro = "_MasterFile_Ok";

            // Ejecuta
            bool readedOk = MR.ReadMaestro();

            // Prueba
            MR.NameMaestro = MR.NameMaestro_Default;
            Assert.IsTrue(readedOk);
            Assert.IsFalse(MR.HayError);
            Assert.AreEqual("", MR.MensajeError);
            var regPwd = MR.TableMaestro[key1];
            Assert.IsTrue(MR.RegistroPwdToRow(regPwd).Contains(rowEsperada1));
            regPwd = MR.TableMaestro[key2];
            Assert.IsTrue(MR.RegistroPwdToRow(regPwd).Contains(rowEsperada2));
            regPwd = MR.TableMaestro[key3];
            Assert.IsTrue(MR.RegistroPwdToRow(regPwd).Contains(rowEsperada3));
            regPwd = MR.TableMaestro[key4];
            Assert.IsTrue(MR.RegistroPwdToRow(regPwd).Contains(rowEsperada4));
        }

        [TestMethod]
        public void ReadMaestro_vacio()
        {
            // Prepara
            MR.EmptyMaestro();
            MR.NameMaestro = "_MasterFileEmpty";

            // Ejecuta
            bool readedOk = MR.ReadMaestro();

            // Prueba
            MR.NameMaestro = MR.NameMaestro_Default;
            Assert.IsTrue(readedOk);
            Assert.IsFalse(MR.HayError);
            Assert.AreEqual(string.Empty, MR.MensajeError);
        }

        #endregion

        #region RegistroPwdToRow

        [TestMethod]
        public void RegistroPwdToRow_camposConNulos()
        {
            // Prepara
            RegistroPwd regPwd = new RegistroPwd();
            regPwd.UserNombre = "LAOSS";
            regPwd.Categoria = "Software";
            regPwd.Empresa = "Google";
            regPwd.Producto = "Cuenta";
            regPwd.Numero = "1234567";
            regPwd.Web = "www.google.com";
            regPwd.UserId = "luis.osinaga@gmail.com";
            regPwd.UserPwd = "password";
            regPwd.UserEMail = null;
            regPwd.UserNota = null;
            regPwd.CreateDate = new DateTime(2019, 03, 12, 10, 15, 20);
            regPwd.UpdateDate = new DateTime(2020, 08, 13, 16, 49, 10);
            regPwd.RegId = "100";
            string rowEsperada = "LAOSS|Software|Google|Cuenta|1234567|www.google.com|luis.osinaga@gmail.com|password|||2019/03/12 10:15:20|2020/08/13 16:49:10";

            // Ejecuta
            string row = MR.RegistroPwdToRow(regPwd);

            // Prueba
            Assert.IsTrue(row.Contains(rowEsperada));
            Assert.IsFalse(MR.HayError);
            Assert.AreEqual("", MR.MensajeError);
        }

        [TestMethod]
        public void RegistroPwdToRow_camposNoInicializados()
        {
            // Prepara
            RegistroPwd regPwd = new RegistroPwd();
            string rowEsperada = "||||||||||0001/01/01 00:00:00|0001/01/01 00:00:00||";

            // Ejecuta
            string row = MR.RegistroPwdToRow(regPwd);

            // Prueba
            Assert.AreEqual(rowEsperada, row);
            Assert.IsFalse(MR.HayError);
            Assert.AreEqual("", MR.MensajeError);
        }

        [TestMethod]
        public void RegistroPwdToRow_camposOk()
        {
            // Prepara
            RegistroPwd regPwd = new RegistroPwd();
            regPwd.UserNombre = "LLAOS";
            regPwd.Categoria = "Software";
            regPwd.Empresa = "Google";
            regPwd.Producto = "Cuenta";
            regPwd.Numero = "333444";
            regPwd.Web = "www.google.com";
            regPwd.UserId = "luis.osinaga@gmail.com";
            regPwd.UserPwd = "password";
            regPwd.UserEMail = "";
            regPwd.UserNota = "";
            regPwd.CreateDate = new DateTime(2019, 03, 12, 10, 15, 20);
            regPwd.UpdateDate = new DateTime(2020, 08, 13, 16, 49, 10);
            regPwd.RegId = "0";
            string rowEsperada = "LLAOS|Software|Google|Cuenta|333444|www.google.com|luis.osinaga@gmail.com|password|||2019/03/12 10:15:20|2020/08/13 16:49:10";

            // Ejecuta
            string row = MR.RegistroPwdToRow(regPwd);

            // Prueba
            Assert.IsTrue(row.Contains(rowEsperada));
            Assert.IsFalse(MR.HayError);
            Assert.AreEqual("", MR.MensajeError);
        }

        [TestMethod]
        public void RegistroPwdToRow_regPwdNulo()
        {
            // Prepara

            // Ejecuta
            string row = MR.RegistroPwdToRow(null);

            // Prueba
            Assert.IsNull(row);
            Assert.IsTrue(MR.HayError);
            Assert.AreEqual("Error: reg null, en ManejadorRegistros.RegistroPwdToRow!", MR.MensajeError);
        }

        #endregion

        #region RowsToTable

        [TestMethod]
        public void RowsToTable_rowsNoRow()
        {
            // Prepara
            var rows = new string[] { };
            var mensajeEsperado = "Error: rows sin registros, en ManejadorRegistros.RowsToTable!";

            // Ejecuta
            bool resultOk = MR.RowsToTable(rows);

            // Prueba
            Assert.IsFalse(resultOk);
            Assert.IsTrue(MR.HayError);
            Assert.AreEqual(mensajeEsperado, MR.MensajeError);
        }

        [TestMethod]
        public void RowsToTable_rowsNull()
        {
            // Prepara
            var mensajeEsperado = "Error: rows null, en ManejadorRegistros.RowsToTable!";

            // Ejecuta
            bool resultOk = MR.RowsToTable(null);

            // Prueba
            Assert.IsFalse(resultOk);
            Assert.IsTrue(MR.HayError);
            Assert.AreEqual(mensajeEsperado, MR.MensajeError);
        }

        [TestMethod]
        public void RowsToTable_rowsOk()
        {
            // Prepara
            var rows = new string[]
                { $"{MR.KeyMaestro}",
                          "LAOS|Software|Google|Cuenta||www.google.com|luis.osinaga@gmail.com|password|||2019/03/12 10:15:20|2020/08/13 16:49:10|",
                          "Mickey|Software|Google|Cuenta||www.google.com|luis.osinaga@gmail.com|password|||||",
                          "LAOS|Software|Microsoft|Cuenta||www.microsoft.com|luis.osinaga@gmail.com|password|||||",
                          "|Software|Adobe|Readers||www.adobe.com|luisalberto|clave|||2019/03/12 10:15:20|2020/08/13 16:49:10|"
                };
            var key1 = "laos|software|google|cuenta||";
            var key2 = "mickey|software|google|cuenta||";
            var key3 = "laos|software|microsoft|cuenta||";
            var key4 = "|software|adobe|readers||";
            var rowEsperada1 = "LAOS|Software|Google|Cuenta||www.google.com|luis.osinaga@gmail.com|password|||2019/03/12 10:15:20|2020/08/13 16:49:10|";
            var rowEsperada2 = "Mickey|Software|Google|Cuenta||www.google.com|luis.osinaga@gmail.com|password|||0001/01/01 00:00:00|0001/01/01 00:00:00|";
            var rowEsperada3 = "LAOS|Software|Microsoft|Cuenta||www.microsoft.com|luis.osinaga@gmail.com|password|||0001/01/01 00:00:00|0001/01/01 00:00:00|";
            var rowEsperada4 = "|Software|Adobe|Readers||www.adobe.com|luisalberto|clave|||2019/03/12 10:15:20|2020/08/13 16:49:10|";

            // Ejecuta
            bool resultOk = MR.RowsToTable(rows);

            // Prueba
            Assert.IsTrue(resultOk);
            Assert.IsFalse(MR.HayError);
            Assert.AreEqual("", MR.MensajeError);
            Assert.AreEqual(4, MR.TableMaestro.Count);
            var regPwd = MR.TableMaestro[key1];
            Assert.IsTrue(MR.RegistroPwdToRow(regPwd).Contains(rowEsperada1));
            regPwd = MR.TableMaestro[key2];
            Assert.IsTrue(MR.RegistroPwdToRow(regPwd).Contains(rowEsperada2));
            regPwd = MR.TableMaestro[key3];
            Assert.IsTrue(MR.RegistroPwdToRow(regPwd).Contains(rowEsperada3));
            regPwd = MR.TableMaestro[key4];
            Assert.IsTrue(MR.RegistroPwdToRow(regPwd).Contains(rowEsperada4));
        }

        [TestMethod]
        public void RowsToTable_rowsVacias()
        {
            // Prepara
            MR.ClearTableMaestro();
            var rows = new string[]
                { $"{MR.KeyMaestro}",
                          "",
                          "",
                          "",
                          "",
                          ""
                };

            // Ejecuta
            bool resultOk = MR.RowsToTable(rows);

            // Prueba
            Assert.IsTrue(resultOk);
            Assert.IsTrue(MR.TableMaestro.Count == 0);
            Assert.IsFalse(MR.HayError);
            Assert.AreEqual("", MR.MensajeError);
        }

        #endregion

        #region RowToRegistroPwd

        [TestMethod]
        public void RowToRegistroPwd_camposOk()
        {
            // Prepara
            string rowEsperada = "LAOS|Software|Google|Cuenta||www.google.com|luis.osinaga@gmail.com|password|||2019/03/12 10:15:20|2020/08/13 16:04:00";

            // Ejecuta
            RegistroPwd regPwd = MR.RowToRegistroPwd(rowEsperada);
            bool hayError = MR.HayError;
            bool isEmpty = (MR.MensajeError == string.Empty);

            // Prueba
            string row = MR.RegistroPwdToRow(regPwd);
            Assert.IsTrue(row.Contains(rowEsperada));
            Assert.IsFalse(hayError);
            Assert.IsTrue(isEmpty);
        }

        [TestMethod]
        public void RowToRegistroPwd_camposIncompletos()
        {
            // Prepara
            string rowIn = "|||||||";
            string rowEsperada = "||||||||||0001/01/01 00:00:00|0001/01/01 00:00:00||";

            // Ejecuta
            RegistroPwd regPwd = MR.RowToRegistroPwd(rowIn);
            bool hayError = MR.HayError;
            bool isEmpty = MR.MensajeError == string.Empty;

            // Prueba
            string row = MR.RegistroPwdToRow(regPwd);
            Assert.AreEqual(rowEsperada, row);
            Assert.IsFalse(hayError);
            Assert.IsTrue(isEmpty);
        }

        [TestMethod]
        public void RowToRegistroPwd_camposVacios()
        {
            // Prepara
            string rowIn = "||||||||||";
            string rowEsperada = "||||||||||0001/01/01 00:00:00|0001/01/01 00:00:00||";

            // Ejecuta
            RegistroPwd regPwd = MR.RowToRegistroPwd(rowIn);
            bool hayError = MR.HayError;
            bool isEmpty = MR.MensajeError == string.Empty;

            // Prueba
            string row = MR.RegistroPwdToRow(regPwd);
            Assert.AreEqual(rowEsperada, row);
            Assert.IsFalse(hayError);
            Assert.IsTrue(isEmpty);
        }

        #endregion

        #region TableToRows

        [TestMethod]
        public void TableToRows_regsOk()
        {
            // Prepara
            MR.TableMaestro.Clear();
            RegistroPwd regPwd1 = new RegistroPwd
            {
                Categoria = "Soft",
                Producto = "Doodly",
                UserId = "Albertosky",
                UserPwd = "infinitamente"
            };
            RegistroPwd regPwd2 = new RegistroPwd
            {
                Categoria = "Card",
                Producto = "Mastercard",
                UserId = "",
                UserPwd = "5323"
            };
            var rowEsperada1 = "|Soft||Doodly|||Albertosky|infinitamente|||0001/01/01 00:00:00|0001/01/01 00:00:00|";
            var rowEsperada2 = "|Card||Mastercard||||5323|||0001/01/01 00:00:00|0001/01/01 00:00:00|";
            MR.TableMaestro[MR.KeyOfRegistroPwd(regPwd1)] = regPwd1;
            MR.TableMaestro[MR.KeyOfRegistroPwd(regPwd2)] = regPwd2;

            // Ejecuta
            var rows = MR.TableToRows();

            // Prueba
            Assert.IsFalse(MR.HayError);
            Assert.AreEqual("", MR.MensajeError);
            Assert.IsTrue(MR.RegistroPwdToRow(MR.TableMaestro[MR.KeyOfRegistroPwd(regPwd1)]).Contains(rowEsperada1));
            Assert.IsTrue(MR.RegistroPwdToRow(MR.TableMaestro[MR.KeyOfRegistroPwd(regPwd2)]).Contains(rowEsperada2));
        }

        #endregion

        #region WriteMaestro

        [TestMethod]
        public void WriteMaestro_Ok()
        {
            // Prepara
            var vaciadoMaestroOk = MR.EmptyMaestro();
            Assert.IsTrue(vaciadoMaestroOk);
            bool readedMaestroOk = MR.ReadMaestro();
            Assert.IsTrue(readedMaestroOk);

            // Ejecuta
            bool writeOk = MR.WriteMaestro();

            // Prueba
            Assert.IsTrue(writeOk);
            Assert.IsFalse(MR.HayError);
            Assert.AreEqual("", MR.MensajeError);
        }

        [TestMethod]
        public void WriteMaestro_vacio()
        {
            // Prepara
            var vaciadoMaestroOk = MR.EmptyMaestro();
            Assert.IsTrue(vaciadoMaestroOk);
            var readedMaestroOk = MR.ReadMaestro();
            Assert.IsTrue(readedMaestroOk);

            // Ejecuta
            bool writeOk = MR.WriteMaestro();

            // Prueba
            Assert.IsTrue(writeOk);
            Assert.IsFalse(MR.HayError);
            Assert.AreEqual("", MR.MensajeError);
        }

        [TestMethod]
        public void WriteMaestro_writed()
        {
            // Nota:
            // El archivo Maestro solo puede escribirse una sola vez despues de leido.
            // Para volver a escribirse, debe ser primero leido.

            // Prepara
            MR.StatusMaestro = MR.StatusWrited;

            // Ejecuta
            bool okWrited = MR.WriteMaestro();

            // Prueba
            Assert.IsFalse(okWrited);
            Assert.IsTrue(MR.HayError);
            Assert.AreEqual("Maestro no leido o ya escrito con anterioridad!", MR.MensajeError);
        }

        #endregion
    }

#region Footer
}
#endregion

#region Header

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

using _3PwdLibrary;
using Cr = _3PwdLibrary.Cryptador;
using System.Security.Cryptography;

namespace _3PwdMSTests
{

#endregion

    [TestClass]
    public class Cr_Encrypt
    {
        [TestMethod]
        public void IVNulo()
        {
            // Prepara
            string texto = "abc";
            byte[] key = new byte[] { 1, 2, 3 };
            byte[] iv = null;

            // Ejecuta
            var result = Cr.Encrypt(texto, key, iv);

            // Prueba
            Assert.IsTrue(result.hayError);
            Assert.AreEqual("*** Error(Cryptador.Encrypt): IV nulo o vacio! ***", result.mensajeError);
        }

        [TestMethod]
        public void IVSizeInvalido()
        {
            // Prepara
            string texto = "abc";
            byte[] key = (new AesManaged()).Key;
            byte[] iv = new byte[] { 4, 5, 6 };

            // Ejecuta
            var resultEncrypt = Cr.Encrypt(texto, key, iv);

            // Prueba
            Assert.IsTrue(resultEncrypt.hayError);
            Assert.AreEqual(@"Excepcion en metodo Cryptador.Encrypt en archivo 'C:\Work\3Password\3PwdSolution\3PwdLibrary\Cryptador.cs', linea # 126: 'CryptographicException' - 'Specified initialization vector (IV) does not match the block size for this algorithm.'", resultEncrypt.mensajeError);
        }

        [TestMethod]
        public void IVVacio()
        {
            // Prepara
            string texto = "abc";
            byte[] key = new byte[] { 1, 2, 3 };
            byte[] iv = new byte[] { };

            // Ejecuta
            var result = Cr.Encrypt(texto, key, iv);

            // Prueba
            Assert.IsTrue(result.hayError);
            Assert.AreEqual("*** Error(Cryptador.Encrypt): IV nulo o vacio! ***", result.mensajeError);
        }

        [TestMethod]
        public void KeyNula()
        {
            // Prepara
            string texto = "abc";
            byte[] key = null;
            byte[] iv = null;

            // Ejecuta
            var result = Cr.Encrypt(texto, key, iv);

            // Prueba
            Assert.IsTrue(result.hayError);
            Assert.AreEqual("*** Error(Cryptador.Encrypt): Key nula o vacia! ***", result.mensajeError);
        }

        [TestMethod]
        public void KeySizeInvalido()
        {
            // Prepara
            string texto = "abc";
            byte[] key = new byte[] { 1, 2, 3 };
            byte[] iv = new byte[] { 4, 5, 6 };

            // Ejecuta
            var resultEncrypt = Cr.Encrypt(texto, key, iv);

            // Prueba
            Assert.IsTrue(resultEncrypt.hayError);
            Assert.AreEqual(@"Excepcion en metodo Cryptador.Encrypt en archivo 'C:\Work\3Password\3PwdSolution\3PwdLibrary\Cryptador.cs', linea # 125: 'CryptographicException' - 'Specified key is not a valid size for this algorithm.'", resultEncrypt.mensajeError);
        }

        [TestMethod]
        public void KeyVacia()
        {
            // Prepara
            string texto = "abc";
            byte[] key = new byte[] {};
            byte[] iv = null;

            // Ejecuta
            var result = Cr.Encrypt(texto, key, iv);

            // Prueba
            Assert.IsTrue(result.hayError);
            Assert.AreEqual("*** Error(Cryptador.Encrypt): Key nula o vacia! ***", result.mensajeError);
        }

        [TestMethod]
        public void Ok()
        {
            // Prepara
            string texto = "abc";
            byte[] key = (new AesManaged()).Key;
            byte[] iv = (new AesManaged()).IV;

            // Ejecuta
            var resultEncrypt = Cr.Encrypt(texto, key, iv);

            // Prueba
            Assert.IsFalse(resultEncrypt.hayError);
            Assert.AreEqual("", resultEncrypt.mensajeError);
            var resultDecrypt = Cr.Decrypt(resultEncrypt.encriptado, key, iv);
            Assert.AreEqual(texto, resultDecrypt.texto);
        }

        [TestMethod]
        public void Ok_MasterFile()
        {
            // Prepara
            var masterFile = @"C:\Work\3Password\3PwdSolution\3PwdMSTests\_MasterFile";
            var masterFileEncrypted = @"C:\Work\3Password\3PwdSolution\3PwdMSTests\_MasterFile.bin";
            string texto = File.ReadAllText(masterFile);
            byte[] key = (new AesManaged()).Key;
            byte[] iv = (new AesManaged()).IV;

            // Ejecuta
            var resultEncrypt = Cr.Encrypt(texto, key, iv);

            // Prueba
            Assert.IsFalse(resultEncrypt.hayError);
            Assert.AreEqual("", resultEncrypt.mensajeError);
            File.WriteAllBytes(masterFileEncrypted, resultEncrypt.encriptado);
            var resultDecrypt = Cr.Decrypt(resultEncrypt.encriptado, key, iv);
            Assert.AreEqual(texto, resultDecrypt.texto);
        }

        [TestMethod]
        public void TextoNulo()
        {
            // Prepara
            string texto = null;
            byte[] key = null;
            byte[] iv = null;

            // Ejecuta
            var result = Cr.Encrypt(texto, key, iv);

            // Prueba
            Assert.IsTrue(result.hayError);
            Assert.AreEqual("*** Error(Cryptador.Encrypt): Texto nulo o vacio! ***", result.mensajeError);
        }

        [TestMethod]
        public void TextoVacio()
        {
            // Prepara
            string texto = "";
            byte[] key = null;
            byte[] iv = null;

            // Ejecuta
            var result = Cr.Encrypt(texto, key, iv);

            // Prueba
            Assert.IsTrue(result.hayError);
            Assert.AreEqual("*** Error(Cryptador.Encrypt): Texto nulo o vacio! ***", result.mensajeError);
        }
    }

    #region Footer
}
#endregion

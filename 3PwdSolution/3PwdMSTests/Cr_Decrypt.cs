#region Header

using Microsoft.VisualStudio.TestTools.UnitTesting;

using _3PwdLibrary;
using Cr = _3PwdLibrary.Cryptador;
using System.Security.Cryptography;

namespace _3PwdMSTests
{

#endregion

    [TestClass]
    public class Cr_Decrypt
    {
        [TestMethod]
        public void IVNulo()
        {
            // Prepara
            byte[] encriptado = new byte[] {4, 5, 6};
            byte[] key = new byte[] { 1, 2, 3 };
            byte[] iv = null;

            // Ejecuta
            var result = Cr.Decrypt(encriptado, key, iv);

            // Prueba
            Assert.IsTrue(result.hayError);
            Assert.AreEqual("*** Error(Cryptador.Decrypt): IV nulo o vacio! ***", result.mensajeError);
        }

        [TestMethod]
        public void IVSizeInvalido()
        {
            // Prepara
            byte[] encriptado = new byte[] {1, 2, 3 };
            byte[] key = (new AesManaged()).Key;
            byte[] iv = new byte[] { 4, 5, 6 };

            // Ejecuta
            var resultEncrypt = Cr.Decrypt(encriptado, key, iv);

            // Prueba
            Assert.IsTrue(resultEncrypt.hayError);
            Assert.AreEqual(@"Excepcion en metodo Cryptador.Decrypt en archivo 'C:\Work\3Password\3PwdSolution\3PwdLibrary\Cryptador.cs', linea # 58: 'CryptographicException' - 'Specified initialization vector (IV) does not match the block size for this algorithm.'", resultEncrypt.mensajeError);
        }

        [TestMethod]
        public void IVVacio()
        {
            // Prepara
            byte[] encriptado = new byte[] {4, 5, 6};
            byte[] key = new byte[] { 1, 2, 3 };
            byte[] iv = new byte[] { };

            // Ejecuta
            var result = Cr.Decrypt(encriptado, key, iv);

            // Prueba
            Assert.IsTrue(result.hayError);
            Assert.AreEqual("*** Error(Cryptador.Decrypt): IV nulo o vacio! ***", result.mensajeError);
        }

        [TestMethod]
        public void KeyNula()
        {
            // Prepara
            byte[] encriptado = new byte[] {1, 2, 3};
            byte[] key = null;
            byte[] iv = null;

            // Ejecuta
            var result = Cr.Decrypt(encriptado, key, iv);

            // Prueba
            Assert.IsTrue(result.hayError);
            Assert.AreEqual("*** Error(Cryptador.Decrypt): Key nula o vacia! ***", result.mensajeError);
        }

        [TestMethod]
        public void KeySizeInvalido()
        {
            // Prepara
            byte[] encriptado = new byte[] {4, 5, 6};
            byte[] key = new byte[] { 1, 2, 3 };
            byte[] iv = new byte[] { 4, 5, 6 };

            // Ejecuta
            var resultEncrypt = Cr.Decrypt(encriptado, key, iv);

            // Prueba
            Assert.IsTrue(resultEncrypt.hayError);
            Assert.AreEqual(@"Excepcion en metodo Cryptador.Decrypt en archivo 'C:\Work\3Password\3PwdSolution\3PwdLibrary\Cryptador.cs', linea # 57: 'CryptographicException' - 'Specified key is not a valid size for this algorithm.'", resultEncrypt.mensajeError);
        }

        [TestMethod]
        public void KeyVacia()
        {
            // Prepara
            byte[] encriptado = new byte[] {1, 2, 3};
            byte[] key = new byte[] {};
            byte[] iv = null;

            // Ejecuta
            var result = Cr.Decrypt(encriptado, key, iv);

            // Prueba
            Assert.IsTrue(result.hayError);
            Assert.AreEqual("*** Error(Cryptador.Decrypt): Key nula o vacia! ***", result.mensajeError);
        }

        [TestMethod]
        public void Ok()
        {
            // Prepara
            string texto = "abc";
            byte[] key = (new AesManaged()).Key;
            byte[] iv = (new AesManaged()).IV;
            var resultEncrypt = Cr.Encrypt(texto, key, iv);
            var encriptado = resultEncrypt.encriptado;

            // Ejecuta
            var resultDecrypt = Cr.Decrypt(encriptado, key, iv);

            // Prueba
            Assert.IsFalse(resultEncrypt.hayError);
            Assert.AreEqual("", resultEncrypt.mensajeError);
            Assert.AreEqual(texto, resultDecrypt.texto);
        }

        [TestMethod]
        public void TextoEncriptadoNulo()
        {
            // Prepara
            byte[] encriptado = null;
            byte[] key = null;
            byte[] iv = null;

            // Ejecuta
            var result = Cr.Decrypt(encriptado, key, iv);

            // Prueba
            Assert.IsTrue(result.hayError);
            Assert.AreEqual("*** Error(Cryptador.Decrypt): TextoEncriptado nulo o vacio! ***", result.mensajeError);
        }

        [TestMethod]
        public void TextoVacio()
        {
            // Prepara
            byte[] encriptado = new byte[] {};
            byte[] key = null;
            byte[] iv = null;

            // Ejecuta
            var result = Cr.Decrypt(encriptado, key, iv);

            // Prueba
            Assert.IsTrue(result.hayError);
            Assert.AreEqual("*** Error(Cryptador.Decrypt): TextoEncriptado nulo o vacio! ***", result.mensajeError);
        }
    }

    #region Footer
}
#endregion

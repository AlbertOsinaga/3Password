using System;
using System.IO;
using System.Security.Cryptography;

using G = _3PwdLibrary.Global;
using Cr = _3PwdLibrary.Cryptador;

namespace _3PwdLibrary
{
    public static class Cryptador
    {
        #region Propiedades

        public static bool HayError;
        public static string MensajeError;

        #endregion

        #region Metodos

        public static (string texto, bool hayError, string mensajeError)
            Decrypt(byte[] textoEncriptado, byte[] key, byte[] IV)
        {
            InitMetodo();

            // Main return;
            var texto = "";

            // Check arguments.
            if (textoEncriptado == null || textoEncriptado.Length <= 0)
            {
                Cr.MensajeError = $"*** Error({nameof(Cryptador)}.{nameof(Decrypt)}): TextoEncriptado nulo o vacio! ***";
                Cr.HayError = true;
                return (texto, Cr.HayError, Cr.MensajeError);
            }

            if (key == null || key.Length <= 0)
            {
                Cr.MensajeError = $"*** Error({nameof(Cryptador)}.{nameof(Decrypt)}): Key nula o vacia! ***";
                Cr.HayError = true;
                return (texto, Cr.HayError, Cr.MensajeError);
            }

            if (IV == null || IV.Length <= 0)
            {
                Cr.MensajeError = $"*** Error({nameof(Cryptador)}.{nameof(Decrypt)}): IV nulo o vacio! ***";
                Cr.HayError = true;
                return (texto, Cr.HayError, Cr.MensajeError);
            }

            try
            {
                // Create an AesManaged object
                // with the specified key and IV.
                using (AesManaged aesAlg = new AesManaged())
                {
                    aesAlg.Key = key;
                    aesAlg.IV = IV;

                    // Create a decryptor to perform the stream transform.
                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                    // Create the streams used for decryption.
                    using (MemoryStream msDecrypt = new MemoryStream(textoEncriptado))
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor,
                            CryptoStreamMode.Read))
                        {
                            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                            {
                                // Read the decrypted bytes from the decrypting stream
                                // and place them in a string.
                                texto = srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }

                return (texto, Cr.HayError, Cr.MensajeError);
            }
            catch (Exception ex)
            {
                Cr.HayError = true;
                Cr.MensajeError = G.ArmaMensajeError($"Excepcion en metodo {nameof(Cryptador)}.{nameof(Decrypt)}", ex);
                return (texto, Cr.HayError, Cr.MensajeError);
            }
        }
        
        public static (byte[] encriptado, bool hayError, string mensajeError) 
            Encrypt(string texto, byte[] key, byte[] IV)
        {
            Cr.InitMetodo();

            // main return
            var textoEncriptado = new byte[] {};

            // Check arguments
            if (string.IsNullOrWhiteSpace(texto))
            {
                Cr.MensajeError = $"*** Error({nameof(Cryptador)}.{nameof(Encrypt)}): Texto nulo o vacio! ***";
                Cr.HayError = true;
                return (textoEncriptado, Cr.HayError, Cr.MensajeError);
            }

            if (key == null || key.Length <= 0)
            {
                Cr.MensajeError = $"*** Error({nameof(Cryptador)}.{nameof(Encrypt)}): Key nula o vacia! ***";
                Cr.HayError = true;
                return (textoEncriptado, Cr.HayError, Cr.MensajeError);
            }

            if (IV == null || IV.Length <= 0)
            {
                Cr.MensajeError = $"*** Error({nameof(Cryptador)}.{nameof(Encrypt)}): IV nulo o vacio! ***";
                Cr.HayError = true;
                return (textoEncriptado, Cr.HayError, Cr.MensajeError);
            }

            // Create an AesManaged object
            // with the specified key and IV.
            try
            {
                using (AesManaged aesAlg = new AesManaged())
                {
                    aesAlg.Key = key;
                    aesAlg.IV = IV;

                    // Create an encryptor to perform the stream transform.
                    ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                    // Create the streams used for encryption.
                    using (MemoryStream msEncrypt = new MemoryStream())
                    {
                        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor,
                                        CryptoStreamMode.Write))
                        {
                            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                            {
                                //Write all data to the stream.
                                swEncrypt.Write(texto);
                            }
                            textoEncriptado = msEncrypt.ToArray();
                        }
                    }
                }

                // Return the encrypted bytes from the memory stream.
                return (textoEncriptado, Cr.HayError, Cr.MensajeError);
            }
            catch (Exception ex)
            {
                Cr.HayError = true;
                Cr.MensajeError = G.ArmaMensajeError($"Excepcion en metodo {nameof(Cryptador)}.{nameof(Encrypt)}", ex);
                return (textoEncriptado, Cr.HayError, Cr.MensajeError);
            }
        }

        public static void InitMetodo()
        {
            Cr.HayError = false;
            Cr.MensajeError = "";
        }

        #endregion
    }
}

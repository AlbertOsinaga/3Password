#region Header

using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Diagnostics;
using static System.Console;
using System.Collections.Generic;

namespace _3PwdLibrary
{

#endregion

    public static class Global
    {
        #region Propiedades

        public static IConfigurationRoot ConfigurationRoot;
        public static string FormatoFecha = "yyyy/MM/dd HH:mm:ss";
        public static ILogger Logger; 
        public static string NoFecha = "0001/01/01 00:00:00";
        public static string RegNull = "reg null";
        public static string SeparadorCSV = "|";
        public static string Version = "0.2";

        #endregion

        #region Metodos
       
        public static string ArmaMensajeError(string mensaje, Exception ex = null)
        {
            StackFrame CallStack = new StackFrame(1, true);
            return $"{mensaje} en archivo '{CallStack.GetFileName()}', " + 
                    $"linea # {CallStack.GetFileLineNumber()}: " + 
                    $"'{ex?.GetType().Name}' - '{ex?.Message}'";
        }
        public static bool IsAlphanumeric(this char c) => (c >= 48 && c <= 57) || (c >= 65 && c <= 90) || (c >= 97 && c <= 122);
        public static bool IsSymbol(this char c) => !c.IsAlphanumeric();
        public static (byte[] bytes, bool ok, string mssg) ReadBinaryFile(string pathFile)
        {
            var rBytes = new List<byte>();

            try
            {
                using (var fs = new FileStream(pathFile, FileMode.Open))
                {
                    using (var br = new BinaryReader(fs))
                    {
                        var length = br.BaseStream.Length;
                        for (int i = 0; i < length; i++)
                            rBytes.Add(br.ReadByte());
                    }
                }

                return (rBytes.ToArray(), true, "");
            }
            catch (Exception ex)
            {
                var mssg = Global.ArmaMensajeError($"Excepcion en metodo { nameof(Global)}.{ nameof(ReadBinaryFile)}", ex);
                return (new byte[] {}, false, mssg);
            }
        }
        public static (bool ok, string mssg) WriteBinaryFile(string pathFile, byte[] bytes)
        {
            try
            {
                using (var fs = new FileStream(pathFile, FileMode.Create))
                {
                    using (var bw = new BinaryWriter(fs))
                    {
                        foreach (var b in bytes)
                            bw.Write(b);
                    }
                }

                return (true, "");
            }
            catch (Exception ex)
            {
                var mssg = Global.ArmaMensajeError($"Excepcion en metodo { nameof(Global)}.{ nameof(WriteBinaryFile)}", ex);
                return (false, mssg);
            }
        }
        public static void WriteHola() => WriteLine("Hola desde Global!");
        
        #endregion
    }

    #region Footer
}
#endregion

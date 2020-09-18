﻿#region Header
using System;
using System.Diagnostics;
using static System.Console;

namespace _3PwdLibrary
{
#endregion

    public static class Global
    {
        #region Propiedades
        public static string FormatoFecha = "yyyy/MM/dd HH:mm:ss";
        public static string NoFecha = "0001/01/01 00:00:00";
        public static string RegNull = "reg null!";
        public static string SeparadorCSV = "|";
        #endregion

        #region Metodos
        public static string ArmaMensajeError(string mensaje, Exception ex = null)
        {
            StackFrame CallStack = new StackFrame(1, true);
            return $"{mensaje} en archivo '{CallStack.GetFileName()}', " + 
                    $"linea # {CallStack.GetFileLineNumber()}: " + 
                    $"'{ex?.GetType().Name}' - '{ex?.Message}'";
        }

        public static void WriteHola() => WriteLine("Hola desde Global!");
        #endregion
    }

    #region Footer
}
#endregion

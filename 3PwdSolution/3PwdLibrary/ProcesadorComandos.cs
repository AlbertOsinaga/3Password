#region Header

using System;
using PC = _3PwdLibrary.ProcesadorComandos;
using MR = _3PwdLibrary.ManejadorRegistros;
using System.Collections.Generic;
using System.Linq;

namespace _3PwdLibrary
{

#endregion

    public static class ProcesadorComandos
    {
        #region Propiedades

        public static bool HayError;
        public static string MensajeError;
        public static char SeparadorCmdArg = ' ';

        #endregion

        #region Metodos

        static ProcesadorComandos()
        {
            HayError = false;
            MensajeError = "";
        }

        public static void InitMetodo()
        {
            PC.HayError = false;
            PC.MensajeError = string.Empty;
        }
        public static Comando Parse(string lineaCmd)
        {
            // El objetivo de este metodo es convertir el formato en linea de comandos
            // al registro de comando, con cmd identificando el comando,
            // arg identificando la row sobre la que se debe operar
            // y manejando el flag Ok para indicar si el parse (conversion) fue exitoso

            #region Body

            PC.InitMetodo();

            var regComando = new Comando();

            if (string.IsNullOrWhiteSpace(lineaCmd))
            {
                PC.HayError = true;
                PC.MensajeError = $"*** Error({nameof(PC.Parse)}): linea comando nula o vacia, en {nameof(ProcesadorComandos)}.{nameof(Parse)}! ***";
                return regComando;
            }

            int i = lineaCmd.IndexOf(PC.SeparadorCmdArg);  // ' '
            if (i < 0)
                i = lineaCmd.Length;
            if (i > 0)
            {
                regComando.Cmd = lineaCmd.Substring(0, i).Trim().ToLower();
                if (i == 3 && lineaCmd.Length > 4)
                    regComando.Arg = (lineaCmd.Substring(i + 1) + " ");
            }
            if (regComando.Cmd.Length != 3)
            {
                PC.HayError = true;
                PC.MensajeError = $"*** Error({nameof(PC.Parse)}): Comando '{regComando.Cmd}' debe ser de 3 caracteres," +
                                    $" en {nameof(ProcesadorComandos)}.{nameof(Parse)}! ***";
                return regComando;
            }

            switch (regComando.Cmd)
            {
                case "all":
                case "add":
                case "del":
                case "dir":
                case "get":
                case "lst":
                case "upd":
                case "viu":
                    ParseRegComando();
                    return regComando;
                default:
                    PC.HayError = true;
                    PC.MensajeError = $"*** Error({nameof(PC.Parse)}): comando '{regComando.Cmd}' no reconcido, " +
                                        $"en {nameof(ProcesadorComandos)}.{nameof(Parse)}! ***";
                    return regComando; ;
            }

            #endregion

            #region Funciones

            // Parse regComando
            void ParseRegComando()
            {
                //
                // Este metodo arma el argumento del cmd add en una row normalizada de la forma
                // UserNombre|Categoria|Empresa|Producto|Numero|WebEmpresa|UserId|UserPwd|UserEmail|userNotas|
                //

                var cmds = new string[] {};
                switch(regComando.Cmd)
                {
                    case "all":
                        regComando.Arg = "nom,cat,emp,cta,nro,web,uid,pwd,ema,not,fcr,fup,rid,lid";
                        regComando.Ok = true;
                        return;
                    case "add":
                        cmds = new[] { "nom", "cat", "emp", "cta", "nro", "web", "uid", "pwd", "ema", "not" };
                        break;
                    case "del":
                    case "get":
                        cmds = new[] { "nom", "cat", "emp", "cta", "nro" };
                        break;
                    case "dir":
                        regComando.Arg = regComando.Arg.Trim();
                        regComando.Ok = true;
                        return;
                    case "lst":
                        if (string.IsNullOrEmpty(regComando.Arg))
                            regComando.Arg = "-fld cta,uid,pwd";
                        break;
                    case "upd":
                        cmds = new[] { "nom", "cat", "emp", "cta", "nro", "web", "uid", "pwd", "ema", "not", "fcr", "fup", "rid" };
                        break;
                    case "viu":
                        regComando.Arg = "nom,cat,emp,cta,nro,web,uid,pwd,ema,not";
                        regComando.Ok = true;
                        return;
                    default:
                        break;
                }

                if (cmds.Length > 0)
                {
                    var partes = regComando.Arg.Split('-');
                    var campos = new Dictionary<string, string>();
                    var key = "";
                    foreach (var campo in partes)
                    {
                        if (campo.Length >= 4 && cmds.Where(cmd => cmd == campo.Substring(0, 3)).Any() && campo[3] == ' ')
                        {
                            key = campo.Substring(0, 3);
                            campos[key] = campo.Substring(4).Trim();
                        }
                        else
                        {
                            if (!string.IsNullOrWhiteSpace(campo))
                                campos[key] += ( "-" + campo.Trim() );
                        }
                    }

                    var arg = "";
                    foreach (var cmd in cmds)
                    {
                        if (campos.ContainsKey(cmd))
                            arg += campos[cmd];
                        arg += cmd == cmds[cmds.Length - 1] ? "" : "|";
                    }
                    regComando.Arg = arg;
                }

                regComando.Arg = regComando.Arg.Trim();
                regComando.Ok = true;
                return;
            }

            #endregion
        }
        public static string Run(string comando)
        {
            PC.InitMetodo();

            if (string.IsNullOrEmpty(comando))
            {
                PC.HayError = true;
                PC.MensajeError = $"*** Error({nameof(PC.Run)}): no se ingreso un comando! ***";
                return PC.MensajeError;
            }

            var respuesta = "";
            var regComando = PC.Parse(comando);
            if (!regComando.Ok)
            {
                PC.HayError = true;
                PC.MensajeError = $"*** Error({nameof(PC.Run)}): Comando invalido! ***";
                return PC.MensajeError;
            }

            switch (regComando.Cmd)
            {
                case "add":
                    ComandoAdd();
                    break;
                case "all":
                case "lst":
                case "viu":
                    ComandoLst();
                    break;
                case "del":
                    ComandoDel();
                    break;
                case "dir":
                    ComandoDir();
                    break;
                case "get":
                    ComandoGet();
                    break;
                case "upd":
                    ComandoUpd();
                    break;
                default:
                    respuesta = $"*** Comando '{regComando.Cmd}' no reconocido! ***";
                    break;
            }

            return respuesta;

            #region Functions

            void ComandoAdd()
            {
                respuesta = MR.CreateRegPwd(regComando.Arg);
                if (string.IsNullOrEmpty(respuesta))
                    respuesta = !MR.HayError ? $"*** Registro duplicado ***" 
                                                : $"*** Error({nameof(ComandoAdd)}): {MR.MensajeError} ***";
            }

            void ComandoDel()
            {
                bool deleteOk = MR.DeleteRegPwd(regComando.Arg);
                respuesta = deleteOk ? "*** Registro borrado! ***"
                                       : (!MR.HayError ? "*** Registro no encontrado! ***" 
                                                        : $"*** Error({nameof(ComandoDel)}): {MR.MensajeError} ***");
            }

            void ComandoDir()
            {
                MR.DirMaestro = regComando.Arg;
                respuesta = $"*** Ruta a archivo maestro: '{MR.PathMaestro}'! ***";
            }

            void ComandoGet()
            {
                respuesta = MR.RetrieveRegPwd(regComando.Arg);
                if (string.IsNullOrEmpty(respuesta))
                    respuesta = !MR.HayError ? "*** Registro no encontrado ***" 
                                                : $"*** Error({nameof(ComandoGet)}): {MR.MensajeError} ***";
            }

            void ComandoLst()
            {
                respuesta = MR.ListRowsPwdAsString(regComando.Arg);
                if (string.IsNullOrEmpty(respuesta))
                    respuesta = !MR.HayError ? "*** No hay registros ***" 
                                                : $"*** Error({nameof(ComandoLst)}): {MR.MensajeError} ***";
            }

            void ComandoUpd()
            {
                respuesta = MR.UpdateRegPwd(regComando.Arg);
                if (string.IsNullOrEmpty(respuesta))
                    respuesta = !MR.HayError ? "*** Registro no encontrado ***" 
                                                : $"*** Error({nameof(ComandoUpd)}): {MR.MensajeError} ***";
            }

            #endregion
        }

        #endregion
    }

#region Footer
}
#endregion

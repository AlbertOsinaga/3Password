#region Header

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.IO;
using _3PwdLibrary;
using G = _3PwdLibrary.Global;
using MR = _3PwdLibrary.ManejadorRegistros;
using PC = _3PwdLibrary.ProcesadorComandos;

namespace _3PwdConsola
{
    public static class Programa
    {
        static void Main(string[] args)
        {

#endregion

            Init();
            
            var lineaCmd = GetLineaCmd();
            var respuesta = PC.Run(lineaCmd);
            WriteRespuesta();

            #region Functions

            // Construye el configurador appsettings
            void BuildConfig(IConfigurationBuilder builder)
            
            {
                builder.SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                    .AddEnvironmentVariables();
            }

            // Config Settings & Logging
            IConfigurationRoot Config()
            {
                var builder = new ConfigurationBuilder();
                BuildConfig(builder);
                var configRoot = builder.Build();
                //Bienvenida.Config = configRoot;

                Log.Logger = new LoggerConfiguration()
                    //.ReadFrom.Configuration(builder.Build())
                    .ReadFrom.Configuration(configRoot)
                    .Enrich.FromLogContext()
                    .WriteTo.Console()
                    .CreateLogger();

                //Log.Logger.Information("Application Starting");
                //Bienvenida.Logger = Log.Logger;

                Host.CreateDefaultBuilder()
                    //.ConfigureServices((context, services) =>
                    //{
                    //    services.AddTransient<IGreetingService, GreetingService>();
                    //})
                    .UseSerilog()
                    .Build();

                return configRoot;
            }

            // Get fieldNames
            string GetFieldNames()
            {
                if (args.Length == 0)
                    return "";

                string fieldNames = "Cuenta|Uid|Pwd";
                if (args.Length == 1 || (args.Length > 0 && !(args[0] == "lst")))
                    return fieldNames;

                fieldNames = "";
                int fields = args.Length > 2 ? 2 : 1;
                if (args.Length > 1)
                {
                    if (args[fields].Contains("cta"))
                        fieldNames += ("Nombre" + G.SeparadorCSV);
                    if (args[fields].Contains("cat"))
                        fieldNames += ("Categoria" + G.SeparadorCSV);
                    if (args[fields].Contains("emp"))
                        fieldNames += ("Empresa" + G.SeparadorCSV);
                    if (args[fields].Contains("cta"))
                        fieldNames += ("Cuenta" + G.SeparadorCSV);
                    if (args[fields].Contains("nro"))
                        fieldNames += ("Nro" + G.SeparadorCSV);
                    if (args[fields].Contains("web"))
                        fieldNames += ("Web" + G.SeparadorCSV);
                    if (args[fields].Contains("uid"))
                        fieldNames += ("Uid" + G.SeparadorCSV);
                    if (args[fields].Contains("pwd"))
                        fieldNames += ("Pwd" + G.SeparadorCSV);
                    if (args[fields].Contains("ema"))
                        fieldNames += ("Email" + G.SeparadorCSV);
                    if (args[fields].Contains("not"))
                        fieldNames += ("Notas" + G.SeparadorCSV);
                    if (args[fields].Contains("fcr"))
                        fieldNames += ("Fec Add" + G.SeparadorCSV);
                    if (args[fields].Contains("fup"))
                        fieldNames += ("Fec Upd" + G.SeparadorCSV);
                    if (args[fields].Contains("rid"))
                        fieldNames += ("RegId" + G.SeparadorCSV);
                    if (args[fields].Contains("lid"))
                        fieldNames += ("Last RegId" + G.SeparadorCSV);
                }
                if (fieldNames[fieldNames.Length - 1] == G.SeparadorCSV[0])
                    fieldNames = fieldNames.Remove(fieldNames.Length - 1);

                return fieldNames;
            }

            // Get Linea de Comandos (args, *lineaCmd)
            string GetLineaCmd()
            {
                var lineaCmd = "";
                if (args.Length == 0)
                    return lineaCmd;
                
                foreach (var item in args)
                    lineaCmd += (item + " ");

                return lineaCmd;
            }

            // Inicializa settings & logging
            void Init()
            {
                G.ConfigurationRoot = Config();
                G.Logger = Log.Logger;
                MR.DirMaestro = G.ConfigurationRoot.GetValue<string>("DirMasterFile");
                G.Logger.Information("3Password   V:{Version}  MasterFile: {PathMaestro}", G.Version, MR.PathMaestro);
            }

            // Despliega respuesta (lineaCmd, respuesta)
            void WriteRespuesta()
            {

                Console.WriteLine();
                Console.WriteLine(lineaCmd);
                if (!string.IsNullOrEmpty(respuesta) && (respuesta[0].IsAlphanumeric() || respuesta[0] == G.SeparadorCSV[0]))
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    var fieldNames = GetFieldNames();
                    Console.WriteLine(fieldNames);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(respuesta);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(respuesta);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            #endregion

#region Footer

        }
    }

}
#endregion

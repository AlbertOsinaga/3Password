#region Header

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.IO;
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
            
            var lineaCmd = "";
            GetLineaCmd();
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

            // Get Linea de Comandos (args, *lineaCmd)
            void GetLineaCmd()
            {
                foreach (var item in args)
                    lineaCmd += (item + " ");
            }

            // Inicializa settings & logging
            void Init()
            {
                G.ConfigurationRoot = Config();
                MR.DirMaestro = G.ConfigurationRoot.GetValue<string>("DirMasterFile");
                Log.Logger.Information("3Password   MasterFile: {file}", MR.PathMaestro);
            }

            // Despliega respuesta (lineaCmd, respuesta)
            void WriteRespuesta()
            {

                Console.WriteLine();
                Console.WriteLine(lineaCmd);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                var fieldNames = GetFieldNames();
                Console.WriteLine(fieldNames);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(respuesta);
                Console.ForegroundColor = ConsoleColor.White;
            }

            // Get fieldNames
            string GetFieldNames()
            {
                string fieldNames = "Cuenta|Uid|Pwd";
                if (args.Length == 1 || (args.Length > 0 && !(args[0] == "lst")))
                    return fieldNames;

                fieldNames = "";
                if (args.Length > 1)
                {
                    if (args[1].Contains("cta"))
                        fieldNames += ("Nombre" + G.SeparadorCSV);
                    if (args[1].Contains("cat"))
                        fieldNames += ("Categoria" + G.SeparadorCSV);
                    if (args[1].Contains("emp"))
                        fieldNames += ("Empresa" + G.SeparadorCSV);
                    if (args[1].Contains("cta"))
                        fieldNames += ("Cuenta" + G.SeparadorCSV);
                    if (args[1].Contains("nro"))
                        fieldNames += ("Nro" + G.SeparadorCSV);
                    if (args[1].Contains("web"))
                        fieldNames += ("Web" + G.SeparadorCSV);
                    if (args[1].Contains("uid"))
                        fieldNames += ("Uid" + G.SeparadorCSV);
                    if (args[1].Contains("pwd"))
                        fieldNames += ("Pwd" + G.SeparadorCSV);
                    if (args[1].Contains("ema"))
                        fieldNames += ("Email" + G.SeparadorCSV);
                    if (args[1].Contains("not"))
                        fieldNames += ("Notas" + G.SeparadorCSV);
                    if (args[1].Contains("fcr"))
                        fieldNames += ("Fec Add" + G.SeparadorCSV);
                    if (args[1].Contains("fup"))
                        fieldNames += ("Fec Upd" + G.SeparadorCSV);
                    if (args[1].Contains("rid"))
                        fieldNames += ("RegId" + G.SeparadorCSV);
                    if (args[1].Contains("lid"))
                        fieldNames += ("Last RegId" + G.SeparadorCSV);
                }
                if (fieldNames[fieldNames.Length - 1] == G.SeparadorCSV[0])
                    fieldNames = fieldNames.Remove(fieldNames.Length - 1);

                return fieldNames;
            }

            #endregion

#region Footer

        }
    }

}
#endregion

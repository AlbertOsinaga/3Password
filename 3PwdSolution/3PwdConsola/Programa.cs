#region Header

using System;

using PC = _3PwdLibrary.ProcesadorComandos;

namespace _3PwdConsola
{


    
    public static class Programa
    {
#endregion
        
        static void Main(string[] args)
        {
            var lineaCmd = "";
            foreach (var item in args)
                lineaCmd += (item + " ");

            var respuesta = PC.Run(lineaCmd);
            Console.WriteLine();
            Console.WriteLine(lineaCmd);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Nombre|Categoria|Empresa|Cuenta|Nro|Web|Uid|Pwd|Email|Notas|Fec Add|Fec Upd|RegId|Last RegId");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(respuesta);
            Console.ForegroundColor = ConsoleColor.White;
        }

        #region Footer

    }

}
#endregion

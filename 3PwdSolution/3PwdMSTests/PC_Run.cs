#region Header

using Microsoft.VisualStudio.TestTools.UnitTesting;

using MR = _3PwdLibrary.ManejadorRegistros;
using PC = _3PwdLibrary.ProcesadorComandos;

namespace _3PwdMSTests
{

#endregion
    
    [TestClass]
    public class PC_Run
    {

        [TestMethod]
        public void Test1()
        {
            // Prepara
            var linea = "add -nom Luis Alberto -cat cat Software -emp Microsoft -cta Azure -nro Cuenta 1 " +
                        " -web web.azure.com -uid laos -pwd clavesecreta -ema luis.@gmail.com -not prueba de Registro";

            // Ejecuta
            PC.Parse(linea);

            // Prueba

        }

        [TestMethod]
        public void Add_ok()
        {
            // Prepara
            MR.NameMaestro = MR.NameMaestro_Default;
            MR.EmptyMaestro();
            var lineaComando = "add -cta Gmail LAOS -uid luis@gmail.com -pwd claveSecreta$";
            var rowEsperada = "|||Gmail LAOS|||luis@gmail.com|claveSecreta$||";

            // Ejecuta
            var respuesta = PC.Run(lineaComando);

            // Prueba
            Assert.IsTrue(respuesta.Contains(rowEsperada));
        }
    }

    #region Footer
}
#endregion
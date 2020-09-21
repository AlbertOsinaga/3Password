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
            var rowEsperada = "|||Gmail LAOS|||luis@gmail.com|claveSecreta$||";

            // Ejecuta
            var lineaComando = "add -cta Gmail LAOS -uid luis@gmail.com -pwd claveSecreta$";
            var respuesta = PC.Run(lineaComando);

            // Prueba
            Assert.IsNotNull(respuesta);
            Assert.IsTrue(respuesta.Contains(rowEsperada));
        }

        [TestMethod]
        public void Del_ok()
        {
            // Prepara
            MR.NameMaestro = MR.NameMaestro_Default;
            MR.EmptyMaestro();
            var lineaComando = "add -nom Luis Alberto -cta Gmail LAOS -uid luis@gmail.com -pwd claveSecreta$";
            var respuesta = PC.Run(lineaComando);

            // Ejecuta
            lineaComando = "del -nom Luis Alberto -cta Gmail LAOS";
            respuesta = PC.Run(lineaComando);

            // Prueba
            Assert.IsNotNull(respuesta);
            Assert.AreEqual("*** registro borrado! ***", respuesta);
        }

        [TestMethod]
        public void Get_ok()
        {
            // Prepara
            MR.NameMaestro = MR.NameMaestro_Default;
            MR.EmptyMaestro();
            var lineaComando = "add -nom Luis Alberto -cat Programas -cta Gmail LAOS -uid luis@gmail.com -pwd claveSecreta$";
            var respuesta = PC.Run(lineaComando);
            var respuestaEsperada = "Luis Alberto|Programas||Gmail LAOS|||luis@gmail.com|claveSecreta$";

            // Ejecuta
            lineaComando = "get -nom Luis Alberto -cta Gmail LAOS -cat Programas";
            respuesta = PC.Run(lineaComando);

            // Prueba
            Assert.IsNotNull(respuesta);
            Assert.IsTrue(respuesta.Contains(respuestaEsperada));
        }

        [TestMethod]
        public void Upd_ok()
        {
            // Prepara
            MR.NameMaestro = MR.NameMaestro_Default;
            MR.EmptyMaestro();
            var lineaComando = "add -nom Luis Alberto -cta Gmail LAOS -uid luis@gmail.com -pwd claveSecreta$ -cat Programas -emp Google";
            var respuesta = PC.Run(lineaComando);
            var respuestaEsperada = "Luis Alberto|Programas|Google|Gmail LAOS|||alberto@gmail.com|clavePowerfull";

            // Ejecuta
            lineaComando = "upd  -nom Luis Alberto -cta Gmail LAOS -uid alberto@gmail.com -pwd clavePowerfull -cat Programas -emp Google";
            respuesta = PC.Run(lineaComando);

            // Prueba
            Assert.IsNotNull(respuesta);
            Assert.IsTrue(respuesta.Contains(respuestaEsperada));
        }
    }

    #region Footer
}
#endregion
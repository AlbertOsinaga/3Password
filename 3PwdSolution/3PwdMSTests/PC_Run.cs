﻿#region Header

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
            Assert.AreEqual("*** Registro borrado! ***", respuesta);
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
        public void Lst_all_ok()
        {
            // Prepara
            MR.NameMaestro = MR.NameMaestro_Default;
            MR.EmptyMaestro();
            var lineaComando = "add -nom Luis Alberto -cat Programas -cta Gmail LAOS -uid luis@gmail.com -pwd claveSecreta$";
            var respuesta = PC.Run(lineaComando);
            lineaComando = "add -nom Luis -cat Programas -cta Gmail LAOS -uid luis@gmail.com -pwd claveSecreta$";
            respuesta = PC.Run(lineaComando);
            lineaComando = "add -nom Alberto -cat Programas -cta Gmail LAOS -uid luis@gmail.com -pwd claveSecreta$";
            respuesta = PC.Run(lineaComando);
            lineaComando = "add -nom Luigi -cat Programas -cta Gmail LAOS -uid luis@gmail.com -pwd claveSecreta$";
            respuesta = PC.Run(lineaComando);
            var respuestaEsperada1 = "Luis Alberto|Programas||Gmail LAOS|||luis@gmail.com|claveSecreta$";
            var respuestaEsperada2 = "Luis|Programas||Gmail LAOS|||luis@gmail.com|claveSecreta$";
            var respuestaEsperada3 = "Alberto|Programas||Gmail LAOS|||luis@gmail.com|claveSecreta$";
            var respuestaEsperada4 = "Luigi|Programas||Gmail LAOS|||luis@gmail.com|claveSecreta$";

            // Ejecuta
            lineaComando = "all";
            respuesta = PC.Run(lineaComando);

            // Prueba
            Assert.IsNotNull(respuesta);
            Assert.IsTrue(respuesta.Contains(respuestaEsperada1));
            Assert.IsTrue(respuesta.Contains(respuestaEsperada2));
            Assert.IsTrue(respuesta.Contains(respuestaEsperada3));
            Assert.IsTrue(respuesta.Contains(respuestaEsperada4));
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
#region Header

using Microsoft.VisualStudio.TestTools.UnitTesting;

using PC = _3PwdLibrary.ProcesadorComandos;

namespace _3PwdMSTests
{

#endregion
    
    [TestClass]
    public class PC_Parse
    {
        [TestMethod]
        public void Add_ok_espacios()
        {
            // Prepara
            var lineaComando = "add -nom Juan Perez -uid jperez -pwd secreto!";

            // Ejecuta
            var regCmd = PC.Parse(lineaComando);

            // Prueba
            Assert.IsTrue(regCmd.Ok);
            Assert.AreEqual("add", regCmd.Cmd);
            Assert.AreEqual("Juan Perez||||||jperez|secreto!||", regCmd.Arg);
        }

        [TestMethod]
        public void Add_ok_full()
        {
            // Prepara
            var lineaComando = "add -cta Microsoft Azure -nro #123001 -nom Luis Alberto -cat Software -emp Microsoft " +
                        " -web web.azure.com -uid laos -pwd supersecreta -ema luis.@gmail.com -not prueba de registro";

            // Ejecuta
            var regCmd = PC.Parse(lineaComando);

            // Prueba
            Assert.IsTrue(regCmd.Ok);
            Assert.AreEqual("add", regCmd.Cmd);
            Assert.AreEqual("Luis Alberto|Software|Microsoft|Microsoft Azure|#123001|web.azure.com|laos|supersecreta|luis.@gmail.com|prueba de registro", regCmd.Arg);
        }

        [TestMethod]
        public void Add_ok_noEspacios()
        {
            // Prepara
            var lineaComando = "add -cta Camaleon -uid carlos.lopez -pwd facil_clave -web www.camaleon.com -not todo es igual!";
            // Ejecuta
            var regCmd = PC.Parse(lineaComando);

            // Prueba
            Assert.IsTrue(regCmd.Ok);
            Assert.AreEqual("add", regCmd.Cmd);
            Assert.AreEqual("|||Camaleon||www.camaleon.com|carlos.lopez|facil_clave||todo es igual!", regCmd.Arg);
        }

        [TestMethod]
        public void Del_ok_full()
        {
            // Prepara
            var lineaComando = "del -nom Luis Alberto -cat Software -emp Microsoft -cta Microsoft Azure -nro 0001";

            // Ejecuta
            var regCmd = PC.Parse(lineaComando);

            // Prueba
            Assert.IsTrue(regCmd.Ok);
            Assert.AreEqual("del", regCmd.Cmd);
            Assert.AreEqual("Luis Alberto|Software|Microsoft|Microsoft Azure|0001", regCmd.Arg);
        }

        [TestMethod]
        public void Get_ok_full()
        {
            // Prepara
            var lineaComando = "get -nom Luis Alberto -cat Software -emp Microsoft -cta Microsoft Azure -nro 0001";

            // Ejecuta
            var regCmd = PC.Parse(lineaComando);

            // Prueba
            Assert.IsTrue(regCmd.Ok);
            Assert.AreEqual("get", regCmd.Cmd);
            Assert.AreEqual("Luis Alberto|Software|Microsoft|Microsoft Azure|0001", regCmd.Arg);
        }

        [TestMethod]
        public void Lst_ok_full()
        {
            // Prepara
            var lineaComando = "lst -nom Luis Alberto -cat Software -emp Microsoft -cta Microsoft Azure -nro 0001";

            // Ejecuta
            var regCmd = PC.Parse(lineaComando);

            // Prueba
            Assert.IsTrue(regCmd.Ok);
            Assert.AreEqual("lst", regCmd.Cmd);
            Assert.AreEqual("", regCmd.Arg);
        }

        [TestMethod]
        public void Upd_ok_full()
        {
            // Prepara
            var lineaComando = "upd -cta Microsoft Azure -nro #123001 -nom Luis Alberto -cat Software -emp Microsoft " +
                        " -web web.azure.com -uid laos -pwd supersecreta -ema luis.@gmail.com -not prueba de registro " +
                        "-fcr -fup -rid";

            // Ejecuta
            var regCmd = PC.Parse(lineaComando);

            // Prueba
            Assert.IsTrue(regCmd.Ok);
            Assert.AreEqual("upd", regCmd.Cmd);
            Assert.AreEqual("Luis Alberto|Software|Microsoft|Microsoft Azure|#123001|web.azure.com|laos|supersecreta|luis.@gmail.com|prueba de registro|||", regCmd.Arg);
        }

        [TestMethod]
        public void Upd_ok_noCamposSistema()
        {
            // Prepara
            var lineaComando = "upd -cta Microsoft Azure -nro #123001 -nom Luis Alberto -cat Software -emp Microsoft " +
                        " -web web.azure.com -uid laos -pwd supersecreta -ema luis.@gmail.com -not prueba de registro ";

            // Ejecuta
            var regCmd = PC.Parse(lineaComando);

            // Prueba
            Assert.IsTrue(regCmd.Ok);
            Assert.AreEqual("upd", regCmd.Cmd);
            Assert.AreEqual("Luis Alberto|Software|Microsoft|Microsoft Azure|#123001|web.azure.com|laos|supersecreta|luis.@gmail.com|prueba de registro|||", regCmd.Arg);
        }
    }

    #region Footer
}
#endregion
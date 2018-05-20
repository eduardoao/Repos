using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebLocadoras.Models;
using WebLocadoras.Data;
using Microsoft.Extensions.Configuration;

namespace UtWebLocadoras
{
    [TestClass]
    public class UnitTest1
    {

        private AcessoDados _acessoDados;
        private DbContexto _contexto;

        [TestInitialize]
        public void Inicializar()
        {

    

            //_contexto(options => options.UseNpgsql(connectionString));

            //_contexto = new DbContexto(builder.);
            //_acessoDados = new AcessoDados()

        }

        [TestMethod]
        public void UtCliente()
        {
            var cliente = new EntidadeCliente { Id = 1 };

           


        }
    }
}

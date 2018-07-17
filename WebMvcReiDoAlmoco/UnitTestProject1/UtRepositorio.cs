using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using WebMvcDoAlmoco;
using WebMvcDoAlmoco.Models;
using WebMvcDoAlmoco.Repositorio;
using WebMvcReiDoAlmoco.Interfaces;

namespace UnitTestProject1
{
    [TestClass]
    public class UtRepositorio
    {

        private string connectionstring =  "Data Source = LAPTOP-QSD1P64U; Initial Catalog = ReiDoAlmoco; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
        private Mock<IConfigurationSection> configurationSectionStub;
        Mock<IConfiguration> configurationStub;
        private IServiceCollection services;
        private ICandidatoRepositorio candidatoRepositorio;
        private ServiceProvider ServiceProvider;

        private IList<BaseModel> listaCandidatos;

        private ICandidatoRepositorio RetornarCandidatoRepositorio()
        {
            return ServiceProvider.GetService<ICandidatoRepositorio>();
        }

       [TestInitialize]
       public void SetUp()
        {          
            configurationSectionStub = new Mock<IConfigurationSection>();
            configurationSectionStub.Setup(c => c["Default"]).Returns(connectionstring);
            configurationStub = new Mock<IConfiguration>();
            configurationStub.Setup(x => x.GetSection("ConnectionStrings")).Returns(configurationSectionStub.Object);

            services = new ServiceCollection();
            services.AddTransient<ICandidatoRepositorio, CandidatoRepositorio>();

            var target = new Startup(configurationStub.Object);
            target.ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();

        }

       [TestMethod]
       public void TesteCadastroCandidatoComSucesso()
        {
            var candidato = new Candidato { Email = "eoalcantara@gmail.com", Nome = "Eduardo Alcantara" };
            candidatoRepositorio = RetornarCandidatoRepositorio();            
            candidatoRepositorio.Adicionar(candidato);                      
            
        }

       [TestMethod]
        public void TesteRetornarCandidatosComSucesso()
        {
            candidatoRepositorio = RetornarCandidatoRepositorio();
            listaCandidatos = candidatoRepositorio.RetornarTodos();
            Assert.AreNotEqual(listaCandidatos.Count, 0);
        }


        [TestMethod]
        public void TesteRemoverCandidatosComSucesso()
        {
            candidatoRepositorio = RetornarCandidatoRepositorio();
            listaCandidatos = candidatoRepositorio.RetornarTodos();

            foreach (var item in listaCandidatos)
            {
                candidatoRepositorio.Remover(item);
            }
           
        }



    }
}

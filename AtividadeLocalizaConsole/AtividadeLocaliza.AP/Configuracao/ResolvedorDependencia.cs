using AtividadeLocaliza.BLL;
using AtividadeLocaliza.DAL;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AtividadeLocaliza.AP.Configuracao
{
    public static class ResolvedorDependencia
    {
        public static ServiceProvider resolver(IConfiguration configuration)
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<INumeracaoBLL, DecompositorNumericoBLL>();
            serviceCollection.AddScoped<IDecompositorNumericoDAL, DecompositorNumericoDAL>();
            serviceCollection.AddSingleton(configuration);

            var serviceProvider = serviceCollection.BuildServiceProvider();
            return serviceProvider;
        }

    }

}

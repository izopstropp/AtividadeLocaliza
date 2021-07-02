using AtividadeLocaliza.Infrasctructure.Ioc.Modulos;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AtividadeLocaliza.Infrasctructure.Ioc
{
    public static class ResolvedorDependencia
    {
        public static IServiceCollection Resolver(IServiceCollection serviceCollection)
        {

            IServiceCollection dependenciasResolvidas = ApplicationModule.ResolverDependencias(serviceCollection);
            dependenciasResolvidas = DomainServiceModule.ResolverDependencias(dependenciasResolvidas);

            return dependenciasResolvidas;
        }
    }
}

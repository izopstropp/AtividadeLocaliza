using AtividadeLocaliza.Domain.Interfaces.Services;
using AtividadeLocaliza.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AtividadeLocaliza.Infrasctructure.Ioc.Modulos
{
    internal static class DomainServiceModule
    {
        internal static IServiceCollection ResolverDependencias(IServiceCollection serviceCollection) 
        {
            serviceCollection.AddScoped<IDecomposicaoNumericaService, DecomposicaoNumericaService>();
            return serviceCollection;
        }
    }
}

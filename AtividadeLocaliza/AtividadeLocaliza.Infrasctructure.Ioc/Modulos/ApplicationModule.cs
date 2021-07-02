using AtividadeLocaliza.Application.AppService;
using AtividadeLocaliza.Application.Intefaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AtividadeLocaliza.Infrasctructure.Ioc.Modulos
{
    internal static class ApplicationModule
    {
        internal static IServiceCollection ResolverDependencias(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IDecomposicaoNumericaAppService, DecomposicaoNumericaAppService>();
            return serviceCollection;
        }
    }
}

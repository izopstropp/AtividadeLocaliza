using AtividadeLocaliza.Domain.Interfaces.Repositories;
using AtividadeLocaliza.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AtividadeLocaliza.Infrasctructure.Ioc.Modulos
{
    internal class RepositoryModule
    {

        internal static IServiceCollection ResolverDependencias(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IDecompositorNumericoRepository, DecompositorNumericoRepository>();
            return serviceCollection;
        }
    }

}

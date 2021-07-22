using AtividadeLocaliza.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace AtividadeLocaliza.Infrastructure.Repository
{
    public class DecompositorNumericoRepository : IDecompositorNumericoRepository
    {
        private IConfiguration _configuration;
        private readonly string ConnectionString;

        public DecompositorNumericoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetValue<string>("ConnectionStrings:ConnectionDecompositorNumerico");
        }
        public async Task<bool> SalvarNumeroDecomposto(long numero)
        {
            int qtdRegistrosAfetados = 0;
            try
            {
                using ( var con = new SqlConnection(ConnectionString))
                {
                    qtdRegistrosAfetados = await con.ExecuteAsync(@"INSERT INTO [dbo].[HistoricosPesquisa]
                                                       (Descricao)
                                                 VALUES
                                                       (@numero)", new { @numero = numero.ToString() });

                }
            }
            catch (Exception ex)
           {

                throw;
            }

            return qtdRegistrosAfetados > 0;
        }
    }
}

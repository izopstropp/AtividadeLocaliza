using AtividadeLocaliza.AP.Configuracao;
using AtividadeLocaliza.BLL;
using AtividadeLocalizaConsole.DTO;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AtividadeLocaliza.AP
{
    class Program
    {

        static async Task Main(string[] args)
        {

            var container = ResolvedorDependencia.resolver(ProviderConfiguration.SetupConfiguration(args));


            long numero;
            var permanecerAplicacao = false;
            bool statusProcesso;

            Console.WriteLine("Decompositor Numerico\r");
            Console.WriteLine("------------------------\n");
            do
            {
                do
                {
                    try
                    {

                        Console.WriteLine("\n\n\n\nDigite o numero para decompor:");
                        numero = Convert.ToInt64(Console.ReadLine());

                        if (numero < 0)
                        {
                            throw new FormatException();
                        }
                        Console.Clear();
                        INumeracaoBLL numeracaoBLL = container.GetService<INumeracaoBLL>();

                        NumeracaoDecompostaDto numeroDecomposto = await numeracaoBLL.obterNumeroDecomposto(numero);
                        Console.WriteLine("\n\n\n\n\nNumero de Entrada:" + numeroDecomposto.NumeroEntrada);
                        Console.WriteLine("Números divisores:" + string.Join(",", numeroDecomposto.NumerosDivisores));
                        Console.WriteLine("Divisores primos:" + string.Join(",", numeroDecomposto.DivisoresPrimos));
                        statusProcesso = true;

                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("Padrão numerico incorreto.");
                        statusProcesso = false;
                    }
                    catch (HttpRequestException e)
                    {
                        Console.WriteLine("O sistema se encontra inoperante tente novamente em instantes.");
                        statusProcesso = false;
                    }
                    catch (AggregateException e)
                    {
                        Console.WriteLine("O sistema se encontra inoperante tente novamente em instantes.");
                        statusProcesso = false;
                    }
                } while (!statusProcesso);

                Console.WriteLine("\n\n\n\n\nDigite a opção:");
                Console.WriteLine(" 1 - Decompor um novo numero.");
                Console.WriteLine(" 2 - Sair");

                switch (Console.ReadLine())
                {
                    case "1":
                        permanecerAplicacao = false;
                        break;
                    case "2":
                        permanecerAplicacao = true;
                        break;
                    default:
                        Console.WriteLine("Saindo da aplicação");
                        permanecerAplicacao = true;
                        break;

                }
                Console.Clear();
            } while (!permanecerAplicacao);


        }
    }
}
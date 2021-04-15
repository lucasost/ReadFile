using ReadFile.Domain.Interfaces;
using ReadFile.Domain.ViewModel;
using System.Linq;

namespace ReadFile.Service
{
    public class EscreverArquivo : IEscreverArquivoRepository
    {
        void IEscreverArquivoRepository.EscreverArquivo(DadosRetornoArquivoModel dadosDoArquivo, string caminhoSaida)
        {
            string caminhoCompletoSaida = caminhoSaida + dadosDoArquivo.NomeArquivoSaida;
            var registrarOcorrenciasArquivo = new RegistrarInformacao(new RegistrarNoArquivo(caminhoCompletoSaida));
            registrarOcorrenciasArquivo.RegistrarInfo($"Relatório {dadosDoArquivo.NomeArquivoSaida}");
            registrarOcorrenciasArquivo.RegistrarInfo($"Quantidade de clientes: {dadosDoArquivo.Clientes.Count}");
            registrarOcorrenciasArquivo.RegistrarInfo($"Quantidade de Vendedores: {dadosDoArquivo.Vendedores.Count}");

            var melhorVenda = dadosDoArquivo.Vendas.GroupBy(a => a.SaleId).Select(g => new MelhorVendaViewModel
            {
                SaleId = g.Key,
                ValorVenda = g.SelectMany(b => b.Itens).Sum(c => c.ItemPrice)
            }).OrderByDescending(a => a.ValorVenda).FirstOrDefault();

            registrarOcorrenciasArquivo.RegistrarInfo($"Melhor venda: {melhorVenda.SaleId} no valor de R$ {melhorVenda.ValorVenda}");

            var piorvendedor = dadosDoArquivo.Vendas.GroupBy(a => a.Salesman).Select(g => new VendedorDesempenhoViewModel
            {
                Vendedor = g.Key,
                ValorVenda = g.SelectMany(b => b.Itens).Sum(c => c.ItemPrice)
            }).OrderBy(a => a.ValorVenda).FirstOrDefault();
            registrarOcorrenciasArquivo.RegistrarInfo($"Vendedor com pior desempenho: {piorvendedor.Vendedor}, vendendo apenas R$ {piorvendedor.ValorVenda}");
        }
    }
}

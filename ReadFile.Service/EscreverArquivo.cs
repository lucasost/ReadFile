using ReadFile.Domain.Interfaces;
using ReadFile.Domain.ViewModel;
using System.Linq;

namespace ReadFile.Service
{
    public class EscreverArquivo : IEscreverArquivoRepository
    {
        private readonly IRegistro _registrarInformacao;

        public EscreverArquivo(IRegistro registrarInformacao)
        {
            _registrarInformacao = registrarInformacao;
        }
        void IEscreverArquivoRepository.EscreverArquivo(DadosRetornoArquivoModel dadosDoArquivo, string caminhoSaida, string nomeArquivoSaida)
        {
            string caminhoCompletoSaida = caminhoSaida + nomeArquivoSaida;
            _registrarInformacao.RegistrarInfo($"Relatório - {nomeArquivoSaida}", caminhoCompletoSaida);
            _registrarInformacao.RegistrarInfo($"Quantidade de clientes: {dadosDoArquivo.Clientes.Count}", caminhoCompletoSaida);
            _registrarInformacao.RegistrarInfo($"Quantidade de Vendedores: {dadosDoArquivo.Vendedores.Count}", caminhoCompletoSaida);

            var melhorVenda = dadosDoArquivo.Vendas.GroupBy(a => a.SaleId).Select(g => new MelhorVendaViewModel
            {
                SaleId = g.Key,
                ValorVenda = g.SelectMany(b => b.Itens).Sum(c => c.ItemPrice)
            }).OrderByDescending(a => a.ValorVenda).FirstOrDefault();
            _registrarInformacao.RegistrarInfo($"Melhor venda: {melhorVenda.SaleId} no valor de R$ {melhorVenda.ValorVenda}", caminhoCompletoSaida);

            var piorvendedor = dadosDoArquivo.Vendas.GroupBy(a => a.Salesman).Select(g => new VendedorDesempenhoViewModel
            {
                Vendedor = g.Key,
                ValorVenda = g.SelectMany(b => b.Itens).Sum(c => c.ItemPrice)
            }).OrderBy(a => a.ValorVenda).FirstOrDefault();
            _registrarInformacao.RegistrarInfo($"Vendedor com pior desempenho: {piorvendedor.Vendedor}, vendendo apenas R$ {piorvendedor.ValorVenda}", caminhoCompletoSaida);
        }
    }
}

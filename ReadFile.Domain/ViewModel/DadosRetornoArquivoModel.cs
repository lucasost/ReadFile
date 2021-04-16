using ReadFile.Domain.Entity;
using System.Collections.Generic;

namespace ReadFile.Domain.ViewModel
{
    public class DadosRetornoArquivoModel
    {
        public List<Venda> Vendas { get; set; }
        public List<Cliente> Clientes { get; set; }
        public List<Vendedor> Vendedores { get; set; }
    }
}

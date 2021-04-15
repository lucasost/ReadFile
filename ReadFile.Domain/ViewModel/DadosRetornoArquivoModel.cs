using ReadFile.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadFile.Domain.ViewModel
{
    public class DadosRetornoArquivoModel
    {
        public string CaminhoSaida { get; set; }
        public string NomeArquivoSaida { get; set; }
        public List<Venda> Vendas { get; set; }
        public List<Cliente> Clientes { get; set; }
        public List<Vendedor> Vendedores { get; set; }
    }
}

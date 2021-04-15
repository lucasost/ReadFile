using System.Collections.Generic;

namespace ReadFile.Domain.Repository
{
    public class Venda : Base
    {
        public int SaleId { get; set; }

        public List<VendaItem> Itens { get; set; }

        public string Salesman { get; set; }
    }
}

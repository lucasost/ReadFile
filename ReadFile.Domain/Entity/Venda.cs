using System.Collections.Generic;

namespace ReadFile.Domain.Entity
{
    public class Venda : Base
    {
        public int SaleId { get; set; }

        public List<VendaItem> Itens { get; set; }

        public string Salesman { get; set; }
    }
}

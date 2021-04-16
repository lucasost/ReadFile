using System.Collections.Generic;

namespace ReadFile.Domain.Entity
{
    public class Venda : Base
    {
        public Venda(string type, int saleId, string salesman) : base(type)
        {
            SaleId = saleId;
            Itens = new List<VendaItem> ();
            Salesman = salesman;
        }

        public int SaleId { get; }

        public List<VendaItem> Itens { get; }

        public string Salesman { get; }
    }
}

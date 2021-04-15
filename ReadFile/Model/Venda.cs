using FileHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadFile.Model
{
    public class Venda
    {
        public string Type { get; set; }

        public int SaleId { get; set; }

        public List<VendaItem> Itens { get; set; }

        public string Salesman { get; set; }

    }
}

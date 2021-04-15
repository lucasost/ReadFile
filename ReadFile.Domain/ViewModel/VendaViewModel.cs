using FileHelpers;

namespace ReadFile.Domain.ViewModel
{
    [DelimitedRecord("ç")]
    public class VendaViewModel
    {
        public string Type { get; set; }

        public int SaleId { get; set; }

        public string ItensVendas { get; set; }

        public string Salesman { get; set; }

    }
}

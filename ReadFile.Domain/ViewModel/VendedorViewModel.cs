using FileHelpers;

namespace ReadFile.Domain.ViewModel
{
    [DelimitedRecord("ç")]
    public class VendedorViewModel
    {
        public string Type { get; set; }
        public string Cpf { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
    }
}

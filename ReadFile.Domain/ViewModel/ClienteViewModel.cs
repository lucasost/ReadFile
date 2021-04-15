using FileHelpers;

namespace ReadFile.Domain.ViewModel
{
    [DelimitedRecord("ç")]
    public class ClienteViewModel
    {
        public string Type { get; set; }
        public string Cnpj { get; set; }
        public string Name { get; set; }
        public string BusinessArea { get; set; }
    }
}

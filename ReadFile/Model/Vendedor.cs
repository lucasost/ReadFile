using FileHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadFile.Model
{
    [DelimitedRecord("ç")]
    public class Vendedor
    {
        public string Type { get; set; }
        public string Cpf { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
    }
}

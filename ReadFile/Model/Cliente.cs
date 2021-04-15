using FileHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadFile.Model
{
    [DelimitedRecord("ç")]
    public class Cliente
    {
        public string Type { get; set; }
        public string Cnpj { get; set; }
        public string Name { get; set; }
        public string BusinessArea { get; set; }
    }
}

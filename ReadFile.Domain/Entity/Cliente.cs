namespace ReadFile.Domain.Entity
{
    public class Cliente : Base
    {
        public Cliente(string type, string cnpj, string name, string businessArea)
        {
            Type = type;
            Cnpj = cnpj;
            Name = name;
            BusinessArea = businessArea;
        }

        public string Cnpj { get; set; }
        public string Name { get; set; }
        public string BusinessArea { get; set; }
    }
}

namespace ReadFile.Domain.Entity
{
    public class Cliente : Base
    {
        public Cliente(string type, string cnpj, string name, string businessArea) : base(type)
        {
            Cnpj = cnpj;
            Name = name;
            BusinessArea = businessArea;
        }

        public string Cnpj { get; }
        public string Name { get; }
        public string BusinessArea { get; }
    }
}

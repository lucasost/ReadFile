namespace ReadFile.Domain.Entity
{
    public class Vendedor : Base
    {
        public Vendedor(string type, string cpf, string name, decimal salary) : base(type)
        {
            Cpf = cpf;
            Name = name;
            Salary = salary;
        }

        public string Cpf { get; }
        public string Name { get; }
        public decimal Salary { get; }
    }
}

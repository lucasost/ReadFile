namespace ReadFile.Domain.Entity
{
    public class Vendedor : Base
    {
        public Vendedor(string type, string cpf, string name, decimal salary)
        {
            Type = type;
            Cpf = cpf;
            Name = name;
            Salary = salary;
        }

        public string Cpf { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
    }
}

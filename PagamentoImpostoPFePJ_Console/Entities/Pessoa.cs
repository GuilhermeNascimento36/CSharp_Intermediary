namespace PagamentoImpostoPFePJ_Console.Entities
{
    internal abstract class Pessoa
    {
        public string Name { get; protected set; }
        public double AnnualIncome { get; protected set; }

        public Pessoa(string name, double annualIncome)
        {
            Name = name;
            AnnualIncome = annualIncome;
        }

        public abstract double CalculateTax();
    }
}

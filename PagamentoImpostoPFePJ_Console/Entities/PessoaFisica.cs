namespace PagamentoImpostoPFePJ_Console.Entities
{
    internal class PessoaFisica : Pessoa
    {
        public double HelthExpenditures { get; private set; }
        public PessoaFisica(string name, double annualIncome, double helthExpenditures) : base(name, annualIncome)
        {
            HelthExpenditures = helthExpenditures;
        }
        public override double CalculateTax()
        {
            if (AnnualIncome < 20000)
            {
                return (AnnualIncome * 0.15) - (HelthExpenditures * 0.50);
            }
            else
            {
                return (AnnualIncome * 0.25) - (HelthExpenditures * 0.50);
            }
        }
    }
}

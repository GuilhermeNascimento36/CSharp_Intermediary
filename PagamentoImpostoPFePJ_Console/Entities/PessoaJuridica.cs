namespace PagamentoImpostoPFePJ_Console.Entities
{
    internal class PessoaJuridica : Pessoa
    {
        public int EmployeesNumber { get; private set; }

        public PessoaJuridica(string name, double annualIncome, int employeesNumber) : base(name, annualIncome)
        {
            EmployeesNumber = employeesNumber;
        }

        public override double CalculateTax()
        {
            if(EmployeesNumber > 10)
            {
                return AnnualIncome * 0.14;
            }
            else
            {
                return AnnualIncome * 0.16;
            }
        }
    }
}

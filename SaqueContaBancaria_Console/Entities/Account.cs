using SaqueContaBancaria_Console.Entities.Exceptions;

namespace SaqueContaBancaria_Console.Entities
{
    internal class Account
    {
        public int Number { get; private set; }
        public string Holder { get; private set; }
        public double Balance { get; private set; }
        public double WithDrawLimit { get; private set; }

        public Account(int number, string holder, double balance, double withDrawLimit)
        {
            Number = number;
            Holder = holder;
            Balance = balance;
            WithDrawLimit = withDrawLimit;
        }

        public void Deposit(double amount)
        {
            if(amount < 0)
            {
                throw new DomainException("The amount cannot be less than zero.");
            }
            Balance += amount;
        }

        public void WithDraw(double amount)
        {
            if(amount > WithDrawLimit && amount <= Balance)
            {
                throw new DomainException("Withdraw error: The amount exceeds withdraw limit.");
            }

            if (amount > WithDrawLimit && amount > Balance)
            {
                throw new DomainException("Withdraw error: The amount exceeds withdraw limit and your balance.");
            }

            if (amount < WithDrawLimit && amount > Balance)
            {
                throw new DomainException("Withdraw error: Not enough balance.");
            }

            Balance -= amount;
        }
    }
}

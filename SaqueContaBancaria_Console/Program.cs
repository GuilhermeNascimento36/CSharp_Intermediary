using System;
using SaqueContaBancaria_Console.Entities;
using SaqueContaBancaria_Console.Entities.Exceptions;
using System.Globalization;

namespace SaqueContaBancaria_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Fazer um programa para ler os dados de uma conta bancária e depois realizar um 
            saque nesta conta bancária, mostrando o novo saldo. Um saque não pode ocorrer 
            ou se não houver saldo na conta, ou se o valor do saque for superior ao limite de 
            saque da conta. Implemente a conta bancária conforme projeto abaixo*/

            bool error = false;

            try
            {
                Console.WriteLine("Enter account data");
                Console.Write("Number: ");
                int number = int.Parse(Console.ReadLine());
                Console.Write("Holder: ");
                string holder = Console.ReadLine();
                Console.Write("Initial Balance: ");
                double initialBalance = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Withdraw limit: ");
                double withdrawLimit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Account ac = new Account(number, holder, initialBalance, withdrawLimit);

                Console.WriteLine("\n");
                Console.Write("Enter amount for withdraw: ");
                double amount = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                ac.WithDraw(amount);
                Console.WriteLine("New balance: " + ac.Balance.ToString("F2", CultureInfo.InvariantCulture));     
            }

            catch (DomainException e)
            {
                Console.WriteLine(e.Message);
                error = true;
            }

            catch (FormatException e)
            {
                error = true;
                Console.WriteLine(e.Message);
            }

            catch(Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }


        }
    }
}

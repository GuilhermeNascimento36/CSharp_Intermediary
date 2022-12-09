using PagamentoImpostoPFePJ_Console.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace PagamentoImpostoPFePJ_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            fazer um programa para ler os dados de N contribuintes (N fornecido pelo usuário), os quais 
            podem ser pessoa física ou pessoa jurídica, e depois mostrar o valor do imposto pago por cada um, 
            bem como o total de imposto arrecadado. 
            Os dados de pessoa física são: nome, renda anual e gastos com saúde. Os dados de pessoa jurídica 
            são nome, renda anual e número de funcionários. As regras para cálculo de imposto são as 
            seguintes:
            Pessoa física: pessoas cuja renda foi abaixo de 20000.00 pagam 15% de imposto. Pessoas com 
            renda de 20000.00 em diante pagam 25% de imposto. Se a pessoa teve gastos com saúde, 50% 
            destes gastos são abatidos no imposto. 
            Exemplo: uma pessoa cuja renda foi 50000.00 e teve 2000.00 em gastos com saúde, o imposto 
            fica: (50000 * 25%) - (2000 * 50%) = 11500.00
            Pessoa jurídica: pessoas jurídicas pagam 16% de imposto. Porém, se a empresa possuir mais de 10 
            funcionários, ela paga 14% de imposto. 
            Exemplo: uma empresa cuja renda foi 400000.00 e possui 25 funcionários, o imposto fica: 
            400000 * 14% = 56000.00*/

            List<Pessoa> payers = new List<Pessoa>();

            Console.Write("Enter the number of tax payers: ");
            int nPayers = int.Parse(Console.ReadLine());

            for (int i = 1; i <= nPayers; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"Tax payer #{i} data: ");
                char iOrC;
                do
                {
                    Console.Write("Individual or company (i/c)? ");
                    iOrC = char.Parse(Console.ReadLine());
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Annual income: ");
                    double annualIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    switch (iOrC)
                    {
                        case 'i':
                            Console.Write("Health expenditures: ");
                            double helth = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                            payers.Add(new PessoaFisica(name, annualIncome, helth));
                            break;

                        case 'c':
                            Console.Write("Number of employees: ");
                            int number = int.Parse(Console.ReadLine());
                            payers.Add(new PessoaJuridica(name, annualIncome, number));
                            break;

                        default:
                            Console.WriteLine("Wrong option.");
                            break;
                    }

                } while (iOrC != 'i' && iOrC != 'c');
            }

            Console.WriteLine();
            Console.WriteLine("TAXES PAID: ");
            double totalTaxes = 0;

            foreach (Pessoa p in payers)
            {
                Console.WriteLine(p.Name + ": $" + p.CalculateTax().ToString("F2", CultureInfo.InvariantCulture));
                totalTaxes += p.CalculateTax();
            }

            Console.WriteLine();
            Console.WriteLine("TOTAL TAXES: $" + totalTaxes.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}

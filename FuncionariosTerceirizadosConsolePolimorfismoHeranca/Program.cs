using FuncionariosTerceirizadosConsolePolimorfismoHeranca.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace FuncionariosTerceirizadosConsolePolimorfismoHeranca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employeeList = new List<Employee>();

            /*
             *  Uma empresa possui funcionários próprios e terceirizados.
                Para cada funcionário, deseja-se registrar nome, horas
                trabalhadas e valor por hora. Funcionários terceirizados
                possuem ainda uma despesa adicional.

                O pagamento dos funcionários corresponde ao valor da hora
                multiplicado pelas horas trabalhadas, sendo que os
                funcionários terceirizados ainda recebem um bônus
                correspondente a 110% de sua despesa adicional.

                Fazer um programa para ler os dados de N funcionários (N
                fornecido pelo usuário) e armazená-los em uma lista. Depois
                de ler todos os dados, mostrar nome e pagamento de cada
                funcionário na mesma ordem em que foram digitados.
                Construa o programa conforme projeto ao lado.
             */


            Console.Write("Enter the number of employees: ");
            int nEmployees = int.Parse(Console.ReadLine());

            for(int i = 1; i <= nEmployees; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"Employee #{i} data:");
                Console.Write("Outsourced (y/n)? ");
                char outSourcedYN = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string employeeName = Console.ReadLine();
                Console.Write("Hours: ");
                int employeeHours = int.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double employeeValuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if(outSourcedYN == 'Y' || outSourcedYN == 'y')
                {
                    Console.Write("Additional charge: ");
                    double outSourcedEmployeeAddCharge = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    Employee employee = new OutSourcedEmployee(employeeName, employeeHours, employeeValuePerHour, outSourcedEmployeeAddCharge);
                    employeeList.Add(employee);
                }

                else
                {
                    Employee employee = new Employee(employeeName, employeeHours, employeeValuePerHour);
                    employeeList.Add(employee);
                }
            }

            Console.WriteLine();
            Console.WriteLine("PAYMENTS: ");

            foreach(Employee em in employeeList)
            {
                Console.WriteLine(em.Name + " - $" + em.Payment().ToString("F2", CultureInfo.InvariantCulture));
            }
        }
    }
}

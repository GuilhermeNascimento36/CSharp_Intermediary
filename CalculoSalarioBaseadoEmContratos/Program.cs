using CalculoSalarioBaseadoEmContratos.Entities;
using CalculoSalarioBaseadoEmContratos.Entities.Enums;
using System.Globalization;

namespace CalculoSalarioBaseadoEmContratos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter department's name: ");
            string dptName = Console.ReadLine();

            Console.WriteLine("Enter worker data:");
            Console.Write("Name: ");
            string workerName = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level =  Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base salary: ");
            double salary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department department = new ();
            department.Name = dptName;
            Worker worker = new(workerName, level, salary, department);

            Console.WriteLine();
            Console.Write("How many contracts to this worker? ");
            int nContracts = int.Parse(Console.ReadLine());

            for(int i = 1; i <= nContracts; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"Enter #{i} contract data:");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double value = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());

                HourContract contract = new()
                {
                    Hours = hours,
                    Date = date,
                    ValuePerHour = value
                };

                worker.addContract(contract);
            }

            Console.WriteLine();
            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            string dateUser = Console.ReadLine();

            int month = int.Parse(dateUser.Substring(0, 2));
            int year = int.Parse(dateUser.Substring(3));

            Console.WriteLine();

            Console.WriteLine("Name: " + worker.Name);
            Console.WriteLine("Department: " + worker.Department.Name);
            Console.WriteLine("Income for " + dateUser + ": " + worker.income(year, month).ToString("F2", CultureInfo.InvariantCulture));

        }
    }
}
using CalculoSalarioBaseadoEmContratos.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CalculoSalarioBaseadoEmContratos.Entities
{
    internal class Worker
    {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public List <HourContract> Contracts { get; set; } = new List<HourContract> ();


        public Worker() { }
        public Worker(string name, WorkerLevel level, double baseSalary, Department department)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void addContract(HourContract contract)
        {
            Contracts.Add(contract);
        }

        public void removeContract(HourContract contract)
        {
            Contracts.Remove(contract);
        }

        public double income (int year, int month)
        {
            double plusSalary = BaseSalary;

            foreach (HourContract contract in Contracts)
            {
                if(contract.Date.Year == year && contract.Date.Month == month)
                {
                    plusSalary += contract.totalValue();
                }
            }

            return plusSalary;
        }
    }
}

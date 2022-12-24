using SalvarDadosDeVendaEmArquivoTXT_Console.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace SalvarDadosDeVendaEmArquivoTXT_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> prodList = new List<Product>();

            string tempPath = Path.GetTempPath();

            try
            {
                Console.Write("How many items will you buy? ");
                int qtnItems = int.Parse(Console.ReadLine());

                for (int i = 1; i <= qtnItems; i++)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Product #{i}");
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Price: ");
                    double price = double.Parse(Console.ReadLine(), System.Globalization.CultureInfo.InvariantCulture);
                    Console.Write("Quantity: ");
                    int quantity = int.Parse(Console.ReadLine());

                    Product product = new Product(name, quantity, price);
                    prodList.Add(product);
                }

                Directory.CreateDirectory(tempPath + @"\000000AAAA\ProductData");
                string filePath = tempPath + @"\000000AAAA\ProductData\Data.txt";
                FileInfo file = new FileInfo(filePath);
         
                using (StreamWriter sw = File.AppendText(filePath))
                {
                    foreach (Product p in prodList)
                    {
                        sw.WriteLine(p.ToString());
                    }
                }
               
                Console.WriteLine("O arquivo pode ser encontrado no endereço: " + Path.GetFullPath(filePath));
            }
            catch (IOException e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            catch (SystemException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
}

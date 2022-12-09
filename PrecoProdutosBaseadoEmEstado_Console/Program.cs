using System;
using System.Globalization;
using System.Collections.Generic;
using PrecoProdutosBaseadoEmEstado_Console.Entities;

namespace PrecoProdutosBaseadoEmEstado_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> prodList = new List<Product>();

            /*
            Fazer um programa para ler os dados de N
            produtos (N fornecido pelo usuário). Ao final,
            mostrar a etiqueta de preço de cada produto na
            mesma ordem em que foram digitados.

            Todo produto possui nome e preço. Produtos
            importados possuem uma taxa de alfândega, e
            produtos usados possuem data de fabricação.
            Estes dados específicos devem ser
            acrescentados na etiqueta de preço conforme
            exemplo (próxima página).
            
            Para produtos importados, a taxa e 
            alfândega deve ser acrescentada ao preço 
            final do produto.*/

            Console.Write("Enter the number of products: ");
            int nProducts = int.Parse(Console.ReadLine());

            for(int i = 1; i <= nProducts; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"Product #{i} data: ");
                char typeProduct;
                do{
                    Console.Write("Common, used or imported(c/ u / i)?");
                    typeProduct = char.Parse(Console.ReadLine());

                    Console.Write("Name: ");
                    string nameProduct = Console.ReadLine();
                    Console.Write("Price: ");
                    double priceProduct = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    switch (typeProduct)
                    {
                        case 'c':
                            Product prod = new Product(nameProduct, priceProduct);
                            prodList.Add(prod);
                            break;

                        case 'u':
                            Console.Write("Manufacture date (DD/MM/YYYY): ");
                            DateTime manufactureDate = DateTime.Parse(Console.ReadLine());
                            Product uProd = new UsedProduct(nameProduct, priceProduct, manufactureDate);
                            prodList.Add(uProd);
                            break;

                        case 'i':
                            Console.Write("Customs fee: ");
                            double customs = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                            Product iProd = new ImportedProduct(nameProduct, priceProduct, customs);
                            prodList.Add(iProd);
                            break;

                        default:
                            Console.WriteLine("Invalid option to product type.");
                            break;
                    }
                } while (typeProduct != 'c' && typeProduct != 'u' && typeProduct != 'i');
            }

            Console.WriteLine();
            Console.WriteLine("PRICE TAGS: ");

            foreach(Product prod in prodList)
            {
                Console.WriteLine(prod.PriceTag());
            }
        }
    }
}

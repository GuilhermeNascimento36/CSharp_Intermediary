using System;
using System.Globalization;

namespace SalvarDadosDeVendaEmArquivoTXT_Console.Entities
{
    internal class Product
    {
        public string Name { get; private set; }
        public int Quantity { get; set; }
        public double Price { get; private set; }

        public Product(string name, int quantity, double price)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
        }

        public double TotalPrice()
        {
            return Price * Quantity;
        }

        public override string ToString()
        {
            return "PRODUCT DATA" + "\n\nName: " + Name + "\nQuantity: " + Quantity + "\nPrice: " + Price.ToString("F2", CultureInfo.InvariantCulture) + "\n\nTOTAL: "
                + TotalPrice().ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}

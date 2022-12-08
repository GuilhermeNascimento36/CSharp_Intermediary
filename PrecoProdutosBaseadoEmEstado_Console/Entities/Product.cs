using System.Globalization;

namespace PrecoProdutosBaseadoEmEstado_Console.Entities
{
    internal class Product
    {
        public string Name { get; protected set; }
        public double Price { get; protected set; }

        public Product(){}

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public virtual string PriceTag()
        {
            return Name + " $" + Price.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}

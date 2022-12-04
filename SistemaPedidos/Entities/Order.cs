using SistemaPedidos.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SistemaPedidos.Entities
{
    internal class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public Client Client { get; set; }

        //methods
        public Order() { }
        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }

        public double Total()
        {
            double totalOrder = 0;

            foreach (OrderItem item in Items)
            {
                totalOrder += item.SubTotal();
            }

            return totalOrder;
        }
        
        public override string ToString()
        {
            StringBuilder sb =  new StringBuilder();
            sb.AppendLine("ORDER SUMMARY: ");

            sb.Append("Order Moment: ");
            sb.AppendLine(Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.Append("Order Status: ");
            sb.AppendLine(Status.ToString());
            sb.Append("Client: ");
            sb.Append(Client.Name);
            sb.Append(" (" + Client.BirthDate.ToString("dd/MM/yyyy") + ") ");
            sb.AppendLine("- " + Client.Email);
            sb.AppendLine("Order Items: ");
            
            foreach(OrderItem item in Items)
            {
                sb.AppendLine(item.Product.Name + ", " + item.Price.ToString("F2", CultureInfo.InvariantCulture) + ", Quantity: " + item.Quantity + ", Subtotal: $" + item.SubTotal().ToString("F2", CultureInfo.InvariantCulture)); 
            }

            sb.AppendLine(" ");
            sb.AppendLine("Total price: $" + Total().ToString("F2", CultureInfo.InvariantCulture));
            
            return sb.ToString();
        }
    }
}

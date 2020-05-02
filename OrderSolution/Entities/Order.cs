using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using OrderSolution.Entities.Enums;

namespace OrderSolution.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Order()
        {
        }

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
            double sum = 0;

            foreach(OrderItem item in Items)
            {
                sum += item.SubTotal();
            }

            return sum;
        }

        public override string ToString()
        {
            StringBuilder st = new StringBuilder();
            st.AppendLine("ORDER SUMMARY:");
            st.Append("Order moment: ");
            st.AppendLine(Moment.ToString());
            st.Append("Order status: ");
            st.AppendLine(Status.ToString());
            st.Append("Client: ");
            st.AppendLine(Client.ToString());
            st.AppendLine("Order items:");

            foreach(OrderItem item in Items)
            {
                st.AppendLine(item.ToString());
            }

            st.Append("Total price: $");
            st.AppendLine(Total().ToString("F2", CultureInfo.InvariantCulture));

            return st.ToString();
        }
    }
}

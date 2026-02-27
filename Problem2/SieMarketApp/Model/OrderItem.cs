using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SieMarketApplication.Model
{
    //Implementation of the object "OrderItem"
    public class OrderItem
    {
        public int Id {  get; private set; }
        public string ProductName { get;private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }

       public OrderItem(int id, string productName, int quantity, decimal unitPrice)
        {
            this.Id = id;
            this.ProductName = productName;
            this.Quantity = quantity;
            this.UnitPrice = unitPrice;
        }

        public decimal GetTotalPrice()
        {
            return Quantity * UnitPrice;
        }

    }
}

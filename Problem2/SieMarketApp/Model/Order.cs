using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SieMarketApplication.Model
{
    //Implementation of the object "Order"
    public class Order
    {
        public int Id { get; private set; }
        public string CustomerName { get; private set; }
        public DateTime OrderDate {  get;private set; }
        public List<OrderItem> items { get; private set; } = new List<OrderItem>();

        public Order(int id, string customerName, DateTime orderDate, List<OrderItem> items)
        {
            this.Id = id;
            this.CustomerName = customerName;
            this.OrderDate = orderDate;
            this.items = items;
        }
        //Feature 2.2: implement the discount function that applies only when necessary

        //Function: get total price of order before considering a discount
        public decimal GetTotalPrice()
        {
            decimal total = 0;
            foreach(OrderItem orderItem in  items)
            {
                total += orderItem.GetTotalPrice();
            }
            return total;
        }
        //Function: get the sum that should be reduced from the total price, if necessary
        public decimal GetDiscount()
        {
            decimal total = GetTotalPrice();
            if(total>500)
            {
                return total * 0.10m;
            }
            return 0;
        }

        //Function: get the final price of the order
        public decimal GetFinalTotalPrice()
        {
            return GetTotalPrice() - GetDiscount();
        }
    }
}

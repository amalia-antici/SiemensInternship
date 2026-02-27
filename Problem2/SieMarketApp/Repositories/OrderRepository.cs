using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SieMarketApplication.Model;


namespace SieMarketApplication.Repositories
{
    //Repository for Order
    public class OrderRepository
    {
  
        private List<Order> orders = new List<Order>();
        public OrderRepository() { }

        public List<Order> GetOrders() { return orders; }

        public void AddOrder(Order order) { orders.Add(order); }


    }
}

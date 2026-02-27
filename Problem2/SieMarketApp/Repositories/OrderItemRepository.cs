using SieMarketApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SieMarketApplication.Repositories
{
    //Repository for the OrderItems
    public class OrderItemRepository
    {
        private List<OrderItem> orderItems = new List<OrderItem>();

        public OrderItemRepository() { }

        public List<OrderItem> GetOrderItems()
        {
            return orderItems; 
        }
    }
}

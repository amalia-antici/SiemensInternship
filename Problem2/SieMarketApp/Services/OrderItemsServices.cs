using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SieMarketApplication.Repositories;
using SieMarketApplication.Model;

namespace SieMarketApplication.Services
{
    //Services for OrderItems
    public class OrderItemsServices
    {
        private OrderItemRepository Repository;
        private OrderRepository OrderRepository;
        public OrderItemsServices(OrderItemRepository repository, OrderRepository orderRepository)
        {
            this.Repository = repository;
            this.OrderRepository = orderRepository;
        }

        public List<OrderItem> GetOrderItems()
        {
            return Repository.GetOrderItems();
        }

        //Feature 2.4: make a top of the most popular products, holding their name and quantity sold in total
    public Dictionary<string, int> GetMostPopularProducts()
        {
            Dictionary<string, int> popularProducts = new Dictionary<string, int>();
            foreach (Order order in OrderRepository.GetOrders())
            {
                foreach (OrderItem orderItem in order.items)
                {
                    if (popularProducts.ContainsKey(orderItem.ProductName))
                    {
                        popularProducts[orderItem.ProductName]+=orderItem.Quantity;
                    }
                    else
                    {
                        popularProducts.Add(orderItem.ProductName, orderItem.Quantity);
                    }
                }
            }
            return popularProducts.OrderByDescending(p => p.Value).ToDictionary(p => p.Key, p => p.Value);
        }
    }
}

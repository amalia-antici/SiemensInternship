using System.Collections.Generic;
using SieMarketApplication.Repositories;
using SieMarketApplication.Model;

namespace SieMarketApplication.Services
{
    public class OrderServices
    {
        //Services for Orders
        private OrderRepository Repository;
        public OrderServices(OrderRepository Repository)
        {
            this.Repository = Repository;
        }

        public List<Order> GetOrders()
        {
            return Repository.GetOrders();
        }

        //Feature 2.3: find the biggest spender customer

        //Function: find the total amount spend per customer
        public decimal GetTotalPriceOfOrdersPerCustomer(string CustomerName)
        {
            decimal total=0;
            foreach (Order order in GetOrders())
            {
                if (order.CustomerName==CustomerName)
                {
                    total += order.GetFinalTotalPrice();
                }
            }
            return total;
        }

        //Function: collect the names of the customers only once
        private List<string> CollectCustomersNames()
        {
            List<string> customersNames = new List<string>();
            foreach (Order order in Repository.GetOrders())
            {
                if (!customersNames.Contains(order.CustomerName))
                {
                    customersNames.Add(order.CustomerName);
                }
            }
            return customersNames;
                  
        }

        //Function: return the name of the customer who spend the most
        public string GetNameOfBiggestSpender()
        {
            string name="";
            decimal total=0;
            List<string> customersNames = CollectCustomersNames();
            foreach(string Cname in customersNames)
            {
                decimal localTotal = GetTotalPriceOfOrdersPerCustomer(Cname);
                if(localTotal>total)
                {
                    total=localTotal;
                    name=Cname;
                }
                
            }
            return name;
        }
    }

}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using SieMarketApplication.Model;
using SieMarketApplication.Repositories;
using SieMarketApplication.Services;

namespace SieMarketApplication.Tests
{
    [TestClass]
    public class TestFeatures
    {
        //Testing feature 2.2: check if the discount is applied only when necessary
        [TestMethod]
        public void TestDiscount()
        {
            Order o1 = new Order(1, "Amalia", DateTime.Now, new List<OrderItem>());
            o1.items.Add(new OrderItem(1, "Toaster", 1, 300));

            Order o2 = new Order(2, "George", DateTime.Now, new List<OrderItem>());
            o2.items.Add(new OrderItem(3, "Headphones", 2, 150));
            o2.items.Add(new OrderItem(4, "Smartwatch", 1, 800));

            //o1 should not get a discount, the price stays 300
            //o2 should get a discount, the price in the end shuld be 0.9*(150*2+800)=990
            Assert.AreEqual(300, o1.GetFinalTotalPrice());
            Assert.AreEqual(990, o2.GetFinalTotalPrice());

        }


        [TestMethod]
        //Testing feature 2.3: check if the biggest spender is found corectly
        public void TestBiggestSpender()
        {
            OrderRepository orderRepository = new OrderRepository();
            OrderServices orderServices=new OrderServices(orderRepository);

            OrderItemRepository orderItemRepository = new OrderItemRepository();
            OrderItemsServices orderItemsServices=new OrderItemsServices(orderItemRepository,orderRepository);

            Order o1 = new Order(1, "Amalia", DateTime.Now, new List<OrderItem>());
            o1.items.Add(new OrderItem(1, "Toaster", 1, 300));

            Order o2 = new Order(2, "George", DateTime.Now, new List<OrderItem>());
            o2.items.Add(new OrderItem(2,"Laptop", 1, 1100));

            Order o3 = new Order(3, "Amalia", DateTime.Now, new List<OrderItem>());
            o3.items.Add(new OrderItem(3, "Headphones", 2, 150));
            o3.items.Add(new OrderItem(4, "Smartwatch", 1, 800));

            orderRepository.AddOrder(o1);
            orderRepository.AddOrder(o2);
            orderRepository.AddOrder(o3);
            //Customer Amalia has a total of 1290 spend, while George spend a total of 990
            string result = orderServices.GetNameOfBiggestSpender();

            Assert.AreEqual("Amalia", result);
        }

        //Testing feature 2.4: check if the top of the most popular products is computed corectly
        [TestMethod]
        public void TestPopularProduct()
        {
            OrderRepository orderRepository = new OrderRepository();
            OrderServices orderServices = new OrderServices(orderRepository);

            OrderItemRepository orderItemRepository = new OrderItemRepository();
            OrderItemsServices orderItemsServices = new OrderItemsServices(orderItemRepository, orderRepository);

            Order o1 = new Order(1, "Delia", DateTime.Now, new List<OrderItem>());
            o1.items.Add(new OrderItem(1, "Cooler", 2, 300));

            Order o2 = new Order(2, "George", DateTime.Now, new List<OrderItem>());
            o2.items.Add(new OrderItem(2, "Laptop", 1, 1100));

            Order o3 = new Order(3, "Amalia", DateTime.Now, new List<OrderItem>());
            o3.items.Add(new OrderItem(3, "Laptop", 2, 1100));
            o3.items.Add(new OrderItem(4, "Smartwatch", 1, 800));

            orderRepository.AddOrder(o1);
            orderRepository.AddOrder(o2);
            orderRepository.AddOrder(o3);

            Dictionary<string, int> result = orderItemsServices.GetMostPopularProducts();

            //The most popular product should be "Laptop",  with 3 units sold
            //Therefore comes the product "Cooler" (with 2 units sold), and "Smartwatch", with one unit sold
            //That being said, the "Laptop" should be first in the result
            Assert.AreEqual("Laptop", result.First().Key);
            Assert.AreEqual( 3, result["Laptop"]);
            Assert.AreEqual(2, result["Cooler"]);

        }
    }
}

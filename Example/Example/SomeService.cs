using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Context;
using DAL.Entities;

namespace Example
{
    public class SomeService
    {
        public void DoSmth()
        {
            using (var context = new AppDbContext())
            {
                var customers = context.Customers.ToList();

                PrintCustomers(customers);

                Console.WriteLine();
            }

            Console.ReadLine();
        }

        private void PrintCustomers(IEnumerable<Customer> customers)
        {
            Console.WriteLine($"Customers number: {customers.Count()}");

            foreach (var customer in customers)
            {
                Console.WriteLine($"{customer.Id} - {customer.Name} - {customer.Address}");
                PrintOrders(customer.Orders);
            }
        }

        private void PrintOrders(IEnumerable<Order> orders)
        {
            Console.WriteLine($"Orders number: {orders.Count()}");

            using (var context = new AppDbContext())
            {
                var items = context.Items.ToList();

                foreach (var order in orders)
                {
                    Console.WriteLine($"Order ID {order.Id} - {order.Date}");

                    var currentItems = items.Where(oi => oi.OrderItems.Any(o => o.OrderId == order.Id)).ToList();


                    PrintItems(currentItems);
                }

                Console.WriteLine("------------------------------------");
                Console.WriteLine();
            }
        }

        private void PrintItems(IEnumerable<Item> items)
        {
            Console.WriteLine($"Items number: {items.Count()}");

            foreach (var item in items)
            {
                Console.WriteLine($"{item.Id} - {item.Description} - {item.Price}");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LazyT
{
  /// <summary>
  /// Example program for Lazy<t> and auto-implemented properties with factory methods.
  /// </summary>
  class Program
  {
    static void Main(string[] args)
    {

      Dictionary<String, Customer> olCustomers = new Dictionary<string, Customer>();
      olCustomers.Add("1", Customer.CreateCustomer("1", "Mike"));
      olCustomers.Add("2", Customer.CreateCustomer("2", "James"));
      olCustomers.Add("3", Customer.CreateCustomer("3", "Ian"));
      olCustomers.Add("4", Customer.CreateCustomer("4", "Fred"));
      olCustomers.Add("5", Customer.CreateCustomer("5", "Sean"));

      do
      {
        Console.WriteLine("Enter customer number 1 through {0} to view orders:", olCustomers.Count);

        String slCustomer = Console.ReadLine();
        if (!olCustomers.ContainsKey(slCustomer))
          return;

        DisplayOrders(olCustomers[slCustomer]);

      } while (true);

    }

    static void DisplayOrders(Customer ovCustomer)
    {
      // Here is where the progam will actually instantiate a new order class and put the orders
      // into memory for us to read.
      Orders olCustomerOrders = ovCustomer.CustomerOrders;

      // Variable to track the sum of the variables
      Double dvTotalPrice = 0;

      // Loop through the Dictionary of Order Numbers and Amounts
      foreach (KeyValuePair<Int32, Double> olOrder in olCustomerOrders.DetailOrders)
      {
        Double dvPrice = olOrder.Value;
        dvTotalPrice += dvPrice;

        Console.WriteLine("{0}'s order number {1} amount is {2}", ovCustomer.CustomerName, olOrder.Key.ToString("000"), dvPrice.ToString("#0.00"));
      }

      Console.WriteLine("Total Price for {0} is {1}.", ovCustomer.CustomerName, dvTotalPrice.ToString("#0.00"));

    }
  }
}

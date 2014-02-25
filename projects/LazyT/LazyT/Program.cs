using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LazyT
{
  class Program
  {
    static void Main(string[] args)
    {
      Customer olCustomer = Customer.CreateCustomer("1", "Customer1");

      Orders olCustomerOrders = olCustomer.CustomerOrders;

      foreach (KeyValuePair<Int32, Double> olOrder in olCustomerOrders.DetailOrders)
      {

        Console.WriteLine("Order {0} order price is {1}", olOrder.Key, olOrder.Value.ToString("#.00"));
      }

      Console.ReadLine();

    }
  }
}

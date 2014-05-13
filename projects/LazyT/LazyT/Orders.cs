using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LazyT
{
  class Orders
  {

    private Dictionary<Int32, Double> omCustomerOrders;

    public string CustomerID { get; private set; }

    private Orders(String svCustomerID)
    {
      CustomerID = svCustomerID;
      zzRetriveOrders();
    }

    public static Orders QueryCustomerOrders(String svCustomerID)
    {
      return new Orders(svCustomerID);
    }

    public Dictionary<Int32, Double> DetailOrders
    {
      get
      {
        return omCustomerOrders;
      }
    }

    private void zzRetriveOrders()
    {
      try
      {
        omCustomerOrders = new Dictionary<Int32, Double>();

        Random olRandom = new Random();

        for (Int32 ili = 1; ili <= 100; ili++)
        {
          Double dlRandomNumber = olRandom.NextDouble() * 100;
          omCustomerOrders.Add(ili, dlRandomNumber);
        }
      }
      catch (Exception)
      {

        throw;
      }
    }
  }
}

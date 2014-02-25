using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LazyT
{
  class Orders
  {

    public string CustomerID { get; private set; }

    private Orders(String svCustomerID)
    {
      CustomerID = svCustomerID;
    }

    public static Orders QueryCustomerOrders(String svCustomerID)
    {
      return new Orders(svCustomerID);
    }

    public Dictionary<Int32, Double> DetailOrders
    {
      get
      {
        Dictionary<Int32, Double> olOrders = new Dictionary<Int32, Double>();
        olOrders.Add(1, 10.00);
        olOrders.Add(2, 12.95);
        olOrders.Add(3, 15.00);

        return olOrders;
      }
    }
  }
}

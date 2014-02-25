using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LazyT
{
  class Customer
  {
    // Lazy initialization of an object means that its creation is deferred until it is first used. (For this topic, the terms lazy initialization and lazy instantiation are synonymous.) Lazy initialization is primarily used to improve performance, avoid wasteful computation, and reduce program memory requirements. These are the most common scenarios:

    //    •  When you have an object that is expensive to create, and the program might not use it. For example, assume that you have in memory a Customer object that has an Orders property that contains a large array of Order objects that, to be initialized, requires a database connection. If the user never asks to display the Orders or use the data in a computation, then there is no reason to use system memory or computing cycles to create it. By using Lazy<Orders> to declare the Orders object for lazy initialization, you can avoid wasting system resources when the object is not used.
    
    //    •  When you have an object that is expensive to create, and you want to defer its creation until after other expensive operations have been completed. For example, assume that your program loads several object instances when it starts, but only some of them are required immediately. You can improve the startup performance of the program by deferring initialization of the objects that are not required until the required objects have been created. 

    //Although you can write your own code to perform lazy initialization, we recommend that you use Lazy<T> instead. Lazy<T> and its related types also support thread-safety and provide a consistent exception propagation policy.

    // In the following example, assume that Orders is a class that contains an array of Order objects retrieved from a database. A Customer object contains an instance of Orders, but depending on user actions, the data from the Orders object might not be required.

    // Initialize by using default Lazy<T> constructor. The 
    // Orders array itself is not created yet.
    Lazy<Orders> omOrders;

    // Private constructor.
    private Customer(String svCustomerID,
                     String svCustomerName)
    {
      CustomerID = svCustomerID;
      CustomerName = svCustomerName;
      omOrders = new Lazy<Orders>(() =>
        {
          // The order class is not instanciated until the method "CustomerOrders" is called
          // This will return the object
          return Orders.QueryCustomerOrders(CustomerID);
        });
    }

    // Public factory method.
    public static Customer CreateCustomer(String svCustomerID,
                                          String svCustomerName)
    {
      return new Customer(svCustomerID, svCustomerName);
    }

    // In C# 3.0 and later, auto-implemented properties make property-declaration 
    // more concise when no additional logic is required in the property accessors. 
    // They also enable client code to create objects. When you declare a property 
    // as shown in the following example, the compiler creates a private, anonymous 
    // backing field that can only be accessed through the property's get and set accessors.

    // Use auto-implementation than exposing members directly is that if you ever change a 
    // field to a property, you need to recompile every assembly referencing that one. If you
    // add implementation to an auto-implemented property, you don't need to recompile them.

    // Auto-Impl Properties for trivial get and set
    public String CustomerName { get; set; }

    // You make the class immutable by declaring the set accessors as private. However, 
    // when you declare a private set accessor, you cannot use an object initializer to 
    // initialize the property. You must use a constructor or a factory method.
    public String CustomerID { get; private set; }

    public Orders CustomerOrders
    {
      get
      {
        // Orders is created on first access here.
        return omOrders.Value;
      }
    }
  }
}

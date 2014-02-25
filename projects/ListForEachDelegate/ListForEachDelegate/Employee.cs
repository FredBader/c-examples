using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListForEachDelegate
{
  class Employee
  {

    // In C# 3.0 and later, auto-implemented properties make property-declaration 
    // more concise when no additional logic is required in the property accessors. 
    // They also enable client code to create objects. When you declare a property 
    // as shown in the following example, the compiler creates a private, anonymous 
    // backing field that can only be accessed through the property's get and set accessors.

    // Use auto-implementation than exposing members directly is that if you ever change a 
    // field to a property, you need to recompile every assembly referencing that one. If you
    // add implementation to an auto-implemented property, you don't need to recompile them.

    // Auto-Impl Properties for trivial get and set
    public String Name { get; set; }
    public Int32 PayType { get; set; }
    public Double Rate { get; set; }

    public Employee(String svName,
                    Int32 ivPayType,
                    Double drRate)
    {
      Name = svName;
      PayType = ivPayType;
      Rate = drRate;
    }
    ~Employee() { }
  }

  class Employee2
  {

    // You make the class immutable by declaring the set accessors as private. However, 
    // when you declare a private set accessor, you cannot use an object initializer to 
    // initialize the property. You must use a constructor or a factory method.
    public String Name { get; private set; }
    public Int32 PayType { get; private set; }
    public Double Rate { get; private set; }

    // Private constructor.
    private Employee2(String svName,
                     Int32 ivPayType,
                     Double drRate)
    {
      Name = svName;
      PayType = ivPayType;
      Rate = drRate;
    }
    ~Employee2() { }

    // Public factory method. 
    public static Employee2 CreateEmployee(string svName, Int32 ivPayType, Double dvRate)
    {
      dvRate *= 2;
      return new Employee2(svName, ivPayType, dvRate);
    }
  }
}

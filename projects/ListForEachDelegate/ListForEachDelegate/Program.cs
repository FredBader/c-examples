using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListForEachDelegate
{
  class Program
  {

    public enum EmployeeType { Owner = 1, Salary = 2, Hourly = 3 };
    static public Double totalPay;

    // svaNames = Heather Jessica Kathy Susan
    static void Main(string[] svaNames)
    {

      //// List of other people
      //List<String> sllNames = new List<String> { "Fred", "Mike", "Ian", "Sean", "Nate", "James" };

      //// Add the command line array of names to the Names List
      //sllNames.AddRange(svaNames);

      //// Display the names in the list using the DisplayName method.
      //// The parameter for the ForEach is an System.Action<T> Delegate
      //// The System.Action<T> delegate encapsulates a method that has a single parameter and does not return a value.
      //// System.Action<T> can take up to 16 parameters
      //sllNames.ForEach(DisplayName);
      //// Results in printing the follow printed in the console:
      //// Fred
      //// Mike
      //// Ian
      //// Sean
      //// Nate
      //// James
      //// Heather
      //// Jessica
      //// Kathy
      //// Susan

      //// ReadLine to prevent the console from closing until the enter key is pressed
      //Console.ReadLine();

      List<Employee> olEmployees = new List<Employee>();

      olEmployees.Add(new Employee("Employee 1", Convert.ToInt32(EmployeeType.Hourly), 25.00));
      olEmployees.Add(new Employee("Employee 2", Convert.ToInt32(EmployeeType.Salary), 750.00));
      olEmployees.Add(new Employee("Employee 3", Convert.ToInt32(EmployeeType.Owner), 10000));

      olEmployees.ForEach(DisplayEmployeePay);

      Console.ReadLine();
    }

    public static void DisplayEmployeePay(Employee employee)
    {

      Action<Employee> DisplayEmployeePayEx;

      switch (employee.PayType)
      {
        case 1:
          DisplayEmployeePayEx = DisplayOwnerPay;
          break;
        case 2:
          DisplayEmployeePayEx = DisplaySalaryPay;
          break;
        default:
          DisplayEmployeePayEx = DisplayHoulryPay;
          break;
      }

      DisplayEmployeePayEx(employee);
    }

    public static void DisplayOwnerPay(Employee Owner)
    {
      Console.WriteLine("{0} makes {1} a month.", Owner.Name, Owner.Rate);
      totalPay += Owner.Rate;
    }

    public static void DisplaySalaryPay(Employee Salary)
    {
      Double dlRate = Salary.Rate * 4.2;
      Console.WriteLine("{0} makes {1} a month.", Salary.Name, dlRate);
    }

    public static void DisplayHoulryPay(Employee Hourly)
    {
      Double dlRate = Hourly.Rate * 40 * 4.2;
      Console.WriteLine("{0} makes {1} a month.", Hourly.Name, dlRate);
    }
  }
}

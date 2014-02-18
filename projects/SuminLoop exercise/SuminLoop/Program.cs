using System;
using System.Collections.Generic;

namespace SuminLoop
{
  class Program
  {

    // Count for the number of times the user entered a value
    private static Int32 imiN = 0;

    // This holds the values entered by the user
    private static List<Int32> omNumbersToAdd = new List<int>();

    static void Main(string[] args)
    {
      
      do
      {
        // Prompt user for the values
      } while (zzGetConsoleValue() != 1);

      // Get the summed amount of value
      Int32 llValue = zzGetSummedAmount();

      // -1 indicates an error with the zzGetSummedAmount.  Stop here
      if (llValue == -1)
      {
        Console.ReadLine();
        return;
      }

      // Report the summed values
      Console.WriteLine("The summed amount is {0}, press any key to quit.", llValue);

      // Read line so the console doesn't close
      Console.ReadLine();
    }

    /// <summary>
    /// Returns the value of the summed numbers entered by the user
    /// </summary>
    /// <returns></returns>
    private static Int32 zzGetSummedAmount()
    {
      try
      {
        // The result of the summed amounts
        Int32 vlSummedAmount = 0;

        //Loop through the list and add the numbers together
        for (Int32 ili = 0; ili < omNumbersToAdd.Count; ili++)
        {
          vlSummedAmount = vlSummedAmount + omNumbersToAdd[ili];
        }

        // Return the value
        return vlSummedAmount;
      }
      catch (Exception)
      {

        return zzReportError();
      }
    }

    /// <summary>
    /// Prompts a user for a value to sum up.
    /// </summary>
    /// <returns>0 to prompt for another value, 1 to sum the value and -1 if an error occured</returns>
    private static Int32 zzGetConsoleValue()
    {
      try
      {
        // Prompt the user to enter a value or S to sum up the values
        Console.WriteLine("Please enter an integer value to sum or press \"S\" to sum the values.");
        String svValue = Console.ReadLine();
        if (svValue == "S")
        {
          // Check to make sure there is 2 or more values 
          if (imiN < 2)
          {
            Console.WriteLine("Please enter 2 or more numbers.");

            // a value of 0 tells the calling routine to prompt for more numbers
            return 0;
          }

          // A value of 1 indicates to sum the amounts
          return 1;
        }

        // Cast the value to an Int32 and add to list
        omNumbersToAdd.Add(Convert.ToInt32(svValue));

        // Increment the number of times the user entered a value
        imiN++;

        return 0;
      }
      // This exception occurs if the value is not an Int32
      catch (FormatException)
      {
        Console.WriteLine("Value was not an Integer.");
        return 0;
      }
      // This exception occurs if the value is bigger than an Int
      catch (OverflowException)
      {
        Console.WriteLine("Value is to big.");
        return 0;
      }
      // Generic exception occurred
      catch (Exception)
      {
        return zzReportError();
      }
    }

    /// <summary>
    /// Tells the user there was an error and returns -1
    /// </summary>
    /// <returns></returns>
    private static Int32 zzReportError()
    {
      Console.WriteLine("An error has occurred with this program. Please enter another value.");
      return -1;
    }
  }
}

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

    // The resulting summed amount
    private static Int32 imResult = 0;

    static void Main(string[] args)
    {
      
      do
      {
        // Prompt user for the values
      } while (zzGetConsoleValue() != 1);
      
      // -1 indicates an error with the zzGetSummedAmount.  Stop here
      if (zzGetSummedAmount() == -1)
      {
        Console.ReadLine();
        return;
      }

      // Report the summed values
      Console.WriteLine("The summed amount is {0}, press any key to quit.", imResult);

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
        
        omNumbersToAdd.ForEach(zzSumAmount);

        return 0;
      }
      catch (Exception)
      {

        return zzReportError();
      }
    }

    private static void zzSumAmount(Int32 ivValue)
    {
      try
      {
        imResult += ivValue;
      }
      catch (Exception)
      {
        throw;
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

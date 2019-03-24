using System;
using System.Collections.Generic;
using System.Globalization;

namespace CurrencyFormatConverter
{
    class Program
    {
        static void Main(string[] args)
        {

            var amount = new List<float>(2);
            float total = 0, lowestAmount = float.PositiveInfinity, highestAmount = 0;
            int totalAmountOfInputs = 3;

            //Font was changed to accomodate for the different currency symbols
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("This program takes " + totalAmountOfInputs + " dollar amounts and outputs the average, the lowest amount and the highest amount. " +
                "\nIt will then display the total formatted in US, Japanese, Swedish and Thai currencies.\n");

            for (int i = 0; i < totalAmountOfInputs; ++i)
            {
                amount.Add(getDollarAmount(i));
                total += amount[i];
                if (amount[i] > highestAmount)
                {
                    highestAmount = amount[i];
                }
                if (amount[i] < lowestAmount)
                {
                    lowestAmount = amount[i];
                }

            }

            Console.WriteLine("\nAverage........... {0}", (total / totalAmountOfInputs).ToString("c2"));
            Console.WriteLine("Lowest Amount..... {0}", lowestAmount.ToString("c2"));
            Console.WriteLine("Highest Amount.... {0}", highestAmount.ToString("c2"));
            Console.WriteLine("Total in USD...... {0}", total.ToString("c2", CultureInfo.CreateSpecificCulture("en-US")));
            Console.WriteLine("Total in JPY...... {0}", total.ToString("c0", CultureInfo.CreateSpecificCulture("ja-JP")));
            Console.WriteLine("Total in kr........{0}", total.ToString("c2", CultureInfo.CreateSpecificCulture("sv-SE")));
            Console.WriteLine("Total in THB...... {0}\n", total.ToString("c2", CultureInfo.CreateSpecificCulture("th-TH")));
        }

        private static float getDollarAmount(int number)
        {
            bool allGood = false, success = false;
            string userInput;
            float amount;

            do
            {
                Console.Write("Please input dollar amount # " + (number + 1) + ": ");
                userInput = Console.ReadLine();
                success = float.TryParse(userInput, NumberStyles.Currency | NumberStyles.AllowCurrencySymbol, CultureInfo.CurrentCulture, out amount);
                if (!success)
                {
                    Console.WriteLine("Invalid input detected. Please try again.");
                    allGood = false;
                }
                else
                {
                    allGood = true;
                }
            } while (allGood == false);

            return amount;
        }


    }
}

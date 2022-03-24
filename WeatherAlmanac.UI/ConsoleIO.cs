using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAlmanac.UI
{
    public class ConsoleIO
    {
        public void Display(string message)
        {
            Console.WriteLine(message);
        }
        
        public int GetInt(string prompt, int upperLimit, int lowerLimit)
        {
            int value;

            while (true)
            {
                Console.Write(prompt);

                string input = Console.ReadLine();

                if (int.TryParse(input, out value))
                {
                    if(value > lowerLimit && value <= upperLimit)
                    {
                        return value;
                    }
                    else
                    {
                        Console.WriteLine("Not an option.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            }
        }
        public decimal GetDecimal(string prompt)
        {
            decimal value;

            while (true)
            {
                Console.Write(prompt);

                string input = Console.ReadLine();

                if (decimal.TryParse(input, out value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            }
        }
        public decimal GetDecimalOrNull(string prompt)
        {
            decimal value;

            while (true)
            {
                Console.Write(prompt);

                string input = Console.ReadLine();

                if (decimal.TryParse(input, out value))
                {
                    return value;
                }
                else 
                {
                    return -1;
                }
            }
        }
        public void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Display(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public string PromptUser(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }
        public DateTime PromptForDate(string prompt)
        {

            DateTime date;

            while (true)
            {
                Console.Write(prompt);

                string input = Console.ReadLine();

                if (DateTime.TryParse(input, out date))
                {
                    return date;
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            }
        }
        public void PromptToContinue()
        {
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}

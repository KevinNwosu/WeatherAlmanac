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

                if (int.TryParse(Console.ReadLine(), out value))
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
    }
}

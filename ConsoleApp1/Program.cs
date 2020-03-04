using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Please enter a positive integer");
                String input = Console.ReadLine();
                int number = int.Parse(input);
                if (number <= 0)
                {
                    throw new Exception();
                }
                string output = GetPrimeFactor(number);
                Console.WriteLine(output);
             
            }
            catch (FormatException)
            {
                Console.WriteLine("Input is not a number.");
                return;
            }
            catch (Exception)
            {
                Console.WriteLine("input is not a positive integer");
                return;
            }
        }

        static String GetPrimeFactor(int num)
        {
            String result="";
            int prime = 2;
            while (num != 1)
            {
                if (num % prime == 0)
                {
                    num /= prime;
                    result =result+prime+" ";
                }
                else
                {
                    prime++;
                }
            }
            return result;
        }
    }
}

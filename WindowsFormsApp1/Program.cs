using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    using System;

    namespace Calculator
    {
        class Program
        {
            static void Main(string[] args)
            {
               
                int num1 = 0; int num2 = 0;

                Console.WriteLine("输入一个数字，然后按下“enter”");
                num1 = Convert.ToInt32(Console.ReadLine());

                
                Console.WriteLine("输入第二个数字,然后按下“enter”");
                num2 = Convert.ToInt32(Console.ReadLine());

                
                Console.WriteLine("选择一个运算符号");
                Console.WriteLine("+");
                Console.WriteLine("-");
                Console.WriteLine("*");
                Console.WriteLine("\\");
                Console.Write("你的选择是？");

               
                switch (Console.ReadLine())
                {
                    case "a":
                        Console.WriteLine($"你的结果是: {num1} + {num2} = " + (num1 + num2));
                        break;
                    case "s":
                        Console.WriteLine($"你的结果是: {num1} - {num2} = " + (num1 - num2));
                        break;
                    case "m":
                        Console.WriteLine($"你的结果是: {num1} * {num2} = " + (num1 * num2));
                        break;
                    case "d":
                        Console.WriteLine($"你的结果是: {num1} / {num2} = " + (num1 / num2));
                        break;
                }
                
               
            }
        }
    }
}

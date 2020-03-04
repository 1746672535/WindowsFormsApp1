using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("用埃式筛法求2~n之间的素数");
            Console.WriteLine("请输入一个正整数n");
            try
            {
                int input = int.Parse(Console.ReadLine());
                int count = 0;
                if (input <= 1)
                {
                    throw new Exception();
                }
                int[] result;
                EgyptianAlgorithm(input, out result);
                Console.WriteLine("其中所有的素数依次为：");
                while (count<=input&&result[count]!=0)
                {
                    Console.Write(result[count] + " ");
                    count++;
                }

                string x = Console.ReadLine();
            }
            catch (FormatException)
            {
                Console.WriteLine("输入不为数字");
                return;
            }
            catch (Exception)
            {
                Console.WriteLine("输入的数不是正整数");
                return;
            }
        }


        static void EgyptianAlgorithm(int number,out int [] result)
        {
            int[] prime = new int[number+1];
            bool[] numFlag = new bool[number+1];
            int k = 0;
            for (int i = 2; i <= number; i++)
            {
                numFlag[i] = true;
            }
            for (int j = 2; j * j < number; j++)
            {
                for (int i =j; i <= number ; i += j)
                {
                    numFlag[i] = false;
                }

            }
            for (int i = 2; i <= number; i++)
            {

                if (numFlag[i])
                {
                    prime[k] = i;
                        k++;
                }

            }
            result = prime;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int []array = { 13, 25, 49, 36, 28, 91, 63, 99 };
            calculate(array, out int maxNumber, out int minNumber, out int Sum);
            Console.WriteLine("该数组的最大值为：" + maxNumber + " 最小值为:" + minNumber + " 平均值为：" + (Sum / array.Length) + " 总和为：" + Sum);
            
        }
        static void calculate(int []array , out int maxNumber,out int minNumber,out int Sum)
        {
            int max=0, min=int.MaxValue, sum=0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
                max = array[i] >= max ? array[i] : max;
                min = array[i] <= min ? array[i] : min;
            }
            maxNumber = max;
            minNumber = min;
            Sum = sum;
        }
    }


}

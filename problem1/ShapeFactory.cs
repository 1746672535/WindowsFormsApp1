using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem1
{
    public class ShapeFactory
    {
        public static Shape CreateShape(int type)
        {
            Shape shape = null;
            Random rd = new Random();
            switch (type)
            {
                case 1:
                    do
                    {
                        shape = new Rectangle(rd.NextDouble()*rd.Next(1,10), rd.NextDouble() * rd.Next(1, 10));
                    } while (!shape.IsValid);
                    break;
                case 2:
                    do
                    {
                        shape = new Square(rd.NextDouble() * rd.Next(1, 10));
                    } while (!shape.IsValid);
                    break;
                case 3:
                    do
                    {
                        shape = new Triangle(rd.NextDouble() * rd.Next(1, 10), rd.NextDouble() * rd.Next(1, 10), rd.NextDouble() * rd.Next(1, 10));
                    } while (!shape.IsValid);
                    break;
                default:break;

            }
            return shape;
        }
    }
    public class test
    {
        static void Main(string[] args)
        {
            Shape[] shapeProduct = new Shape[10];
            Random rd = new Random();
            double totalArea=0;
            for (int k=0;k<10;k++)
            {
                shapeProduct[k] = ShapeFactory.CreateShape(rd.Next(1, 4));
                totalArea += shapeProduct[k].GetArea();
            }
            Console.WriteLine("总面积为" + totalArea);
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem1
{

    public class Triangle : Shape
    {
        private double sideA;
        private double sideB;
        private double sideC;
        public double SideA
        {
            get => sideA;
            set
            {
                try
                {
                    if (value > 0)
                        sideA = value;
                    else
                        throw new Exception();
                }
                catch (Exception)
                {
                    isValid = false;
                    
                }
            }
        }
        public double SideB
        {
            get => sideA;
            set
            {
                try
                {
                    if (value > 0)
                        sideA = value;
                    else
                        throw new Exception();
                }
                catch (Exception)
                {
                    isValid = false;
                   
                }
            }
        }
        public double SideC
        {
            get => sideA;
            set
            {
                try
                {
                    if (value > 0)
                        sideA = value;
                    else
                        throw new Exception();
                }
                catch (Exception)
                {
                    isValid = false;
                   
                }
            }
        }
        public Triangle(double sideA,double sideB,double sideC)
        {
            this.SideA = sideA;this.SideB = sideB;this.SideC = sideC;
            if (SideA >= SideB + SideC || SideB >= SideA + SideC || SideC >= SideB + SideA)
                IsValid = false;
        }
        public override double GetArea()
        {
            double p = (SideA + SideB + SideC) / 2;
            return Math.Sqrt(p *(p - SideA)*(p - SideB)*(p - SideC));
        }
    }
      


}

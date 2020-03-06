using System;

namespace problem1
{
    class Square : Shape
    {
        private double side;
        public double Side
        {
            get => side;
            set
            {
                try
                {
                    if (value > 0)
                        side = value;
                    else
                        throw new Exception();
                }
                catch (Exception)
                {
                    isValid = false;
                   
                }
            }
        }
        public Square(double side)
        {
            this.Side = side;
        }
        public override double GetArea()
        {
            return this.Side * this.Side;
        }
    }
      


}

using System;

namespace problem1
{
    public class Rectangle : Shape
    {
        private double width;
        private double height;
        public double Width
        {
            get => width;

            set {
                try
                {
                    if (value > 0)
                        width = value;
                    else
                        throw new Exception();
                }
                catch (Exception)
                {
                    isValid = false;
                   
                }
            }
        }
        public double Height
        {
            get => height;

            set
            {
                try
                {
                    if (value > 0)
                        height = value;
                    else
                        throw new Exception();
                }
                catch (Exception)
                {
                    isValid = false;
                    
                }
            }
        }
        public Rectangle(double initWidth, double initHeight)
        {
            this.Width = initWidth;
            this.Height = initHeight;
        }
        public override double GetArea()
        {
            return width * Height;
        }
    }
      


}

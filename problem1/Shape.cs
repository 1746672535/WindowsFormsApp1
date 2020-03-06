namespace problem1
{
    public abstract class Shape
    {
        protected bool isValid = true;
        public bool IsValid { get => isValid; set => isValid = value; }
        public abstract double GetArea();
        
    }
      


}

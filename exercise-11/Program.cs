using System;

namespace exercise_11
{
   static class Program
    {
        public static bool IsOdd(this int value)
        {
            if (value % 2 == 0)
                return false;
            return true;
        }

        public static bool IsEven(this int value)
        {
            if (value % 2 == 0)
                return true;
            return false;
        }

        public static bool IsPrime(this int value)
        {
            for(int i=2;i<=Math.Sqrt(value);i++)
            {
                if (value % 2 == 0)
                    return false;
                
            }
            return true;
        }

        public static bool IsDivisibleBy(this int value1, int value2)
        {
            try
            {
                if (value1 % value2 == 0)
                    return true;
            }
            catch
            {
                Console.WriteLine("Exception occured");
            }
            return false;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter 1 to perform IsOdd method");
            Console.WriteLine("Enter 2 to perform IsEven Method");
            Console.WriteLine("Enter 3 to perform IsPrime Method");
            Console.WriteLine("Enter 4 to perform IsDivisibleBy method");
            if(!int.TryParse(Console.ReadLine(), out int choice))

            {
                Console.WriteLine("Enter choice from above only");
            }

            else
            {
                int value;
                switch(choice)
                {

                    case 1:
                        Console.WriteLine("Enter the value");
                        if(int.TryParse(Console.ReadLine(), out  value))
                        {
                            Console.WriteLine("The value {0} after IsOdd operation is {1}", value, value.IsOdd());
                        }
                        else Console.WriteLine("Enter the correct value");
                        break;

                    case 2:
                        Console.WriteLine("Enter the value");
                        if (int.TryParse(Console.ReadLine(), out  value))
                        {
                            Console.WriteLine("The value {0} after IsEven operation is {1}", value, value.IsEven());
                        }
                        else Console.WriteLine("Enter the correct value");
                        break;

                    case 3:
                        Console.WriteLine("Enter the value");
                        if (int.TryParse(Console.ReadLine(), out  value))
                        {
                            Console.WriteLine("The value {0} after IsPrime operation is {1}", value, value.IsPrime());
                        }
                        else Console.WriteLine("Enter the correct value");
                        break;

                    case 4:
                        Console.WriteLine("Enter the first value");
                        if (int.TryParse(Console.ReadLine(), out value))
                        {
                            Console.WriteLine("Enter the second value");
                            if(int.TryParse(Console.ReadLine(), out int value2))
                                Console.WriteLine("The value after IsDivisible operation is {0}", value.IsDivisibleBy(value2));
                            else Console.WriteLine("Enter the correct value");
                        }
                        else Console.WriteLine("Enter the correct value");
                        break;

                    default:
                        break;
                }
            }
        }
    }
}

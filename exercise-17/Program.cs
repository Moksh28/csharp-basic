using System;

namespace exercise_17
{
    public class CustomException:ApplicationException
    {
        public CustomException(string msg) : base(msg) { }
    }

    
    class Program
    {
        public static bool IsPrime(int x)
        {
            if (x < 2) return false;
            for (int i = 2; i <= Math.Sqrt(x); i++)
            {
                if (x % i == 0) return false;
            }
            return true;
        }
        public static void Menu()
        {
            int number;
            Console.WriteLine("Enter any number from 1-5");
            if (int.TryParse(Console.ReadLine(), out int choice)) ;
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter a even number");
                        if (int.TryParse(Console.ReadLine(), out number))
                        {
                            if (number % 2 == 0)
                                Console.WriteLine("You entered correct value");
                            else
                                throw new CustomException("The number you enter is not a even number");
                        }
                        else throw new CustomException("Please enter integer value only");
                        break;

                    case 2:
                        Console.WriteLine("Enter a odd number");
                        if (int.TryParse(Console.ReadLine(), out number))
                        {
                            if (number % 2 == 1)
                                Console.WriteLine("You entered correct value");
                            else
                                throw new CustomException("The number you enter is not a odd number");
                        }
                        else throw new CustomException("Please enter integer value only");
                        break;

                    case 3:
                        Console.WriteLine("Enter a prime number");
                        if (int.TryParse(Console.ReadLine(), out number))
                        {
                            if (IsPrime(number))
                                Console.WriteLine("You entered correct value");
                            else
                                throw new CustomException("The number you enter is not a prime number");
                        }
                        else throw new CustomException("Please enter integer value only");
                        break;

                    case 4:
                        Console.WriteLine("Enter a prime number");
                        if (int.TryParse(Console.ReadLine(), out number))
                        {
                            if (number < 0)
                                Console.WriteLine("You entered correct value");
                            else
                                throw new CustomException("The number you enter is not a negative number");
                        }
                        else throw new CustomException("Please enter integer value only");
                        break;

                    case 5:
                        Console.WriteLine("Enter Zero");
                        if (int.TryParse(Console.ReadLine(), out number))
                        {
                            if (IsPrime(number))
                                Console.WriteLine("You entered correct value");
                            else
                                throw new CustomException("The number you enter is not Zero");
                        }
                        else throw new CustomException("Please enter integer value only");
                        break;

                    default:
                        Console.WriteLine("Error occured");
                        break;
                }
            }
        }
        static void Main(string[] args)
        {
            int i = 0;
            try
            {
                while (true)
                {
                    if (i >= 5) throw new CustomException("\nYou Have Played This Game For 5 Times!");
                    i++;
                    Menu();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
         }

    }
}

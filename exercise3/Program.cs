using System;

namespace exercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter two positive non-equal integers between 2 and 1000");
            //control shifts from line 17 to here i.e line 10
            int number1 = Convert.ToInt32(Console.ReadLine()); //input of 1st number
            int number2 = Convert.ToInt32(Console.ReadLine()); //imput 2nd number

            while ((number1 == number2) || (number1 < 2 || number1 > 1000) || (number2 < 2 || number2 > 1000) || (number1 > number2))
            {
                Console.WriteLine("wrong input enter numbers again");
                number1 = Convert.ToInt32(Console.ReadLine()); //input of 1st number
                number2 = Convert.ToInt32(Console.ReadLine()); //imput 2nd number
            }



            Boolean flag = true; // initial assume all are prime
            Console.WriteLine("Prime numbers between " + number1 + " and " + number2);
            for (int i = number1; i <= number2; i++)
            {

                for (int j = 2; j <= i / 2; j++)
                {
                    if (i % j == 0) // check by dividing the i with j from 2 to i/2 
                    {
                        flag = false; // if we enter here it means number is not a prime hence
                                      // put flag as false once again
                        break; //came out from the inner for loop
                    }
                }

                if (flag)
                {
                    Console.WriteLine(i); // if we came here it means flag is still true and therefore 
                                          // it is a prime number and print it
                }
                flag = true; // this is for the case when flag becomes false in a case but for the iteartion
                             // we always need flag as true;
            }
        }
    }
}

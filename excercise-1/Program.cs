using System;

namespace excercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Enter 1 for integer");
            Console.WriteLine("Enter 2 for float");
            Console.WriteLine("enter 3 for bool");

            string choose = Console.ReadLine();
            int choice = -1;
            int.TryParse(choose, out choice);

            switch (choice)
            {
                case 1:
                    toint();
                    break;
                case 2:
                    tofloat();
                    break;
                case 3:
                    tobool();
                    break;
                default:
                    Console.WriteLine("please enter correct input");
                    break;

            }
        }


        public static void toint()
        {
            Console.WriteLine("Enter integer");
            try
            {
                string n = Console.ReadLine();

                Console.WriteLine("converted the inputNumber to int via int.parse method: " + int.Parse(n));
                Console.WriteLine("converted the inputNumber to int via Convert.ToInt method: " + Convert.ToInt32(n));
                int forConversion;                   // craeted a integer to store the 
                int.TryParse(n, out forConversion); // output of TryParese
                Console.WriteLine("converted the inputNumber to int via int.TryParse method: " + forConversion);
            }
            catch
            {
                Console.WriteLine("you entered wrong input");
            }
        }

        public static void tofloat()
        {
            Console.WriteLine("Enter float number");
            try
            {
                string n = Console.ReadLine();
                Console.WriteLine("converted the inputNumber to float via float.parse method: " + float.Parse(n));
                Console.WriteLine("converted the inputNumber to float via Convert.ToFloat method" + Convert.ToDouble(n));
                Console.WriteLine("converted the inputNumber to float via Convert.ToFloat method" + Convert.ToSingle(n));
            }
            catch
            {
                Console.WriteLine("you entered wrong input");
            }
        }

        public static void tobool()
        {
            Console.WriteLine("Enter only boolean value ");
            try
            {
                string n = Console.ReadLine();
                Console.WriteLine("convert the inputString to bool using Parse: " + bool.Parse(n));
                Console.WriteLine("convert the inputstring to bool using ToBoolean: " + Convert.ToBoolean(n));
            }
            catch
            {
                Console.WriteLine("you entered wrong input");
            }

        }


    }
}

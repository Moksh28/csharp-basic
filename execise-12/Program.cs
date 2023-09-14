using System;
using System.Collections.Generic;
using System.Linq;
namespace execise_12
{
    class Program
    {
        static List<int> list = Enumerable.Range(0, 100).ToList();

        static void Print(IEnumerable<int> printable)
        {
            foreach (int i in printable) Console.Write("\t{0}", i);
            Console.WriteLine("");
        }

        static bool greaterfunc(int x)
        {
            if (x > 5)
                return true;
            else return false;
        }

        static bool lessthanfive (int x)
        {
            if (x < 5)
                return true;
            else return false;
        }

        static bool Gropuconversion(int x)
        {
            if (x % 7 == 0)
                return true;
            else return false;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 1 to find odd numbers");
            Console.WriteLine("Enter 2 to find even numbers");
            Console.WriteLine("Enter 3 to find prime numbers");
            Console.WriteLine("Enter 4 to find prime another");
            Console.WriteLine("Enter 5 Find Elements Greater Than Five");
            Console.WriteLine("Enter 6 Find number Less than Five");
            Console.WriteLine("Enter 7 to Find 3k");
            Console.WriteLine("Enter 8 toFind 3k + 1");
            Console.WriteLine("Enter 9 to Find 3k + 2");
            Console.WriteLine("Enter 10 to Find anything -  Anonymous Method Assignment ");
            Console.WriteLine("Enter 11 to find anything - Method Group Conversion Assignment" );
            if(int.TryParse(Console.ReadLine(), out int choice))
            {
                switch(choice)
                {
                    case 1:
                        IEnumerable<int> odd = list.Where(x => x % 2 == 1);
                        Console.WriteLine("Odds numbers in the range is");
                        Print(odd);
                        break;

                    case 2:
                        IEnumerable<int> even = list.Where(x => { return x % 2 == 0;});
                        Console.WriteLine("Even numbers in the range is");
                        Print(even);
                        break;

                    case 3:
                        IEnumerable<int> prime = list.Where(delegate (int x)
                         {
                             if (x <= 1)
                                 return false;
                             for(int i=2;i<=Math.Sqrt(x);i++)
                             {
                                 if (x % i == 0)
                                     return false;
                             }
                             return true;
                         });
                        Print(prime);
                        break;

                    case 4:
                        IEnumerable<int> primeLambda = list.Where(x =>
                        {
                            if (x <= 1)
                                return false;
                            for (int i = 2; i <= Math.Sqrt(x); i++)
                            {
                                if (x % i == 0)
                                    return false;
                            }
                            return true;
                        });
                        Print(primeLambda);
                        break;

                    case 5:
                        Func<int, bool> greaterthan = greaterfunc;
                        IEnumerable<int> great5 = list.Where(greaterfunc);
                        Print(great5);
                        break;

                    case 6:

                        Func<int, bool> lessthan = new Func<int, bool>(lessthanfive);
                        IEnumerable<int> less = list.Where(lessthan);
                        Print(less);
                        break;

                    case 7:

                        Func<int, bool> threek = new Func<int, bool>(x => x % 3 == 0);
                        IEnumerable<int> ThreeMultiples = list.Where(threek);
                        Print(ThreeMultiples);
                        break;

                    case 8:
                        Func<int, bool> threekone = new Func<int, bool>(delegate (int x)
                         {
                             if (x % 3 == 1)
                                 return true;
                             else return false;
                         });
                        IEnumerable<int> ThreekOne = list.Where(threekone);
                        Print(ThreekOne);
                        break;

                    case 9:
                        Func<int, bool> threektwo = x => x % 3 == 2;
                        IEnumerable<int> ThreeKTwo = list.Where(threektwo);
                        Print(ThreeKTwo);
                        break;

                    case 10:
                        Func<int, bool> any = delegate (int x)
                         {
                             if (x % 10 == 0)
                                 return true;
                             else return false;
                         };
                        IEnumerable<int> anything = list.Where(any);
                        Print(anything);
                        break;

                    case 11:
                        Func<int, bool> anythingusing = Gropuconversion;
                        IEnumerable<int> usinggroupcon = list.Where(anythingusing);
                        Print(usinggroupcon);
                        break;

                    default:
                        Console.WriteLine("enter convertable value");
                        break;

                }
            }

        }
    }
}

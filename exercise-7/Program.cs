using System;
using System.Collections.Generic;
using static exercise_5.Program;
namespace exercise_7
{
    class Program
    {
        internal static List<Duck> ducks = new List<Duck>();

        static void Rubberduck()
        {
            Console.WriteLine("Enter weight of duck");
            if(int.TryParse(Console.ReadLine(), out int weight))
            {
                Console.WriteLine("Enter number of wings");
                if(int.TryParse(Console.ReadLine(), out int wings))
                {
                    ducks.Add(new rubber(weight, wings, DuckType.Rubber));
                    Console.WriteLine("Duck added suceesfully");
                }
                else Console.WriteLine("Enter covertable value");
            }
            else Console.WriteLine("Enter covertable value");
        }

        static void Mallardduck()
        {
            Console.WriteLine("Enter weight of duck");
            if (int.TryParse(Console.ReadLine(), out int weight))
            {
                Console.WriteLine("Enter number of wings");
                if (int.TryParse(Console.ReadLine(), out int wings))
                {
                    ducks.Add(new mallard(weight, wings, DuckType.Rubber));
                    Console.WriteLine("Duck added suceesfully");
                }
                else Console.WriteLine("Enter covertable value");
            }
            else Console.WriteLine("Enter covertable value");
        }

        static void Redheadduck()
        {
            Console.WriteLine("Enter weight of duck");
            if (int.TryParse(Console.ReadLine(), out int weight))
            {
                Console.WriteLine("Enter number of wings");
                if (int.TryParse(Console.ReadLine(), out int wings))
                {
                    ducks.Add(new readhead(weight, wings, DuckType.Rubber));
                    Console.WriteLine("Duck added suceesfully");
                }
                else Console.WriteLine("Enter covertable value");
            }
            else Console.WriteLine("Enter covertable value");
        }
        static void ListOfAllDucks()
        {
            if (ducks.Count > 0)
            {
                Console.WriteLine("\n{0, -10}{1, -10}{2, -20}", "No.", "Weight", "Number of Wings");
                for (int i = 0; i < ducks.Count; i++)
                {
                    Console.WriteLine("{0, -10}{1, -10}{2, -20}", ("Duck" + (i + 1)), ducks[i].weight, ducks[i].wings);
                }
            }
            else Console.WriteLine("List of Ducks is Empty! Please Add A Duck First!");
        }
        static void RemoveDuck()
        {
            ListOfAllDucks();
            Console.WriteLine("\nEnter the Duck Number to Remove: ");
            if (int.TryParse(Console.ReadLine(), out int selectedNumber) && selectedNumber > 0 && selectedNumber <= ducks.Count)
            {
                ducks.RemoveAt(selectedNumber - 1);
                Console.WriteLine("The Selected Ducks is Removed Successfully!");
            }
            else Console.WriteLine("Please Enter Convertible Input or, Index out of Range!");
        }

        static void iterateweight()
        {
            if (ducks.Count > 0)
            {
                ducks.Sort((a, b) => a.weight.CompareTo(b.weight));
                Console.WriteLine("The Duck List Iterated Over Weight of Ducks: ");
                Console.WriteLine("\n{0, -10}{1, -20}{2, -20}", "Weight", "Number of Wings", "Nature");
                for (int i = 0; i < ducks.Count; i++)
                {
                    Console.WriteLine("{0, -10}{1, -20}{2, -20}", ducks[i].weight, ducks[i].wings);
                }
            }
            else Console.WriteLine("The Duck List is Empty! Please Add Ducks First!");
        }

        static void iteratewings()
        {
            if (ducks.Count > 0)
            {
                ducks.Sort((a, b) => a.wings.CompareTo(b.wings));
                Console.WriteLine("The Duck List Iterated Over Duck's Number of Wings:\n ");
                Console.WriteLine("{0, -10}{1, -20}{2, -20}", "Weight", "Number of Wings", "Nature");
                for (int i = 0; i < ducks.Count; i++)
                {
                    Console.WriteLine("{0, -10}{1, -20}{2, -20}", ducks[i].weight, ducks[i].wings);
                }
            }
            else Console.WriteLine("The Duck List is Empty! Please Add Ducks First!");
        }

        static void Main(string[] args)
        {
            int choice = -1;
            while (choice != 0)
            {
                Console.WriteLine("Enter 1 to Create A Rubber Duck");
                Console.WriteLine("Enter 2 to Create A Mallard Duck! ");
                Console.WriteLine("Enter 3 to Create A Redhead Duck! ");
                Console.WriteLine("Enter 4 to Remove A Duck! ");
                Console.WriteLine("Enter 5 to Removing All Ducks!");
                Console.WriteLine("Enter 6 to Iterate Over Ducks Weight");
                Console.WriteLine("Enter 7 to Iterate Over Duck's Number of Wings!");
                Console.WriteLine("Enter 0 to Exit!");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Please enter value from above menu only");
                }
                else
                {
                    switch (choice)
                    {
                        case 1:
                            Rubberduck();
                            break;

                        case 2:
                            Mallardduck();
                            break;

                        case 3:
                            Redheadduck();
                            break;

                        case 4:
                            if (ducks.Count > 0)
                            {
                                RemoveDuck();
                                Console.WriteLine("ALl data deleted");
                            }
                           else  Console.WriteLine("Enter a duck first");
                            break;

                        case 5:
                            if (ducks.Count > 0)
                                ducks.Clear();
                           else  Console.WriteLine("All ducks cleared");
                            break;

                        case 6:
                            if (ducks.Count > 0)
                                iterateweight();
                            else Console.WriteLine("Nothing to display");
                            break;

                        case 7:
                            if (ducks.Count > 0)
                                iteratewings();
                            else Console.WriteLine("Nothing to dislplay");
                            break;

                        default:
                            Console.WriteLine("Enter a particular value");
                            break;
                    }
                }
            }
        }
    }
}

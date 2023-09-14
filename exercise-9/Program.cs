using System;
using System.Collections.Generic;
using System.Linq;
namespace exercise_9
{
    interface IPriority
    {
        int Priority();
    }

    public class Person : IEquatable<Person>, IPriority
    {
        public int priority { get; set; }
        public string Name { get; set; }

        public Person() { }

        public Person(int val, string name)
        {
            priority = val;
            Name = name;
        }

        public int Priority() { return priority; }

        public bool Equals(Person ex)
        {
            if (ex == null) return false;
            return (this.priority == ex.priority && this.Name == ex.Name);
        }
    }

    class PriorityQueue2<T> where T : IEquatable<T>, IPriority
    {
        public IDictionary<int, IList<T>> elements;

        public PriorityQueue2()
        {
            elements = new Dictionary<int, IList<T>>();
        }

        public PriorityQueue2(IDictionary<int, IList<T>> elements) : this() { }

        public int Count()
        {
            return elements.Count;
        }

        public bool Contains(T item)
        {
            foreach (var pair in elements)
            {
                foreach (var val in pair.Value)
                {
                    if (val.Equals(item))
                    {
                        return true; ;
                    }
                }
            }
            return false;
        }

        public T Dequeue()
        {
            IList<T> list = elements[elements.Keys.Max()];
            int priority = elements.Keys.Max();
            T highestPriority = Peek();
            list.RemoveAt(0);
            if (list.Count == 0) elements.Remove(priority);
            return highestPriority;
        }

        public void Enqueue(T item)
        {
            int priority = item.Priority();
            IList<T> items;
            if (!elements.ContainsKey(priority)) elements.Add(priority, new List<T>());
            items = elements[priority];
            items.Add(item);
        }

        public T Peek()
        {
            IList<T> priorityList = elements[elements.Keys.Max()];
            return priorityList[0];
        }

        private int GetHighestPriority()
        {
            return elements.Keys.Max();
        }

        public int PublicGetHighestPriority() { return GetHighestPriority(); }
    }
    class Program
    {
        static void Main(string[] args)
        {
             PriorityQueue2<Person> priorityQueue = new PriorityQueue2<Person>();
            int choice = -1;
            while (choice != 7)
            {
                Console.WriteLine("Enter 1 for Insert Person!");
                Console.WriteLine("Enter 2 for Delete Person!");
                Console.WriteLine("Enter 3 for Total Number of Person!");
                Console.WriteLine("Enter 4 for Peek Person!");
                Console.WriteLine("Enter 5 for Contains Operation!");
                Console.WriteLine("Enter 6 for Get Highest Priority!");
                Console.WriteLine("Enter 7 to exit");

                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch(choice)
                    {
                        case 1:
                            Console.WriteLine("Enter the Priority: ");
                            if (int.TryParse(Console.ReadLine(), out int priority))
                            {
                                Console.WriteLine("Enter the Name: ");
                                priorityQueue.Enqueue(new Person(priority, Console.ReadLine()));
                                Console.WriteLine("\nElement Inserted Successfully!");
                            }
                            else
                                Console.WriteLine("\nPlease Enter Convertible Input!");
                            break;


                        case 2:
                            if (priorityQueue.Count() > 0)
                                Console.WriteLine("Dequeue Operation Successful! Dequeued Element is '{0}'.", priorityQueue.Dequeue().Name);
                            else Console.WriteLine("\nPriority Queue is Empty! Please Add Some Elements First!");
                            break;

                        case 3:
                            Console.WriteLine("\nThe Total Number of Elements in Priority Queue is {0}.", priorityQueue.Count());
                            break;

                        case 4:
                            if (priorityQueue.Count() > 0)
                                Console.WriteLine("\nThe Peek Element of Priority Queue is '{0}'.", priorityQueue.Peek().Name);
                            else Console.WriteLine("\nPriority Queue is Empty! Please Add Some Elements First!");
                            break;

                        case 5:
                            if (priorityQueue.Count() > 0)
                            {
                                Console.WriteLine("\nEnter the Priority: ");
                                if (int.TryParse(Console.ReadLine(), out int searchValue))
                                {
                                    Console.WriteLine("Enter the Name: ");
                                    bool flag = priorityQueue.Contains(new Person(searchValue, Console.ReadLine()));
                                    if (flag) Console.WriteLine("Found!");
                                    else Console.WriteLine("Not Found!");
                                }
                            }
                            else Console.WriteLine("\nPriority Queue is Empty! Please Add Some Elements First!");
                            break;

                        case 6:
                            if (priorityQueue.Count() > 0)
                            {
                                Console.WriteLine("The Highest Priority of Priority Queue is {0}.", priorityQueue.PublicGetHighestPriority());
                            }
                            else Console.WriteLine("\nPriority Queue is Empty! Please Add Some Elements First!");
                            break;

                        default:
                            Console.WriteLine("Something went wrong");
                            break;

                    }
                }
                else
                {
                    Console.WriteLine("you entered wrong input");
                }
            }
        }
    }
}

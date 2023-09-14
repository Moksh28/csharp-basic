using System;
using System.Collections.Generic;
using System.Linq;
namespace exercise_8
{
    class PriorityQueue<T> where T : IEquatable<T>
    {
        private IDictionary<int, IList<T>> elements;

        public PriorityQueue()
        {
            elements = new Dictionary<int, IList<T>>();
        }

        public PriorityQueue(IDictionary<int, IList<T>> elements) : this() { }

        public int Count()
        {
            return elements.Count;
        }

        public bool Contains(T item)
        {
            bool flag = false;
            foreach (var pair in elements)
            {
                foreach (var val in pair.Value)
                {
                    if (val.Equals(item))
                    {
                        Console.WriteLine("\n'{0}' Found at Element '{1}' with Priority {2}.", item, val, pair.Key);
                        flag = true;
                    }
                    if (flag == true) return flag;
                }
            }
            return flag;
        }

        public T Dequeue()
        {
            IList<T> list = elements[elements.Keys.Max()];
            int priority = elements.Keys.Max();
            T highestPriority = list.Max();
            list.Remove(highestPriority);
            if (list.Count == 0) elements.Remove(priority);
            return highestPriority;
        }

        public void Enqueue(int priority, T item)
        {
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

        public int GetHighestPriority()
        {
            int FirstKey = elements.Keys.Max();
            return FirstKey;
        }
    }




    class Program
    {
        static PriorityQueue<string> priorityQueue = new PriorityQueue<string>();
        static void Main(string[] args)
        {
            int choice = -1;
            while (choice != 7)
            {
                Console.WriteLine("Enter 1 for Insert Elements!");
                Console.WriteLine("Enter 2 for Delete Elements!");
                Console.WriteLine("Enter 3 for Total Number of Elements!");
                Console.WriteLine("Enter 4 for Peek Element!");
                Console.WriteLine("Enter 5 for Contains Operation!");
                Console.WriteLine("Enter 6 for Get Highest Priority!");
                Console.WriteLine("Enter 7 to exit");
                if (int.TryParse(Console.ReadLine(), out choice));
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("\nEnter the Priority: ");
                            if (int.TryParse(Console.ReadLine(), out int priority))
                            {
                                Console.WriteLine("Enter the Name: ");
                                priorityQueue.Enqueue(priority, Console.ReadLine());
                                Console.WriteLine("\nElement Inserted Successfully!");
                            }
                            else
                                Console.WriteLine("\nPlease Enter Convertible Input!");
                            break;

                        case 2:
                            if (priorityQueue.Count() > 0)
                                Console.WriteLine("Dequeue Operation Successful! Dequeued Element is '{0}'.", priorityQueue.Dequeue());
                            else Console.WriteLine("\nPriority Queue is Empty! Please Add Some Elements First!");
                            break;
                        case 3:
                            Console.WriteLine("\nThe Total Number of Elements in Priority Queue is {0}.", priorityQueue.Count());
                            break;
                        case 4:
                            if (priorityQueue.Count() > 0)
                                Console.WriteLine("\nThe Peek Element of Priority Queue is '{0}'.", priorityQueue.Peek());
                            else Console.WriteLine("\nPriority Queue is Empty! Please Add Some Elements First!");
                            break;

                        case 5:
                            if (priorityQueue.Count() > 0)
                            {
                                Console.WriteLine("\nEnter the Element to Search: ");
                                Console.WriteLine(priorityQueue.Contains(Console.ReadLine()));
                            }
                            else Console.WriteLine("\nPriority Queue is Empty! Please Add Some Elements First!");
                            break;
                        case 6:
                            if (priorityQueue.Count() > 0)
                            {
                                Console.WriteLine("The Highest Priority of Priority Queue is {0}.", priorityQueue.GetHighestPriority());
                            }
                            else Console.WriteLine("\nPriority Queue is Empty! Please Add Some Elements First!");
                            break;

                        default:
                            Console.WriteLine("Enter value again");
                            break;
                    }
                }
                Console.WriteLine("Enter convertable value");
            }
        }
    }
}

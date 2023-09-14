using System;
using System.Collections.Generic;
using System.Linq;
namespace exercise_10
{
    class PriorityQueue3<T> where T : IEquatable<T>
    {
        private class PriorityNode
        {
            public int Priority { get; private set; }
            public T data { get; private set; }

            public PriorityNode(int priority, T data)
            {
                Priority = priority;
                this.data = data;
            }
        }

        private IList<PriorityNode> elements;

        public PriorityQueue3()
        {
            elements = new List<PriorityNode>();
        }

        public PriorityQueue3(IDictionary<int, IList<T>> elements) : this() { }

        public int Count() { return elements.Count; }

        public bool Contains(T item)
        {
            foreach (PriorityNode val in elements)
            {
                if (val.data.Equals(item)) return true;
            }
            return false;
        }

        public T Dequeue()
        {
            int deletedElement = -1;
            T deletedData = default;
            for (int i = 0; i < elements.Count; i++)
            {
                if (elements[i].Priority == GetHighestPriority())
                {
                    deletedData = elements[i].data;
                    deletedElement = i;
                    break;
                }
            }
            elements.RemoveAt(deletedElement);
            Console.WriteLine("\nDeleted Successfully!");
            return deletedData;
        }

        public void Enqueue(int priority, T item)
        {
            elements.Add(new PriorityNode(priority, item));
        }

        public T Peek()
        {
            int highestPriority = GetHighestPriority();
            for (int i = 0; i < elements.Count; i++)
            {
                if (elements[i].Priority == highestPriority) return elements[i].data;
            }
            return default;
        }

        private int GetHighestPriority()
        {
            int highestPriority = -1;
            foreach (PriorityNode val in elements)
            {
                highestPriority = Math.Max(highestPriority, val.Priority);
            }
            return highestPriority;
        }

        public int PublicGetHighestPriority()
        {
            return GetHighestPriority();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue3<String> priorityQueue = new PriorityQueue3<String>();
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

                if(int.TryParse(Console.ReadLine(),out choice))
                {
                    switch(choice)
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
                            Console.WriteLine("\nAdded Successfully!");
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
                                Console.WriteLine("The Highest Priority of Priority Queue is {0}.", priorityQueue.PublicGetHighestPriority());
                            }
                            else Console.WriteLine("\nPriority Queue is Empty! Please Add Some Elements First!");
                            break;

                        case 7:
                            break;

                        default:
                            Console.WriteLine(" Something wemt wrong");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("wrong input");
                }
            }
        }
    }
}

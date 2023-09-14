using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
namespace exercise_15
{
    class Program
    {
        static ObservableCollection<int> value = new ObservableCollection<int>();

        public static void OnCollectionChange(object sender, NotifyCollectionChangedEventArgs e)
        {
            if(e.Action==NotifyCollectionChangedAction.Add)
            {
                if(e.NewItems?[0]is int)
                    Console.WriteLine("Element is added");
            }
                

            if(e.Action==NotifyCollectionChangedAction.Remove)
            {
                if(e.OldItems?[0]is int)
                    Console.WriteLine("element removed");
            }
                
        }
        static void Main(string[] args)
        {
            int choice = -1;
            while(choice!=3)
            {
                Console.WriteLine("Enter 1 to Add");
                Console.WriteLine("Enter 2 to delete");
                Console.WriteLine("Enter 3 to exit");
                if(int.TryParse(Console.ReadLine(),out choice))
                 { 
                    switch(choice)
                    {
                        case 1:
                            Console.WriteLine("Enter the number to add");
                            if(int.TryParse(Console.ReadLine(),out int val))
                            {
                                value.CollectionChanged += OnCollectionChange;
                                value.Add(val);
                            }
                            else
                                Console.WriteLine("Enter covertable value");
                            break;
                        case 2:
                            if(value.Count>0)
                            {
                                value.RemoveAt(0);
                            }
                            else Console.WriteLine("Nothing to remove");
                            break;
                        default:
                            Console.WriteLine("Enter again");
                            break;
                    }
                }
                else Console.WriteLine("enter covetable value");

            }
        }
    }
}

using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
namespace exercise_13
{
    static class Program
    {
        public static bool CustomAll<T>(this IEnumerable<T> list, Func<T,bool> delegatefunction )
        {
            if (list == null) throw new ArgumentNullException(nameof(list)) ;
            foreach (var value in list)
                if (!delegatefunction(value))
                    return false;
            return true;
        }

        public static bool CustomAny<T>(this IEnumerable<T> list, Func<T,bool> delegatefunction)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));

            foreach(var value in list)
                if (!delegatefunction(value))
                    return false;
            return true;
        }

        public static TResult CustomMin<T, TResult>(this IEnumerable<T> element, Func<T, TResult> delegateFunction)  where TResult : IComparable<TResult>
        {
            if (element is null) throw new ArgumentNullException(nameof(element));
            TResult min;
            using var enumerator = element.GetEnumerator();
            if (enumerator.MoveNext()) min = delegateFunction(enumerator.Current);
            else throw new InvalidOperationException("\nSequence Contains No Element!");
            while (enumerator.MoveNext())
            {
                var result = delegateFunction(enumerator.Current);
                if (min is null || min.CompareTo(result) > 0) min = result;
            }
            return min;
        }

        public static TResult CustomMax<T, TResult>(this IEnumerable<T> element, Func<T, TResult> delegateFunction) where TResult : IComparable<TResult>
        {
            if (element is null) throw new ArgumentNullException(nameof(element));
            TResult max;
            using var enumerator = element.GetEnumerator();
            if (enumerator.MoveNext()) max = delegateFunction(enumerator.Current);
            else throw new InvalidOperationException("\nSequence Contains No Element!");
            while (enumerator.MoveNext())
            {
                var result = delegateFunction(enumerator.Current);
                if (max is null || max.CompareTo(result) < 0) max = result;
            }
            return max;
        }

        public static IEnumerable<TResult> CustomSelect<T, TResult>(this IEnumerable<T> element, Func<T, TResult> delegateFunction)
        {
            if (element is null) throw new ArgumentNullException(nameof(element));
            foreach (var val in element) yield return delegateFunction(val);
        }
        public static IEnumerable<T> CustomWhere<T>(this IEnumerable<T> element, Func<T, bool> delegateFunction)
        {
            if (element is null) throw new ArgumentNullException(nameof(element));
            foreach (var val in element)
            {
                if (delegateFunction(val)) yield return val;
            }
        }

        static List<int> list = new List<int>() { 2, 3, 4, 5, 6, 7, 8, 9 };
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 1 to peroform CustomAll");
            Console.WriteLine("Enter 2 to peroform CustomAny");
            Console.WriteLine("Enter 3 to peroform CustomMax");
            Console.WriteLine("Enter 4 to peroform CustomMin");
            Console.WriteLine("Enter 5 to peroform CustomWhere");
            Console.WriteLine("Enter 6 to peroform CustomSelect");

            if(int.TryParse(Console.ReadLine(), out int choice))
            {
                switch(choice)
                {
                    case 1:
                        Console.WriteLine(list.CustomAll(x => x>2));
                        break;

                    case 2:
                        Console.WriteLine(list.CustomAny(x=> x%3==0));
                        break;

                    case 3:
                        Console.WriteLine(list.CustomMax(x=> 2*x));
                        break;

                    case 4:
                        Console.WriteLine(list.CustomMin(x => x * 2));
                        break;

                    case 5:
                        Console.WriteLine(string.Join(",", list.CustomSelect(x => x + 1)));
                        break;

                    case 6:
                        Console.WriteLine(string.Join(",", list.CustomSelect(x => x + 1)));
                        break;

                    default:
                        Console.WriteLine("Choose options from above only");
                        break;
                }
            }
            else
                Console.WriteLine("Enter covertable value");
        }
    }
}

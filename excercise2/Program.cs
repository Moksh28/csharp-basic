using System;

namespace excercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            object obj1 = null;
            object obj2 = new object();

            // == operator
            // The operator '==' test for reference equality i.e.,
            // Whether both objects are pointing to same object or not.
            // This operator doesn't throw any exception.
            Console.WriteLine("Comparison with == operator: {0}", obj1 == obj1); //true

            // Equals Method
            // This method is used to check whether both objects have
            // equal value or not. It throws an exception "NullReferenceException"
            try
            {
                Console.WriteLine("Comparison with Equals method: {0}", obj1.Equals(obj1));
            }
            catch (Exception)
            {
                Console.WriteLine("Throws NullReferenceException!");
            }

            // ReferenceEquals Method
            // This method is used to determine whether the specified object instances
            // are the same instance or not.
            Console.WriteLine("Comparison with ReferenceEquals method: {0}", ReferenceEquals(obj1, obj1));  // True


            // == operator
            Console.WriteLine("Comparison with == operator: {0}", obj1 == obj2);        // False
            // Equals Method
            try
            {
                Console.WriteLine("Comparison with Equals method: {0}", obj1.Equals(obj2));
            }
            catch (Exception)
            {
                Console.WriteLine("Throws NullReferenceException!");
            }
            // ReferenceEquals Method
            Console.WriteLine("Comparison with ReferenceEquals method: {0}", ReferenceEquals(obj1, obj2));  // False


        }
    }
}

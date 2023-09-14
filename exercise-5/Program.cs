using System;

namespace exercise_5
{
   public class Program
    {
        public enum DuckType { Rubber = 1, Mallard = 2, Redhead = 3 }
        public interface showdetails
        {
            void show();
        }

        public class Duck : showdetails
        {
            public int weight;
            public int wings;
            public DuckType duckType;

            public Duck() // default constructor
            {

            }

            public Duck(int weight, int wings, DuckType duckType)
            {
                this.weight = weight;
                this.wings = wings;
                this.duckType = duckType;
            }

            public virtual void show()
            {
                if (duckType == DuckType.Mallard)
                {
                    Console.WriteLine("Mallard duck:");
                }
                if (duckType == DuckType.Rubber)
                {
                    Console.WriteLine("Rubber duck:");
                }
                if (duckType == DuckType.Redhead)
                {
                    Console.WriteLine("Redhead duck:");
                }
                Console.WriteLine("Weight: {0}", weight);
                Console.WriteLine("Number of wings: {0}",wings);
            }
        
        }
            public class rubber : Duck
            {
                public rubber()
                {

                }
                public rubber(int weight, int wings, DuckType duckType)
                    :base(weight, wings, duckType)
                {

                }

                public override void show()
                {
                    base.show();
                    Console.WriteLine("These ducks can't fly and quack");
                }
            }

            public class mallard : Duck
            {
                public mallard()
                {

                }
                public mallard(int weight, int wings, DuckType duckType)
                    : base(weight, wings, duckType)
                {

                }

                public override void show()
                {
                    base.show();
                    Console.WriteLine("These ducks fly fast and quack loudly");
                }
            }

            public class readhead : Duck
            {
                public readhead()
                {

                }
                public readhead(int weight, int wings, DuckType duckType)
                    : base(weight, wings, duckType)
                {

                }

                public override void show()
                {
                    base.show();
                    Console.WriteLine("These ducks fly slow and quack mild");
                }
            }
        
         static void Main(string[] args)
        {
            Console.WriteLine("Enter 1 to create a rubber duck \nEnter 2 to create a mallard duck \nEnter 3 to create a redhead duck");
            int choice = int.Parse(Console.ReadLine());

            if(choice == (int) DuckType.Rubber)
            {
                Console.WriteLine("Enter weight of the  rubber duck");
                int weight = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter number of wings of duck");
                int wings = int.Parse(Console.ReadLine());
                rubber r = new rubber(weight, wings, DuckType.Rubber);
                r.show();
            }

            if (choice == (int)DuckType.Mallard)
            {
                Console.WriteLine("Enter weight of the mallard duck");
                int weight = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter number of wings of duck");
                int wings = int.Parse(Console.ReadLine());
                mallard m = new mallard(weight, wings, DuckType.Mallard);
                m.show();
            }

            if (choice == (int)DuckType.Redhead)
            {
                Console.WriteLine("Enter weight of the  redhead duck");
                int weight = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter number of wings of duck");
                int wings = int.Parse(Console.ReadLine());
                readhead rd = new readhead(weight, wings, DuckType.Rubber);
                rd.show();
            }
        }
    }
}

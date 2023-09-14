using System;

namespace exercise_4
{
    public enum TypeEquipment { Mobile = 1, immobile = 2 };
    public class Program
    {
        public abstract class Equipment
        {
            public string name;
            public string description;
            public int distcanceMoved = 0;
            public int maintainceCost = 0;
           

            public abstract void moveby();
            public abstract void show();

        }

        public class Mobile : Equipment {
           

            public int wheels;

            public Mobile(String name, String desc,int distancetomoved,int cost,int wheel) 
            {
                this.name = name;
                this.description = desc;
                this.distcanceMoved = distancetomoved;
                this.wheels = wheel;
                this.maintainceCost = cost;
            }
            override public void moveby() 
            {
               
                maintainceCost = distcanceMoved * wheels;
               
            }
            public override void show()
            {
                Console.WriteLine("Name of the equipment is: {0}", name);
                Console.WriteLine("description of equipment: {0}", description);
                Console.WriteLine("Distance moved by equipment; {0}", distcanceMoved);
                Console.WriteLine("Number of wheels are: {0}", wheels);
                Console.WriteLine("maintaince cost is {0}", maintainceCost);
            }
        }

        public class Immobile : Equipment
        {
            public int weight;
            public Immobile(String name, String desc, int distancetomove,int cost, int weigh)
            {
                this.name = name;
                this.description = desc;
                this.distcanceMoved = distancetomove;
                this.weight = weigh;
                this.maintainceCost = cost;
            }
            public override void moveby()
            {
                
                maintainceCost = distcanceMoved * weight;
                
            }

            public override void show()
            {
                Console.WriteLine("Name of the equipment is: {0}", name);
                Console.WriteLine("description of equipment: {0}", description);
                Console.WriteLine("Distance moved by equipment; {0}", distcanceMoved);
                Console.WriteLine("Weight of equipment is: {0}", weight);
                Console.WriteLine("maintaince cost is {0}", maintainceCost);
            }
        }
        static void Main(String[] args) 
        {
            
           
            Console.WriteLine("Press 1 for mobile and 2 for immobile");
            int choice = int.Parse(Console.ReadLine());
            if (choice == (int) TypeEquipment.Mobile ) 
            {
                Console.WriteLine("Enter Name of equipment");
                string n = Console.ReadLine();
                Console.WriteLine("Enter Description of equipment");
                string d = Console.ReadLine();
                Console.WriteLine("Enter distance to move");
                int dm = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the number of wheels of equipment");
                int wheels = int.Parse(Console.ReadLine()); 
                Mobile mb = new Mobile(n, d,dm,0, wheels);
                mb.moveby();
                mb.show();
            }
            if (choice == (int) TypeEquipment.immobile)
            {
                Console.WriteLine("Enter Name of equipment");
                string n = Console.ReadLine();
                Console.WriteLine("Enter Description of equipment");
                string d = Console.ReadLine();
                Console.WriteLine("Enter distance to move");
                int dm = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the weight of equipment");
                int w = int.Parse(Console.ReadLine());
                Immobile mb = new Immobile(n, d, dm,0, w);
                mb.moveby();
                mb.show();

            }

        }
    }
}

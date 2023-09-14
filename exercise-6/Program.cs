using System;
using System.Collections.Generic;
using  static exercise_4.Program;


namespace exercise_6
{
    class Program
    {
        public static List<Equipment> equipment = new List<Equipment>();

        static void CreateEquipment(List<Equipment> equipment)
        {
            Console.WriteLine("Enter 1 to create a mobile equipment");
            Console.WriteLine("Enter 2 to create a immbobile equipment");
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 2)
            {
                Console.WriteLine("\nSelect correct menu item.\n");
            }
            else
            {

                Console.WriteLine("Enter the Equipment Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter the Equipment Description: ");
                string description = Console.ReadLine();
                if (choice == 1)
                {
                    Console.WriteLine("Enter number of wheels");
                    int wheels = int.Parse(Console.ReadLine());
                    equipment.Add(new Mobile(name, description, 0, 0, wheels));
                }
                if (choice == 2)
                {
                    Console.WriteLine("Enter Weight of equipment");
                    int weight = int.Parse(Console.ReadLine());
                    equipment.Add(new Immobile(name, description, 0, 0, weight));
                }
                Console.WriteLine("Equipment has been added");
            }
        }



        static void DeleteEquipment(List<Equipment> equipment)
        {
            if (equipment.Count > 0)
            {
                ListAllEquipment(equipment);
                Console.WriteLine("Enter the Equipment Number to Delete: ");
                if (!int.TryParse(Console.ReadLine(), out int selectedChoice) || selectedChoice < 0 || selectedChoice > equipment.Count)
                {
                    Console.WriteLine("Please Enter Convertable / Indexible Input!");
                }
                else
                {
                    equipment.RemoveAt(selectedChoice - 1);
                    Console.WriteLine("\nThe Selected Equipment is Deleted Successfully!");
                }
            }
            else Console.WriteLine("\nThe Equipment List is Empty! Please Add Equipments First!");
        }

        static void MoveEquipment(List<Equipment> equipment)
        {
            if (equipment.Count > 0)
            {
                ListAllEquipment(equipment);
                Console.WriteLine("\nEnter the Equipment Number to Move: ");
                if (int.TryParse(Console.ReadLine(), out int selectedEquipment) || selectedEquipment > 0 || selectedEquipment <= equipment.Count)
                {
                    equipment[selectedEquipment - 1].moveby();
                }
                else Console.WriteLine("Please Enter Convertible Input or, Index out of Range!");
            }
            else Console.WriteLine("Please Create An Equipment First!");
        }

        static void ListAllEquipment(List<Equipment> equipment)
        {
            if (equipment.Count > 0)
            {
                Console.WriteLine("\n{0, -5}{1, -20}{2, -15}", "No.", "Name", "Description");
                for (int i = 0; i < equipment.Count; i++)
                {
                    Console.WriteLine("{0, -5}{1, -20}{2, -15}", (i + 1), equipment[i].name, equipment[i].description);
                }
            }
            else Console.WriteLine("\nPlease Add An Equipment First!");
        }

        static void GetDetails(List<Equipment> equipment)
        {
            if (equipment.Count > 0)
            {
                ListAllEquipment(equipment);
                Console.WriteLine("\nEnter the Equipment Number to Show: ");
                if (int.TryParse(Console.ReadLine(), out int selectedEquipment) || selectedEquipment > 0 || selectedEquipment <= equipment.Count)
                {
                    equipment[selectedEquipment - 1].show();
                }
                else Console.WriteLine("Please Enter Convertible Input!");
            }

            else Console.WriteLine("Please Create An Equipment First!");
        }

        static void ListMobileEquipment(List<Equipment> equipment)
        {
            if (equipment.Count > 0)
            {
                int i = 0;
                Console.WriteLine("\n{0, -5}{1, -10}{2, -20}{3, -30}{4, -25}{5, -25}", "No.", "Type", "Name", "Description", "Maintenance Cost", "Distance Moved");
                foreach (Equipment equipments in equipment.FindAll(e => e is Mobile))
                {
                    Console.WriteLine("{0,-5}{1,-10}{2,-20}{3,-30}{4,-25}{5,-25}", (i + 1), "Mobile", equipments.name, equipments.description, equipments.maintainceCost, equipments.distcanceMoved);
                    i++;
                }
            }
            else Console.WriteLine("Please Add One Equipment First!");
        }

        static void ListAllImmobileEquipment(List<Equipment> equipment)
        {
            if (equipment.Count > 0)
            {
                int i = 0;
                Console.WriteLine("\n{0, -5}{1, -10}{2, -20}{3, -30}{4, -25}{5, -25}", "No.", "Type", "Name", "Description", "Maintenance Cost", "Distance Moved");
                foreach (Equipment equipments in equipment.FindAll(e => e is Immobile))
                {
                    Console.WriteLine("{0,-5}{1,-10}{2,-20}{3,-30}{4,-25}{5,-25}", (i + 1), "Mobile", equipments.name, equipments.description, equipments.maintainceCost, equipments.distcanceMoved);
                    i++;
                }
            }
            else Console.WriteLine("Please Add One Equipment First!");
        }

        static void ListNotMoved(List<Equipment> equipment)
        {
            List<Equipment> notMoved = new List<Equipment>();
            for (int i = 0; i < equipment.Count; i++)
            {
                if (equipment[i].distcanceMoved == 0) notMoved.Add(equipment[i]);
            }
            if (notMoved.Count == 0)
            {
                Console.WriteLine("\nNo Such Equipments!\n");
            }
            else
            {
                int i = 1;
                Console.WriteLine("{0, -5}{1, -20}{2, -35}{3, -30}{4, -30}", "No.", "Name", "Description", "Moved Distance", "Maintenance Cost");
                foreach (Equipment e in notMoved)
                {
                    Console.WriteLine("{0, -5}{1, -20}{2, -35}{3, -30}{4, -30}", i, e.name, e.description, e.distcanceMoved, e.maintainceCost);
                    i++;
                }
            }
        }

        static void DeleteMobile(List<Equipment> equipment)
        {
            for (int i = 0; i < equipment.Count; i++)
            {
                if (equipment[i] is Mobile) equipment.RemoveAt(i);
            }
            Console.WriteLine("\nAll Mobile Equipments are Deleted!");
        }

        static void DeleteImmobile(List<Equipment> equipment)
        {
            for (int i = 0; i < equipment.Count; i++)
            {
                if (equipment[i] is Immobile) equipment.RemoveAt(i);
            }
            Console.WriteLine("\nAll Immobile Equipments are Deleted!");
        }
        static void Main(string[] args)
        {
            int choice = -1;
            while (choice != 12)
            {
                Console.WriteLine("Enter 1 to create a equipment");
                Console.WriteLine("Enter 2 to delete an equipment");
                Console.WriteLine("Enter 3 to move an equipment");
                Console.WriteLine("Enter 4 to list all equpiment");
                Console.WriteLine("Enter 5 to get deatils of an equipment");
                Console.WriteLine("Enter 6 to list all mobile equipment");
                Console.WriteLine("Enter 7 to list all immobile equipment");
                Console.WriteLine("Enter 8 to List all equipment that have not been moved till now");
                Console.WriteLine("Enter 9 to Delete all equipment");
                Console.WriteLine("Enter 10 to Delete all immobile equipment");
                Console.WriteLine("Enter 11 to Delete all mobile equipment");
                Console.WriteLine("Enter 12 to exit");
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("\nSelect correct menu item.\n");
                }
                else
                {
                    switch (choice)
                    {
                        case 1:
                            CreateEquipment(equipment);
                            break;

                        case 2:
                            if (equipment.Count > 0)
                                DeleteEquipment(equipment);
                            else Console.WriteLine("List is empty -- Add first");
                            break;
                        case 3:
                            if (equipment.Count > 0)
                                MoveEquipment(equipment);
                            else Console.WriteLine("List is empty -- Add first");
                            break;
                        case 4:
                            if (equipment.Count > 0)
                                ListAllEquipment(equipment);
                            else Console.WriteLine("List is empty -- Add first");
                            break;
                        case 5:
                            if (equipment.Count > 0)
                                GetDetails(equipment);
                            else Console.WriteLine("List is empty -- Add first");
                            break;
                        case 6:
                            if (equipment.Count > 0)
                                ListMobileEquipment(equipment);
                            else Console.WriteLine("List is empty -- Add first");
                            break;
                        case 7:
                            if (equipment.Count > 0)
                                ListAllImmobileEquipment(equipment);
                            else Console.WriteLine("List is empty -- Add first");
                            break;
                        case 8:
                            if (equipment.Count > 0)
                                ListNotMoved(equipment);
                            else Console.WriteLine("List is empty -- Add first");
                            break;
                        case 9:
                            if (equipment.Count > 0)
                            {
                                equipment.Clear();
                                Console.WriteLine("deleted succesfully");
                            }
                            else Console.WriteLine("List is empty -- Add first");
                            break;
                        case 10:
                            if (equipment.Count > 0)
                                DeleteImmobile(equipment);
                            else Console.WriteLine("List is empty -- Add first");
                            break;
                        case 11:
                            if (equipment.Count > 0)
                                DeleteMobile(equipment);
                            else Console.WriteLine("List is empty -- Add first");
                            break;
                        default:
                            Console.WriteLine("choose correct input");
                            break;


                    }
                }
            }

        }
    }
}


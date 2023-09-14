using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics.CodeAnalysis;

namespace exercise_14
{
    class Product : IEquatable<int>
    {
        public int id;
        public float price;
        public bool isdefective;

        public Product(int id, float price, bool isdefective)
        {
            this.id = id;
            this.price = price;
            this.isdefective = isdefective;
        }
        public bool Equals([AllowNull] int other)
        {
            throw new NotImplementedException();
        }
    }
    class Program
    {
        static Dictionary<int, Product> products = new Dictionary<int, Product>();

        static public void ProductDetails()
        {
            foreach (var res in products)
                Console.WriteLine("Product id: {0}, quantity: {1}", res.Value.id, res.Key);
        }
        static void Main(string[] args)
        {


            int choice = -1;
            while (choice != 5)
            {
                Console.WriteLine("Enter 1 to add product");
                Console.WriteLine("Enter 2 to remove product");
                Console.WriteLine("Enter 3 to update product quantity");
                Console.WriteLine("Enter 4 to display value of inventory");
                Console.WriteLine("Enter 5 to exit");
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            try
                            {
                                Console.WriteLine("Enter id");
                                int pid = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter Price of product in float");
                                float priceproduct = float.Parse(Console.ReadLine());
                                Console.WriteLine("Enter its quantities");
                                int quantproduct = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter true if product is defective or false if it not");
                                bool isdefectivep = bool.Parse(Console.ReadLine());
                                Product p = new Product(pid, priceproduct, isdefectivep);

                                if (!isdefectivep)
                                {
                                    products.Add(quantproduct, p);
                                    Console.WriteLine("Product has been added");
                                }
                            }

                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;

                        case 2:
                            try
                            {
                                if (products.Count > 0)
                                {
                                    ProductDetails();

                                    int check = -1;
                                    Console.WriteLine("enter product id to remove");
                                    int removeid = int.Parse(Console.ReadLine());
                                    Product removedproduct = null;

                                    foreach (var product in products)
                                    {
                                        if (product.Value.id == removeid)
                                        {
                                            removedproduct = product.Value;
                                            check = product.Key;
                                        }
                                    }
                                    if (removedproduct != null)
                                    {
                                        products.Remove(check);
                                        Console.WriteLine("Removed");
                                    }
                                    else Console.WriteLine("you entered wrong id");
                                }
                                else
                                {
                                    Console.WriteLine("no product present");
                                }

                             }

                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                                break;

                        case 3:
                            try
                            {
                                if (products.Count > 0)
                                {
                                    ProductDetails();
                                    int check = -1;
                                    Console.WriteLine("Enter id to update quantity");
                                    int id = int.Parse(Console.ReadLine());
                                    Product removedproduct = null;

                                    foreach (var product in products)
                                    {
                                        if (product.Value.id == id)
                                        {
                                            removedproduct = product.Value;
                                            check = product.Key;
                                        }
                                    }
                                    if (removedproduct != null)
                                    {
                                        Console.Write("Enter a new product quantities: ");
                                        int quantities = int.Parse(Console.ReadLine());
                                        products.Remove(check);
                                        products.Add(quantities, removedproduct);
                                        Console.WriteLine("\nThe product quantity has been updated.\n");
                                    }

                                }
                                else Console.WriteLine("no product");
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;

                        case 4:
                            float total=0;
                            foreach(var product in products)
                            {
                                total += product.Key * product.Value.price;
                            }
                            Console.WriteLine("Total value {0}", total);
                            break;

                        default:
                            Console.WriteLine("Error occured");
                            break;
                    }
                }
                else Console.WriteLine("wrong input");
            }
        }
    }
}

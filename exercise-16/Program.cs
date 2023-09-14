using System;
using System.IO;
using System.IO.Enumeration;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace exercise_16
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\mokshmahajan\MyFolder";
            DirectoryInfo topfiles = new DirectoryInfo(path);
            var topLargestFiles = topfiles.GetFiles("*", SearchOption.AllDirectories).OrderByDescending(file => file.Length).Take(5).ToList();
            Console.WriteLine("Enter 1 for Return the Number of Text Files in the Directory!");
            Console.WriteLine("Enter 2 for Return the Number of Files per Extension Type!");
            Console.WriteLine("Enter 3 for Return the Top 5 Largest Files with Their Size!");
            Console.WriteLine("Enter 4 for Return the File with Maximum Length!");
            if(int.TryParse(Console.ReadLine(), out int choice))
            {
                switch(choice)
                {
                    case 1:
                        var textfiles = Directory.GetFiles(path, "*txt", SearchOption.AllDirectories).Length;
                        Console.WriteLine("Number of txt files is {0}", textfiles);
                        break;

                    case 2:
                        var di = new DirectoryInfo(path);
                        var extensionCounts = di.EnumerateFiles("*.*", SearchOption.AllDirectories)
                                                .GroupBy(x => x.Extension)
                                                .Select(g => new { Extension = g.Key, Count = g.Count() })
                                                .ToList();

                        foreach (var group in extensionCounts)
                        {
                            Console.WriteLine("There are {0} files with extension {1}", group.Count,
                                                                                        group.Extension);
                        }
                        break;

                    case 3:
                        Console.WriteLine("\nThe Top 5 Largest Files with Their Size: \n");
                        Console.WriteLine("{0, -30}{1, -5}", "File Name", "File Size(in KB)");
                        foreach (FileInfo fileInfo in topLargestFiles)
                            Console.WriteLine("{0, -30}{1, -5}", fileInfo.Name, fileInfo.Length / 1024F);
                        break;

                    case 4:
                        if (topLargestFiles.Count != 0)
                            Console.WriteLine("\nThe File '{0}' has Maximum Length in the Directory and the Size is {1}KB!", ((FileInfo)topLargestFiles[0]).Name, ((FileInfo)topLargestFiles[0]).Length / 1024F);
                        break;

                    default:
                        Console.WriteLine("Enter value from above menu");
                        break;
                }

            }
            else Console.WriteLine("enter covertable value");
        }
    }
}

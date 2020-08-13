using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streams
{
    class Program
    {
        public static void WriteFile(string path)                          // Method to write Data into file
        {
            try                                                            // If file doesn't exist handle the exeption
            {


                using (FileStream fs = new FileStream(path, FileMode.CreateNew)) // create new stream with CreateMode
                {
                    using (var sw = new StreamWriter(fs, Encoding.Unicode)) // create StreamWriter to wrire the Data
                    {
                        const int rows = 2;                                 // write the Data
                        const int cols = 3;
                        double[,] doubleArray = { { 1.1, 2.2, 3.3 }, { 4.4, 5.5, 6.6 } };
                        int[,] intArray = new int[rows, cols] { { 1, 2, 3 }, { 4, 5, 6 } };
                        sw.WriteLine("Ivanov Ivan Ivanich, 01.01.2001");
                        for (int i = 0; i < 2; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                sw.Write(doubleArray[i, j] + "  ");
                            }
                            sw.WriteLine();
                        }
                        foreach (int item in intArray)
                        {
                            sw.Write(item + " ");
                        }
                        sw.WriteLine();                                                   // pass the Data into file
                        sw.WriteLine($"Integer array has {rows} rows, and {cols} cols");
                        sw.WriteLine(DateTime.Now);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            };
        }
        public static void ReadFile(string path)                                // Method to read the Data from the file
        {
            using(FileStream fs = new FileStream(path, FileMode.Open))          // Create File stream with open mode
            {
                using(StreamReader sr = new StreamReader(fs, Encoding.Unicode)) // Use StreamReader to read the Data from file
                {
                    Console.WriteLine(sr.ReadToEnd());                          // read to the end of file
                }
            }
        }
        static void Main(string[] args)
        {
            string path = @"test.dat";            // file's full name
            while (true)
            {
                Console.WriteLine("To write data in to file - press 1, to read data from file press 2");
                string choose = Console.ReadLine();
               
                if (choose == "1")
                {
                    WriteFile(path);                      // invoke write method
                }
                else if(choose == "2")
                {
                    ReadFile(path);                       // invoke read method
                }
                else Console.WriteLine("Invalid value");
            }
        }
    }
   
}

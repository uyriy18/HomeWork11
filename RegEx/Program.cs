using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegEx
{
    class Program
    {
        

        public static string ReadFile(string path)  // Read text from data
        {
            using(FileStream fs = new FileStream(path, FileMode.Open))
            {
                using(StreamReader sr = new StreamReader(fs, Encoding.UTF8))
                {
                    string text = sr.ReadToEnd();
                    return text;
                }
            }
        }
        public static void Writefile(string text)  //write to txt file
        {
            using(FileStream fs = new FileStream("Result_Text.txt", FileMode.Create))
            {
                using(StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    StringBuilder resultText = new StringBuilder(text.Length);  // create string builder for string reverse
                    for( int i = text.Length - 1; i > 0; i--)
                    {
                        resultText.Append(text[i]);                             // put string in stringbuilder in reverse order
                    }
                    sw.WriteLine(resultText);
                    Console.WriteLine("------------------Text was saved------------------");
                    Console.WriteLine("Result text :\n\n" + resultText);        // show the result
                }
            }
        }

        static void Main(string[] args)
        {
            string path = @"text1.txt";                       // path to .txt file
            string text = ReadFile(path);
            string pattern1 = @"\w+\s{2,}\w+";                         // create pattern to remove all unnecessary spaces
            string resultText = Regex.Replace(text, "public", "private");  // change "public" to "private"
            string[] resultArray = resultText.Split(' ');     // turn string to array by spliting it with spases
            resultText = "";                         // delete the result string
            foreach(string item in resultArray)
            {
                string temp = "";
                if (Regex.IsMatch(item, @"\w+"))  //if the item consists 2 or more leters
                {
                    temp = item.ToUpper();           //to upper case
                    resultText += temp + " ";              //add to result string word in upper case
                }
                if(Regex.IsMatch(item, @"\d,\w*"))
                {
                    resultText += item + " ";        //add to result string not changed word
                }       
            }
           
            Console.WriteLine(text);                 //show original text
            Writefile(resultText);                   
        }
    }
}

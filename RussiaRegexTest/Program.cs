using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RussiaRegexTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Use this regex to allow French, German, etc special chars: [^A-Za-z0-9\x80-\xFF-]
            string russian = "Черные штаны прямого покроя с эластичным поясом - PETITE Размеры Плюс от 16 до 32";
            string english = "Black Classic Straight Leg Trousers With Elasticated Waistband - PETITE";

            russian = russian.Trim().Replace(" ", "-");
            english = english.Trim().Replace(" ", "-");

            russian = "/" + Regex.Replace(russian, "[^A-Za-z0-9\x80-\xFF-\u0400-\u04FF]", "");
            while (russian.IndexOf("--") > -1) russian = russian.Replace("--", "-");

            english = "/" + Regex.Replace(english, "[^A-Za-z0-9\x80-\xFF-]", "");
            while (english.IndexOf("--") > -1) english = english.Replace("--", "-");

            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine(russian + "\n" + english + "\nPress any key to continue");
            Console.ReadKey();
        }
    }
}

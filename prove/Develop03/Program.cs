using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // 
        string fileName1 = "Proverbs_3_5-6.txt";
        string fileName2 = "2_Nephi_2_11-16.txt";
        // Reference\nVerse\nVerse\n...
        string[] lines = File.ReadAllLines(fileName1);
        string reference = lines[0];

        List<string> verseList = new List<string>(lines.Skip(1));
        Scripture _scripture1 = new Scripture(reference, verseList);

        string input = "";
        while (input != "Quit")
        {

            _scripture1.renderScripture();

            Console.WriteLine();
            Console.WriteLine("Press Enter to continue, type 'Quit' to Exit. ");

            input = Console.ReadLine();

            _scripture1.hideThreeWords();
        }

    }
}
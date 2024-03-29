﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;

namespace emeltinfo2007
{
    class Program
    {
        static void Main(string[] args)
        {
            #region "1. Feladat"
            Console.WriteLine("Kérnék egy betűt!");

            string letterkeypadnumber = GetKeypadNumberByLetter(char.Parse(Console.ReadLine()));

            Console.WriteLine("Ehhez a betűhöz ez a szám tartozik: " + letterkeypadnumber);
            #endregion

            #region "2. Feladat"
            Console.WriteLine("Kérnék egy szót!");

            string chosenword = Console.ReadLine();
            string wordkeypadnumbers = "";

                foreach (char letter in chosenword)
                {
                    wordkeypadnumbers += GetKeypadNumberByLetter(letter);
                }

            Console.WriteLine("Ehhez a szóhoz ezek a számok tartoznak: " + wordkeypadnumbers);
            #endregion

            #region "3. Feladat"
            List<string> words = new List<string>(File.ReadAllLines("data/szavak.txt"));
            #endregion

            #region "4. Feladat"
            Console.WriteLine("A leghosszabb tárolt szó: " + words.OrderByDescending(word => word.Length).First().ToString());
            #endregion

            #region "5. Feladat"
            Console.WriteLine("Ennyi rövid szó található: " + words.FindAll(word => word.Length <= 5).Count());
            #endregion

            #region "6. Feladat"
            List<string> keypadnumbersforwords = new List<string>();

            foreach (string word in words)
            {
                string buffer = "";

                foreach (char letter in word)
                {
                    buffer += GetKeypadNumberByLetter(letter);
                }
                keypadnumbersforwords.Add(buffer);
                buffer = "";
            }

            if (File.ReadLines("data/kodok.txt").Count() == 0)
            {
                File.WriteAllLines("data/kodok.txt", keypadnumbersforwords.ToArray());
            }
            #endregion

            #region "7. Feladat"
            Console.WriteLine("Kérnék egy számsort:");
            string chosennumber = Console.ReadLine();

            List<WordsWithNumbers> grouped = new List<WordsWithNumbers>();

            for (int i = 0; i < 524; i++)
            {
                grouped.Add(new WordsWithNumbers() { Word = words[i], Number =  keypadnumbersforwords[i] });
            }

            List<WordsWithNumbers> wordbynumber = new List<WordsWithNumbers>(grouped.Where(element => element.Number == chosennumber));

            Console.WriteLine("Ehhez a számsorhoz, ha van több, ez(ek) a szavak tartoznak:");
            foreach (WordsWithNumbers item in wordbynumber)
            {
                Console.WriteLine(item.Word);
            }
            #endregion
            
            #region "8. Feladat / 9. Feladat"

            var query = grouped.GroupBy(wordswithnumbers => wordswithnumbers.Number);

            List<WordsWithNumbers> duplicate = new List<WordsWithNumbers>();

            Console.WriteLine("Ezekhez a kódokhoz tartozik több szó:");
            foreach (var item in query)
            {
                if (item.Count() >= 2)
                {
                    foreach (var y in item)
                    {
                        duplicate.Add(new WordsWithNumbers() { Word = y.Word, Number = y.Number });
                        Console.Write(y.Word + " : " + y.Number + "; ");
                    }
                }
            }

            Console.WriteLine(Environment.NewLine + "Ehhez a kódhoz tartozik a legtöbb szó:");

            var dd = duplicate.GroupBy(xd => xd.Number).OrderByDescending(igro => igro.Key.Count());

            foreach (var item in dd)
            {
                Console.WriteLine(item.Key);
                foreach (var y in item)
                {
                    Console.WriteLine(y.Word);
                }
            }

            #endregion

            Console.ReadLine();
        }

        public static string GetKeypadNumberByLetter(char letterparam)
        {
            char letter = char.ToUpper(letterparam);
            string number = "";

            if (letter == 'A' | letter == 'B' | letter == 'C')
            {
                number = "2";
                return number;
            }
            else if (letter == 'D' | letter == 'E' | letter == 'F')
            {
                number = "3";
                return number;
            }
            else if (letter == 'G' | letter == 'H' | letter == 'I')
            {
                number = "4";
                return number;
            }
            else if (letter == 'J' | letter == 'K' | letter == 'L')
            {
                number = "5";
                return number;
            }
            else if (letter == 'M' | letter == 'N' | letter == 'O')
            {
                number = "6";
                return number;
            }
            else if (letter == 'P' | letter == 'Q' | letter == 'R' || letter == 'S')
            {
                number = "7";
                return number;
            }
            else if (letter == 'A' | letter == 'B' | letter == 'C')
            {
                number = "8";
                return number;
            }
            else if (letter == 'A' | letter == 'B' | letter == 'C')
            {
                number = "9";
                return number;
            }
            return number;
        }

        class WordsWithNumbers
        {
            public string Word { get; set; }
            public string Number { get; set; }
        }
    }
}

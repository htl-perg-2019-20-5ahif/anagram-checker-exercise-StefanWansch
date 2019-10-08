using AnagramChecker;
using AnagramChecker.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;


namespace ConsoleAppAnagram
{
    class Program
    {
        static void Main(string[] args)
        {

            if (args.Length != 0)
            {
                if (args[0] == "check")
                {
                    checkAnagram(args);

                }
                else if (args[0] == "getKnown")
                {
                    IConfiguration config = new ConfigurationBuilder().AddJsonFile("config.json").Build();
                    getKnownWords(args,config);
                }
                else
                {
                    Console.WriteLine("Keine Methode mit diesem Namen gefunden");
                }
            }

           


        } 
        public static void checkAnagram(String[]args)
        {
            Words w = new Words();
            Boolean checkAnagram = w.check(args[1], args[2]);
            if (checkAnagram)
            {
                Console.WriteLine(args[1] + " and " + args[2] + " are anagrams");
            }
            else
            {
                Console.WriteLine(args[1] + " and " + args[2] + " are no anagrams");
            }
        }
        public static void getKnownWords(String[] args, IConfiguration config)
        {

            IDictionaryReader reader = new DictionaryFileReader(config);
            Words w = new Words();
            string dictionaryText = reader.ReadDictionary();
            List<string> words = w.getKnownWords(dictionaryText, args[1]);

            if (words.Count != 0)
            {
                foreach (string s in words)
                {
                    Console.WriteLine(s);
                }
            }
            else
            {
                Console.WriteLine("No known anagrams found");
            }
           
            

        }

    }
}

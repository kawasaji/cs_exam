using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Serl;

namespace DictionaryService
{
    internal class Dictionary : ISerialiazation
    {
        public Dictionary() { }

        public void CreateDictionary()
        {
            Console.Clear();

            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Write("enter first language~# ");
            FirstLanguageName = Console.ReadLine();

            Console.Write("enter second language~# ");
            LastLanguageName = Console.ReadLine();
        }

        public void PrintDictionary()
        {
            Console.Clear();

            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Dictionary ->\n");

            Console.WriteLine($"{FirstLanguageName.ToUpper()} -> {LastLanguageName.ToUpper()}");

            for (int i = 0; i < translationPairs.Count; i++)
            {
                Console.WriteLine($"\t{i + 1}");
                translationPairs[i].PrintPairs();
            }
        }
        public void RemoveWord()
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int index = new();

            PrintDictionary();

            Console.Write("enter index~# ");

            index = Convert.ToInt32(Console.ReadLine());

            translationPairs.RemoveAt(index);
        }

        public void AddWord()
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int indx = new();
            TranslationPair tmp = new();

            tmp = tmp.CreateTraslationPair();

            translationPairs.Add(tmp);
        }
        

        public void ChangeWord()
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int indx = new();
            string tmp_copy;
            StringBuilder new_word;

            Console.Write("enter word's index~# ");
            indx = Convert.ToInt32(Console.ReadLine());

            Console.Write("enter new word~# ");
            tmp_copy = Console.ReadLine();

            new_word = new StringBuilder(tmp_copy);
            translationPairs[indx].LastLanguageTranslation.Append(new_word);
        }

        public void EditDictionary()
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int choice = new();

            Console.Clear();

            Console.WriteLine(" ~ Edititng Menu ~\n" +
                "[1] - Add word\n" +
                "[2] - Change word\n" +
                "[3] - Remove word\n" +
                "[4] - Exit\n" +
                "\n~# "
                );
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddWord();
                    break;
                case 2:
                    ChangeWord();
                    break;
                case 3:
                    RemoveWord();
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Error");
                    break;
            }
        }

        public void FindWord()
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            StringBuilder tmp = new();
            string tmp_copy;
            bool key = true;
            int i = 0;

            Console.Write($"enter word on {FirstLanguageName.ToUpper()} to find its translation~# ");
            tmp_copy = Console.ReadLine();

            tmp = new StringBuilder(tmp_copy);

            while (key)
            {
                if (translationPairs[i].FirstLanguageTranslation == tmp)
                {
                    translationPairs[i].PrintPairs();
                    key = false;
                }
                i++;
            }
        }

        public void SaveToFile()
        {
            Serializator service = new();

            var json = service.Serialize(this);

            using FileStream fs = new("dictionary_data.json", FileMode.OpenOrCreate);
            using StreamWriter sw = new(fs);

            sw.Write(json);
        }

        public List<TranslationPair> translationPairs { get; set; }
        public string FirstLanguageName { get; set; }
        public string LastLanguageName { get; set; }
    }

    class TranslationPair : ISerialiazation
    {
        public TranslationPair() { }

        public TranslationPair(StringBuilder firstLanguageTranslation, StringBuilder[] lastLanguageTranslation)
        {
            FirstLanguageTranslation = firstLanguageTranslation;
            LastLanguageTranslation = lastLanguageTranslation;
        }

        public StringBuilder[] CreateTranslation()
        {
            Console.Clear();

            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine(" ~ translations ~");
            Console.Write("enter amount of words~# ");

            int number = Convert.ToInt32(Console.ReadLine());
            string tmp_copy;

            StringBuilder[] tmp = new StringBuilder[number];

            for (int i = 0; i < number; i++)
            {
                Console.Write("enter word~# ");
                tmp_copy = Console.ReadLine();

                tmp[i] = new StringBuilder(tmp_copy);
            }

            return tmp;
        }

        public TranslationPair CreateTraslationPair()
        {
            Console.Clear();

            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            string tmp_copy;

            Console.WriteLine(" ~ Translation Pair ~\n");

            Console.Write("enter word~# ");
            tmp_copy = Console.ReadLine();

            StringBuilder tmpFirstLanguage = new StringBuilder(tmp_copy);
            StringBuilder[] tmpLastLanguage = CreateTranslation();

            TranslationPair tmp = new TranslationPair(tmpFirstLanguage, tmpLastLanguage);

            return tmp;
        }

        public void PrintPairs()
        {
            Console.Clear();

            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("origin language -> ");

            for (int i = 0; i < FirstLanguageTranslation.Length; i++)
            {
                Console.WriteLine(FirstLanguageTranslation[i] + " ");
            }

            Console.WriteLine("translate language ->\n ");

            for (int i = 0; i < LastLanguageTranslation.Length; i++)
            {
                Console.WriteLine(LastLanguageTranslation[i] + " ");
            }
        }

        public void SaveWord()
        {
            Serializator service = new();

            var json = service.Serialize(this);

            using FileStream fs = new("res_file.json", FileMode.OpenOrCreate);
            using StreamWriter sw = new(fs);

            sw.Write(json);
        }

        public StringBuilder FirstLanguageTranslation { get => FirstLanguageTranslation; set => FirstLanguageTranslation = value; }
        public StringBuilder[] LastLanguageTranslation { get => LastLanguageTranslation; set => LastLanguageTranslation = value; }
    }
}

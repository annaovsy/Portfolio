using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Dictionaries
{
    class StartProgram
    {
        List<Dictionary<string, string>> dictionaries = new List<Dictionary<string, string>>();
        char choise;
        char actionChoise;
        string Word;
        string Translation;
        XmlDocument xdoc = new XmlDocument();
        DictionaryClass dictionaryClass;
        string path;

        public void Print()
        {
            Console.Clear();
            Console.WriteLine("\t  Выберите действие:");
            Console.WriteLine("\t* 1 - Добавить слово и его перевод в словарь");
            Console.WriteLine("\t* 2 - Заменить перевод слова ");
            Console.WriteLine("\t* 3 - Удалить слово и его перевод ");
            Console.WriteLine("\t* 4 - Искать перевод слова ");
            Console.WriteLine("\t* 5 - Добавить слово и его перевод в Файл ");
            Console.WriteLine("\t* 6 - Просмотреть словарь ");
            Console.WriteLine("\t* 7 - Вернуться в предыдущее меню ");
            Console.WriteLine("\t* 8 - Выход ");
        }

        public void Action(string title, string path)
        {           
            while (true)
            {
                Console.Clear();
                Print();
                actionChoise = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (actionChoise == '1')
                {
                    Console.WriteLine("Слово : ");
                    Word = Console.ReadLine();
                    Console.WriteLine("Перевод : ");
                    Translation = Console.ReadLine();
                    if (dictionaryClass.AddWord(Word, Translation))
                        Console.WriteLine($"Слово {Word}({Translation}) ДОБАВЛЕНО!");
                }
                else if (actionChoise == '2')
                {
                    Console.WriteLine("Слово : ");
                    Word = Console.ReadLine();
                    Console.WriteLine("Новый перевод : ");
                    Translation = Console.ReadLine();
                    if (dictionaryClass.ReplaceWord(Word, Translation))
                        Console.WriteLine($"Слово \"{Word}\" ИЗМЕНЕНО!");
                    else
                        Console.WriteLine($"Error! Слово \"{Word}\" не найдено!");

                }
                else if (actionChoise == '3')
                {
                    dictionaryClass.WordList();
                    Console.WriteLine("\tВведите слово: ");
                    Word = Console.ReadLine();
                    if (dictionaryClass.RemoveWord(Word))
                        Console.WriteLine($"Слово \"{Word}\" УДАЛЕНО!");
                    else
                        Console.WriteLine($"Error! Слово \"{Word}\" не найдено!");

                }
                else if (actionChoise == '4')
                {
                    Console.WriteLine("Слово : ");
                    Word = Console.ReadLine();
                    if (dictionaryClass.SearchWord(Word))
                        Console.WriteLine($"ПЕРЕВОД - {Translation}");
                    else
                        Console.WriteLine("Слово не найдено!");
                }
                else if (actionChoise == '5')
                {
                    dictionaryClass.WordList();
                    Console.WriteLine("\nКакое слово хотите записать в файл? ");
                    Word = Console.ReadLine();
                    Console.WriteLine("Название файла : ");
                    string filename = Console.ReadLine();
                    if (dictionaryClass.SaveWordToFile(filename, Word))
                        Console.WriteLine("Файл успешно записан!");
                    else
                        Console.WriteLine("Error! Файл не может быть записан!");
                }
                else if (actionChoise == '6')
                {
                    dictionaryClass.Print(title);
                }
                else if (actionChoise == '7')
                {
                    Console.Clear();
                    Menu();
                }
                else if (actionChoise == '8')
                {
                    Console.WriteLine("\t*** До свидания! ***");
                    Process.GetCurrentProcess().Kill();
                }
                dictionaryClass.SaveDictionaryToXml(path, dictionaryClass.dictionary);
                dictionaryClass.SaveFile("DictionaryEngRus.txt", title);
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void Menu()
        {
            Console.WriteLine("\n\tДобро пожаловать!");
            Console.WriteLine("\n Выберите словарь:\n");
            Console.WriteLine(" 1 - Русско-английский\n 2 - Англо-русский\n 3 - Создать словарь\n 4 - Выход");
            choise = Console.ReadKey().KeyChar;
            Console.WriteLine();
            do
            {
                if (choise == '1')
                {
                    path = "RusEng.xml";
                    dictionaryClass = new DictionaryClass();
                    dictionaryClass.dictionary = new Dictionary<string, string>();
                    dictionaryClass.dictionary = dictionaryClass.ReadXml(path);
                    dictionaries.Add(dictionaryClass.dictionary);
                    Action("\t* Русско-английский словарь *\n", path);
                }
                else if (choise == '2')
                {
                    path = "EngRus.xml";
                    dictionaryClass = new DictionaryClass();
                    dictionaryClass.dictionary = new Dictionary<string, string>();
                    dictionaryClass.dictionary = dictionaryClass.ReadXml(path);
                    dictionaries.Add(dictionaryClass.dictionary);
                    Action("\t* Англо - русский словарь *\n", path);
                }
                else if (choise == '3')
                {
                    Console.WriteLine("Введите название словаря:");
                    string newName = Console.ReadLine();
                    path = $"{newName}.xml";
                    XDocument xdoc = new XDocument();
                    xdoc.Add(new XElement("dictionary"));
                    xdoc.Save(path);
                    dictionaryClass = new DictionaryClass();
                    dictionaryClass.dictionary = new Dictionary<string, string>();
                    dictionaryClass.dictionary = dictionaryClass.ReadXml(path);
                    dictionaries.Add(dictionaryClass.dictionary);
                    Action($"\t* {newName} *\n", path);
                }
                else if (choise == '4')
                {
                    Console.WriteLine("\t*** До свидания! ***");
                    Process.GetCurrentProcess().Kill();
                }
            } while (choise != '4');

        }

    }
}

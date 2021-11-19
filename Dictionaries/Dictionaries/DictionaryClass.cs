using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Dictionaries
{
    class DictionaryClass
    {
        //Dictionary<string, string> dictionary = new Dictionary<string, string>();
        public Dictionary<string, string> dictionary { get; set; }

        public string Word { get; set; }
        public string Translation { get; set; }
        XDocument xdoc = new XDocument();

        public bool AddWord(string Word, string Translation)
        {
            try
            {
                dictionary.Add(Word, Translation);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool RemoveWord(string Word)
        {
            if (dictionary.ContainsKey(Word))
            {
                dictionary.Remove(Word);
                return true;
            }
            else
                return false;
        }

        public bool ReplaceWord(string Word, string translate)
        {
            if (dictionary.ContainsKey(Word))
            {
                dictionary[Word] = translate;
                return true;
            }
            else
                return false;
        }

        public bool SearchWord(string Word)
        {
            if (dictionary.TryGetValue(Word, out var translate))
                return true;

            else
                return false;
        }

        public void WordList()
        {
            Console.WriteLine("\tСписок слов: ");
            foreach (var item in dictionary)
            {
                Console.WriteLine(item.Key);
            }
        }

        public void Print(string title)
        {
            Console.WriteLine(title);
            foreach (var item in dictionary)
            {
                Console.WriteLine($"СЛОВО - {item.Key}");
                Console.WriteLine($"ПЕРЕВОД - {item.Value}");
                Console.WriteLine("----------------------------------");
            }
        }

        public bool SaveWordToFile(string filename, string Word)
        {
            using (FileStream file = new FileStream(filename, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter(file))
                {
                    if (dictionary.TryGetValue(Word, out var translate))
                    {
                        writer.WriteLine($"CЛОВО - {Word}");
                        writer.WriteLine($"ПЕРЕВОД - {translate}");
                        return true;
                    }
                    else
                        return false;
                }
            }
        }

        public void SaveFile(string filename, string title)
        {
            using (FileStream file = new FileStream(filename, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter(file))
                {
                    writer.WriteLine(title);
                    writer.WriteLine();
                    foreach (var item in dictionary)
                    {
                        writer.WriteLine($"СЛОВО - {item.Key}");
                        writer.WriteLine($"ПЕРЕВОД - {item.Value}");
                        writer.WriteLine("----------------------------------");
                    }
                }
            }
        }

        public Dictionary<string, string> ReadXml(string path)
        {
            try
            {
                xdoc = XDocument.Load(path);
                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                XElement baseElem = xdoc.Element("dictionary");
                foreach (var elem in baseElem.Elements())
                {
                    string dictKey = elem.Element("Word").Value;
                    string dictVal = elem.Element("Translation").Value;

                    dictionary.Add(dictKey, dictVal);
                }
            }
            catch(XmlException ex)
            {

            }           
            return dictionary;
        }

        public void SaveDictionaryToXml(string path, Dictionary<string, string> dict)
        {
            xdoc.RemoveNodes();
            xdoc = new XDocument(new XElement("dictionary"));
            foreach (var elem in dict)
            {
                XElement root = new XElement("element");
                root.Add(new XElement("Word", elem.Key));
                root.Add(new XElement("Translation", elem.Value));
                xdoc.Element("dictionary").Add(root);               
            }
            xdoc.Save(path);
        }
    }
}

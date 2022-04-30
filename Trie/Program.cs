using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trie_Lesson
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var trie = new Trie<int>();

            trie.Add("привет", 50);
            trie.Add("приз", 10);
            trie.Add("мир", 60);
            trie.Add("пристань", 70);
            trie.Add("парень", 40);
            trie.Add("лошадь", 90);
            trie.Add("кроль", 40);
            trie.Add("капитан", 30);
            trie.Add("капля", 10);
            trie.Add("мирный", 90);
            trie.Add("легко", 70);
            trie.Add("легкий", 55);


            

            Search(trie, "мирный");

            Search(trie, "пристань");

            Search(trie, "кроль");

            Console.WriteLine("Происходит удаление.");

            trie.Remove("мирный");

            trie.Remove("пристань");

            trie.Remove("кроль");

            Search(trie, "мирный");

            Search(trie, "пристань");

            Search(trie, "кроль");









            Console.ReadLine();

        }


        private static void Search(Trie<int> trie, string word)
        {
            if (trie.TrySearch(word, out int value))
            {
                Console.WriteLine(word + " " + value);
            }
            else
            {
                Console.WriteLine("Не найдено " + word);
            }
        }








    }
}

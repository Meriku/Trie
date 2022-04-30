using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trie_Lesson
{
    public class Trie<T>
    {

        private Node<T> Root;

        public int Count { get; set; }



        public Trie()
        {
            Root = new Node<T>('\0', default(T));
            Count = 1;
        }


        public void Add(string key, T data)     // Добавление слова
        {
            AddNode(key, data, Root);

        }




        private void AddNode(string key, T data, Node<T> node)     // Добавление символа (через рекурсию)
        {
            if (string.IsNullOrWhiteSpace(key))
            {

                if (!node.IsWord)
                {
                    node.Data = data;
                    node.IsWord = true;
                }

            }
            else
            {
                var symbol = key[0];
                var subnode = node.TryFind(symbol);
                if (subnode != null)
                {
                    AddNode(key.Substring(1), data, subnode);   
                }
                else
                {
                    var newNode = new Node<T>(key[0], data);
                    node.SubNodes.Add(key[0], newNode);
                    AddNode(key.Substring(1), data, newNode);
                }
            }





        }




        public void Remove (string key)         // Удаление
        {
            RemoveNode(key, Root);
        }


        private void RemoveNode(string key, Node<T> node)         // Удаление
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                if (node.IsWord)
                {
                    node.IsWord = false;
                }
            }
            else
            {
                var subnode = node.TryFind(key[0]);
                if (subnode != null)
                {
                    RemoveNode(key.Substring(1), subnode);
                }
            }
        }







        public bool TrySearch(string key, out T value)             // Поиск
        {
            return SearchNode(key, Root, out value);
        } 


        private bool SearchNode(string key, Node<T> node, out T data)
        {
            data = default(T);
            var result = false;


            if (string.IsNullOrWhiteSpace(key))
            {
                if (node.IsWord)
                {
                    data = node.Data;
                    result = true;
                }
            }
            else
            {
                var subnode = node.TryFind(key[0]);
                if (subnode != null)
                {
                    result = SearchNode(key.Substring(1), subnode, out data);
                }
            }

            return result;
        }


    }
}

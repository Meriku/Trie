using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trie_Lesson
{
    public class Node<T>
    {

        public char  Symbol { get; set; }     // Буква

        public T Data { get; set; }         // Инфо

        public bool IsWord { get; set; }    // Последняя ли буква в слове

        public string Prefix { get; set; }

        public Dictionary<char, Node<T>> SubNodes { get; set; } // Список наследников этого узла 

        public Node(T data)
        {
            Data = data;
        }

        public Node(char key, T data)
        {
            Symbol = key;
            Data = data;
            SubNodes = new Dictionary<char, Node<T>>();
        }

        public Node<T> TryFind(char symbol)
        {

            if (SubNodes.TryGetValue(symbol, out Node<T> value))
            {
                return value;
            }
            else
            {
                return null;
            }
        }


        public override string ToString()
        {
            return Data.ToString();
        }
        public override bool Equals(object obj)
        {

            if (obj is Node<T> item)
            {
                return Data.Equals(item.Data);
            }
            else
            {
                return false;
            }
        }


    }
}

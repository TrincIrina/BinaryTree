using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BinaryTree
{
    // BinarySearchTree - бинарное дерево поиска
    internal class BinarySearchTree : IEnumerable<Node>, IComparable<BinarySearchTree>,
        ICloneable
    {
        // поля
        private Node root;          // корень бинарного дерева
        private List<Node> nodes;   // буфер для хранения узлов дерева
        private int sum = 0;
        public int Sum { get { return sum; } }

        // конструкторы

        // конструктор по умолчанию
        public BinarySearchTree()
        {
            root = null;
            nodes = new List<Node>();
        }

        // методы работы с деревом

        // 1. добавление элемента в бинарное дерево
        public void Add(int key, string value)
        {
            sum += key;
            Node node = new Node(key, value);
            nodes.Add(node);
            if (root == null)
            {
                // если дерево пустое - просто создаем новый узел
                root = node;
            }
            else
            {
                // если дерево непустое
                root.Add(node);
            }
        }

        public void Print()
        {
            Console.WriteLine(this);
        }

        public override string ToString()
        {
            if (root == null)
            {
                return "empty tree";
            }
            StringBuilder sb = new StringBuilder();
            root.BuildString(sb, 0);
            return sb.ToString();
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is BinarySearchTree))
            {
                return false;
            }
            return GetHashCode().Equals(obj.GetHashCode());
        }

        public IEnumerator<Node> GetEnumerator()
        {
            return nodes.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return nodes.GetEnumerator();
        }

        public int Height
        {
            get
            {
                return TreeHeight(root);
            }
        }

        static public int TreeHeight(Node tree)
        {
            if (tree == null) return 0;
            //находим высоту правой и левой ветки, и из них берем максимальную
            //todo если дерево не бинарное, то для поиска макс ветки реализовать цикл
            return 1 + Math.Max(TreeHeight(tree.Left), TreeHeight(tree.Right));
        }

        public int CompareTo(BinarySearchTree other)
        {
            return Height.CompareTo(other.Height);
        }

        public object Clone()
        {
            return new BinarySearchTree()
            {
                root = this.root,
                nodes = this.nodes
            };
        }
    }
}

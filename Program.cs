using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    internal class Program
    {
        class BSTComparer : IComparer<BinarySearchTree>
        {
            public int Compare(BinarySearchTree x, BinarySearchTree y)
            {
                return x.Sum.CompareTo(y.Sum);
            }
        }
        static void TestBinaryTree()
        {
            BinarySearchTree tree = new BinarySearchTree();

            Random random = new Random();
            for (int i = 0; i < 4; i++)
            {
                tree.Add(random.Next(1, 100), $"test#{i}");
            }
            Console.WriteLine($"Height = {tree.Height}");
            BinarySearchTree nodes = (BinarySearchTree)tree.Clone();
            //Console.WriteLine(tree);
            tree.Print();
            //nodes.Print();
            Console.WriteLine("Nodes:");
            foreach (Node node in tree)
            {
                Console.WriteLine(node);
            }
            IEnumerator<Node> enumerator = tree.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Node node = enumerator.Current;
                Console.WriteLine(node);
            }
            Console.WriteLine(tree.CompareTo(nodes));
        }
        static void Main(string[] args)
        {
            /*
            Необходимо выполнить реализацию бинарного дерева на языке C# в свободной форме. Класс бинарного дерева должен позволять:
               - Создавать бинарное дерево
               - Добавлять элементы в бинарное дерево
               - Выводить бинарное дерево на экран через скобочную нотацию 
               - Получать вывод дерева в виде строки скобочной нотации
               Ключи узлов - целые числа, значения узлов - строки, условие бинарного дерева поиска соблюдается по ключам.

               Класс дерева должен переопределять методы класса object: ToString, Equals, GetHashCode. Подумайте над реализацией, можно советоваться с преподавателем.

               Так же необходимо имплементировать интерфейсы:
               - IComparable - сравнение по высоте дерева
               - IEnumerable - перебор всех элементов дерева в любом порядке
               - ICloneable - глубокое копирование дерева

               Реализовать дополнительный компаратор, имплементирующий IComparer, которые сравнивает 2 дерева по сумме ключей этих деревьев.
           */
            TestBinaryTree();
        }
    }
}

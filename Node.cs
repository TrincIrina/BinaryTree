using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    // Node - узел бинарного дерева
    internal class Node
    {
        // поля - ключ и значение
        public int Key { get; set; }
        public string Value { get; set; }

        // ссылки на левое и правое поддеревья
        public Node Left { get; set; }
        public Node Right { get; set; }

        // конструктор
        public Node(int key, string value)
        {
            Key = key;
            Value = value;
            Left = Right = null;
        }

        // рекурсивный  метод добавление нового элемента
        public void Add(Node node)
        {
            // проверить с текущим
            if (node.Key >= Key)
            {
                // вправо
                if (Right == null)
                {
                    Right = node;
                }
                else
                {
                    Right.Add(node);
                }
            }
            else
            {
                // влево
                if (Left == null)
                {
                    Left = node;
                }
                else
                {
                    Left.Add(node);
                }
            }
        }
        
        public void BuildString(StringBuilder sb, int offset)
        {
            string offsetStr = "";
            // вывод значения узла
            for (int i = 0; i < offset; i++)
            {
                offsetStr += "\t";
            }
            sb.Append(offsetStr).Append($"({this}\n");
            // вывод левого поддерева (рекурсивный)
            if (Left != null)
            {
                Left.BuildString(sb, offset + 1);
            }
            else
            {
                sb.Append(offsetStr).Append("\t(none)\n");
            }
            // вывод правого поддерева (рекурсивный)
            if (Right != null)
            {
                Right.BuildString(sb, offset + 1);
            }
            else
            {
                sb.Append(offsetStr).Append("\t(none)\n");
            }
            // заканчиваем вывод узла
            sb.Append(offsetStr).Append(")\n");
        }

        // 
        public override string ToString()
        {
            return $"{Key}:{Value}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int> intBinaryTree = new BinaryTree<int>();
            intBinaryTree.Add(2);
            intBinaryTree.Add(4);
            intBinaryTree.Add(1);
            intBinaryTree.Add(5);
            intBinaryTree.Add(0);
            intBinaryTree.Add(15);
            intBinaryTree.Add(17);
            intBinaryTree.Add(3);
            intBinaryTree.Add(6);
            intBinaryTree.Add(8);

            foreach (var value in intBinaryTree.Postorder())
            {
                Console.WriteLine(value);
            }

            Console.ReadKey();
        }
      
    }
}

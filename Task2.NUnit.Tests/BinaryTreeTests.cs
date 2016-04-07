using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Task2.NUnit.Tests
{
    [TestFixture]
    public class BinaryTreeTests
    {
        [TestCase(ExpectedException = typeof (ArgumentNullException))]
        public void Add_EmptyValue()
        {
            BinaryTree<object> binaryTree = new BinaryTree<object>();
            binaryTree.Add(500);
            binaryTree.Add(null);   
        }

        [TestCase(ExpectedException = typeof(InvalidOperationException))]
        public void Preorder_EmptyTree()
        {
            BinaryTree<string> binaryTree = new BinaryTree<string>();
            binaryTree.Preorder();
        }

        [TestCase(ExpectedException = typeof(InvalidOperationException))]
        public void Inorder_EmptyTree()
        {
            BinaryTree<string> binaryTree = new BinaryTree<string>();
            binaryTree.Inorder();
        }

        [TestCase(ExpectedException = typeof(InvalidOperationException))]
        public void Postorder_EmptyTree()
        {
            BinaryTree<string> binaryTree = new BinaryTree<string>();
            binaryTree.Postorder();
        }

        [TestCase(new [] {2, 5, 15, 0, 4}, Result = new [] {2, 0, 5, 4, 15})]
        [TestCase(new [] {8, 5, 6, 4, 0}, Result = new [] {8, 5, 4, 0, 6 })]
        [TestCase(new [] { 8, 7, 6}, Result = new [] { 8, 7, 6 })]
        [TestCase(new [] {8, 9, 10}, Result = new [] { 8, 9, 10 })]
        [TestCase(new [] {0, 5, 15, 4 ,3}, Result = new [] {0, 5, 4, 3, 15 })]
        public int[] Add_Preorder_Int_DefaultComparer(int[]array)
        {
            BinaryTree<int> binaryTree = new BinaryTree<int>();
            foreach (int t in array)
            {
                binaryTree.Add(t);
            }
            List<int> binaryList = binaryTree.Preorder().ToList();
            return binaryList.ToArray();
        }

        [TestCase(new [] { 2, 5, 15, 0, 4 }, Result = new [] { 0, 2, 4 , 5, 15 })]
        [TestCase(new [] { 8, 5, 6, 4, 0 }, Result = new [] { 0, 4, 5, 6, 8 })]
        [TestCase(new [] { 8, 7, 6 }, Result = new [] { 6, 7, 8 })]
        [TestCase(new [] { 8, 9, 10 }, Result = new [] { 8, 9, 10 })]
        [TestCase(new [] { 0, 5, 15, 4, 3 }, Result = new [] { 0, 3, 4, 5, 15 })]
        public int[] Add_Inorder_IntCustomComparer(int[] array)
        {
            BinaryTree<int> binaryTree = new BinaryTree<int>(new IntComparer());
            foreach (int t in array)
            {
                binaryTree.Add(t);
            }
            List<int> binaryList = binaryTree.Inorder().ToList();
            return binaryList.ToArray();
        }

        [TestCase()]
        public void Add_Postorder_StringDefaultComparer()
        {
            List<string> expected = new List<string>() {"b", "a", "o", "e"};
            BinaryTree<string> binaryTree = new BinaryTree<string>();
            binaryTree.Add("e");
            binaryTree.Add("a");
            binaryTree.Add("b");
            binaryTree.Add("o");
            List<string> binaryList = binaryTree.Postorder().ToList();
            Assert.AreEqual(expected, binaryList);
        }

        [TestCase()]
        public void Add_Postorder_StringCustomComparer()
        {
            List<string> expected = new List<string>() { "o", "b", "a", "e" };
            BinaryTree<string> binaryTree = new BinaryTree<string>(new StringReverseComparer());
            binaryTree.Add("e");
            binaryTree.Add("a");
            binaryTree.Add("b");
            binaryTree.Add("o");
            List<string> binaryList = binaryTree.Postorder().ToList();
            Assert.AreEqual(expected, binaryList);
        }


        [TestCase(ExpectedException = typeof(ArgumentNullException))]
        public void Point_WithoutComparer()
        {
            BinaryTree<Point> binaryTree = new BinaryTree<Point>();
        }

        [TestCase(new[] { 0, 5, 15, 4, 3 }, Result = new[] { 0, 3, 4, 5, 15 })]
        public int[] Book_DefaultComparer(int[] array)
        {
            BinaryTree<Book> binaryTree = new BinaryTree<Book>();
            foreach (int t in array)
            {
                binaryTree.Add(new Book(t));
            }
            List<Book> binaryList = binaryTree.Inorder().ToList();
            return binaryList.Select(x=> x.Price).ToArray();
        }

        [TestCase()]
        public void Book_CustomComparer()
        {
            List<string> expected = new List<string>() {"a", "c", "d", "e"};
            BinaryTree<Book> binaryTree = new BinaryTree<Book>(new BookComparer());
            binaryTree.Add(new Book("e"));
            binaryTree.Add(new Book("c"));
            binaryTree.Add(new Book("a"));
            binaryTree.Add(new Book("d"));
            List<Book> binaryList = binaryTree.Inorder().ToList();
            List<string> actual = binaryList.Select(x => x.Name).ToList();

            Assert.AreEqual(expected, actual);
        }
    }
}

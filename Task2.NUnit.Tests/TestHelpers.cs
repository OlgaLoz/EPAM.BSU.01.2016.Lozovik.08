using System;
using System.Collections.Generic;

namespace Task2.NUnit.Tests
{
    public struct Point
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class Book : IComparable
    {
        public string Name { get; }
        public int Price { get; }

        public Book(int price)
        {
            Price = price;
        }

        public Book(string name)
        {
            Name = name;
        }

        public int CompareTo(object other)
        {
            Book book = other as Book;

            if (Price == book.Price)
                return 0;
            if (Price < book.Price)
                return -1;
            return 1;
        }
    }

    public class BookComparer : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            if (string.Compare(x.Name, y.Name, StringComparison.Ordinal) > 0)
                return 1;
            if (string.Compare(x.Name, y.Name, StringComparison.Ordinal) < 0)
                return -1;
            return 0;
        }
    }

    public class StringReverseComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (string.Compare(x, y, StringComparison.Ordinal) < 0)
                return 1;
            if (string.Compare(x, y, StringComparison.Ordinal) > 0)
                return -1;
            return 0;
        }
    }

    public class IntComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x > y)
                return 1;
            if (x < y)
                return -1;
            return 0;
        }
    }


}

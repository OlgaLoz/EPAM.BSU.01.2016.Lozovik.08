using System;
using System.Runtime.CompilerServices;
using NUnit.Framework;

namespace Task1.NUnit.Tests
{
    [TestFixture]
    public class SquareMatrixTests
    {
        [TestCase(ExpectedException = typeof(ArgumentException))]
        public void Constructor_Test()
        {
            SquareMatrix<int> matrix = new SquareMatrix<int>(-1);
        }

        [TestCase(ExpectedException = typeof(InvalidOperationException))]
        public void Indexator_SetOnBadIndex_Test()
        {
            SquareMatrix<int> matrix = new SquareMatrix<int>(2)
            {
                [1, 1] = 1,
                [2, 2] = 7
            };
        }

        [TestCase(ExpectedException = typeof(InvalidOperationException))]
        public void Indexator_GetFromBadIndex_Test()
        {
            SquareMatrix<int> matrix = new SquareMatrix<int>(2)
            {
                [1, 1] = 1,
                [0, 0] = 7
            };
            int result = matrix[5, 8];
        }

        [TestCase()]
        public void Indexator_Test()
        {
            SquareMatrix<int> matrix = new SquareMatrix<int>(2)
            {
                [1, 1] = 1,
                [0, 0] = 7
            };
            int[,] result = { { 7, 0 }, { 0, 1 } };
            for (int i = 0; i < matrix.Size; i++)
            {
                for (int j = 0; j < matrix.Size; j++)
                {
                    Assert.AreEqual(matrix[i, j], result[i, j]);
                }
            }
        }
    }
}

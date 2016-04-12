using System;
using NUnit.Framework;

namespace Task1.NUnit.Tests
{
    [TestFixture]
    public class DiagonalMatrixTests
    {
        [TestCase(ExpectedException = typeof(ArgumentException))]
        public void BaseConstructor_Test()
        {
            DiagonalMatrix<int> matrix = new DiagonalMatrix<int>(-1);
        }

        [TestCase(ExpectedException = typeof(InvalidOperationException))]
        public void Indexator_SetOnBadIndex_Test()
        {
            Matrix<int> matrix = new DiagonalMatrix<int>(2)
            {
                [1, 1] = 1,
                [2, 2] = 7
            };
        }

        [TestCase(ExpectedException = typeof(InvalidOperationException))]
        public void Indexator_SetOnNotDiagonalIndex_Test()
        {
            Matrix<int> matrix = new DiagonalMatrix<int>(2)
            {
                [1, 2] = 1,
            };
        }

        [TestCase(ExpectedException = typeof(InvalidOperationException))]
        public void Indexator_GetFromBadIndex_Test()
        {
            Matrix<int> matrix = new DiagonalMatrix<int>(2)
            {
                [1, 1] = 1,
                [0, 0] = 7
            };
            int result = matrix[5, 8];
        }

        [TestCase()]
        public void Indexator_Test()
        {
            Matrix<int> matrix = new DiagonalMatrix<int>(3)
            {
                [0, 0] = -4,
                [1, 1] = 1,
                [2, 2] = 7
            };
            int[,] result = { { -4, 0, 0 }, { 0, 1, 0 }, { 0, 0, 7 } };
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

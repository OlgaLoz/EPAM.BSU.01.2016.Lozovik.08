using System;
using NUnit.Framework;

namespace Task1.NUnit.Tests
{
    [TestFixture]
    public class SimmetricMatrixTests
    {
        [TestCase(ExpectedException = typeof(ArgumentException))]
        public void BaseConstructor_Test()
        {
            SimmetricMatrix<int> matrix = new SimmetricMatrix<int>(-1);
        }

        [TestCase(ExpectedException = typeof(InvalidOperationException))]
        public void Indexator_SetOnBadIndex_Test()
        {
            Matrix<int> matrix = new SimmetricMatrix<int>(2)
            {
                [1, 1] = 1,
                [2, 2] = 7
            };
        }

        [TestCase(ExpectedException = typeof(InvalidOperationException))]
        public void Indexator_GetFromBadIndex_Test()
        {
            Matrix<int> matrix = new SimmetricMatrix<int>(2)
            {
                [1, 1] = 1,
                [0, 0] = 7
            };
            int result = matrix[5, 8];
        }

        [TestCase()]
        public void Indexator_Test()
        {
            Matrix<int> matrix = new SimmetricMatrix<int>(3)
            {
                [1, 2] = 1,
                [1, 0] = 7
            };
            int[,] result = { {0, 7, 0}, {7, 0, 1}, {0, 1, 0}};
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
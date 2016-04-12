using System;
using NUnit.Framework;

namespace Task1.NUnit.Tests
{
    [TestFixture]
    public class SumTests
    {
        #region Check result matrix type

        [TestCase(Result = typeof(SquareMatrix<int>))]
        public Type Square_Plus_Square_Test()
        {
            SquareMatrix<int> matrix = new SquareMatrix<int>(3);
            dynamic result = matrix.Add(new SquareMatrix<int>(3));
            return result.GetType();
        }

        [TestCase(Result = typeof(SquareMatrix<int>))]
        public Type Square_Plus_Simmetric_Test()
        {
            SquareMatrix<int> matrix = new SquareMatrix<int>(3);
            dynamic result = matrix.Add(new SimmetricMatrix<int>(3));
            return result.GetType();
        }

        [TestCase(Result = typeof(SquareMatrix<int>))]
        public Type Square_Plus_Diagonal_Test()
        {
            SquareMatrix<int> matrix = new SquareMatrix<int>(3);
            dynamic result = matrix.Add(new DiagonalMatrix<int>(3));
            return result.GetType();
        }

        [TestCase(Result = typeof(SquareMatrix<int>))]
        public Type Simmetric_Plus_Square_Test()
        {
            Matrix<int> matrix = new SimmetricMatrix<int>(3);
            dynamic result = matrix.Add(new SquareMatrix<int>(3));
            return result.GetType();
        }

        [TestCase(Result = typeof(SimmetricMatrix<int>))]
        public Type Simmetric_Plus_Simmetric_Test()
        {
            Matrix<int> matrix = new SimmetricMatrix<int>(3);
            dynamic result = matrix.Add(new SimmetricMatrix<int>(3));
            return result.GetType();
        }

        [TestCase(Result = typeof(SimmetricMatrix<int>))]
        public Type Simmetric_Plus_Diagonal_Test()
        {
            Matrix<int> matrix = new SimmetricMatrix<int>(3);
            dynamic result = matrix.Add(new DiagonalMatrix<int>(3));
            return result.GetType();
        }

        [TestCase(Result = typeof(SquareMatrix<int>))]
        public Type Diagonal_Plus_Square_Test()
        {
            Matrix<int> matrix = new DiagonalMatrix<int>(3);
            dynamic result = matrix.Add(new SquareMatrix<int>(3));
            return result.GetType();
        }

        [TestCase(Result = typeof(SimmetricMatrix<int>))]
        public Type Diagonal_Plus_Simmetric_Test()
        {
            Matrix<int> matrix = new DiagonalMatrix<int>(3);
            dynamic result = matrix.Add(new SimmetricMatrix<int>(3));
            return result.GetType();
        }

        [TestCase(Result = typeof(DiagonalMatrix<int>))]
        public Type Diagonal_Plus_Diagonal_Test()
        {
            Matrix<int> matrix = new DiagonalMatrix<int>(3);
            dynamic result = matrix.Add(new DiagonalMatrix<int>(3));
            return result.GetType();
        }

        #endregion

        #region Check sum result
        [TestCase(ExpectedException = typeof(InvalidOperationException))]
        public void Sum_Object_Matrixes()
        {
            SquareMatrix<object> matrix = new SquareMatrix<object>(3);
            dynamic result = matrix.Add(new SquareMatrix<object>(3));
        }

        [TestCase(ExpectedException = typeof(InvalidOperationException))]
        public void Sum_MatrixesWithDifferentSize()
        {
            SquareMatrix<int> matrix = new SquareMatrix<int>(3);
            dynamic result = matrix.Add(new SquareMatrix<int>(5));
        }

        [TestCase()]
        public void Square_Plus_Simmetric_Sum_Result_Test()
        {
            SquareMatrix<int> matrix = new SquareMatrix<int>(2){ [1, 1] = 1, [0, 0] = 7 };
            Matrix<int> secondMatrix  = new SimmetricMatrix<int>(2){ [0, 1] = 7 };
            
            SquareMatrix<int> sumResult = matrix.Add(secondMatrix);

            int[,] result = { { 7, 7 }, { 7, 1 } };
            for (int i = 0; i < matrix.Size; i++)
            {
                for (int j = 0; j < matrix.Size; j++)
                {
                    Assert.AreEqual(sumResult[i, j], result[i, j]);
                }
            }
        }

        [TestCase()]
        public void Square_Plus_Diagonal_Sum_Result_Test()
        {
            SquareMatrix<int> matrix = new SquareMatrix<int>(2) {[1, 1] = 1,[0, 0] = 7 };
            Matrix<int> secondMatrix = new DiagonalMatrix<int>(2) {[0, 0] = -5 };

            SquareMatrix<int> sumResult = matrix.Add(secondMatrix);

            int[,] result = { { 2, 0 }, { 0, 1 } };
            for (int i = 0; i < matrix.Size; i++)
            {
                for (int j = 0; j < matrix.Size; j++)
                {
                    Assert.AreEqual(sumResult[i, j], result[i, j]);
                }
            }
        }

        [TestCase()]
        public void Square_Plus_Square_Sum_Result_Test()
        {
            SquareMatrix<int> matrix = new SquareMatrix<int>(2) {[1, 1] = 1,[0, 0] = 7 };
            SquareMatrix<int> secondMatrix = new SquareMatrix<int>(2) {[1, 0] = 1,[0, 0] = 7 };

            SquareMatrix<int> sumResult = matrix.Add(secondMatrix);

            int[,] result = { { 14, 0 }, { 1, 1 } };
            for (int i = 0; i < matrix.Size; i++)
            {
                for (int j = 0; j < matrix.Size; j++)
                {
                    Assert.AreEqual(sumResult[i, j], result[i, j]);
                }
            }
        }

        [TestCase()]
        public void Simmetric_Plus_Simmetric_Sum_Result_Test()
        {
            Matrix<int> matrix = new SimmetricMatrix<int>(2) {[0, 0] = 7 };
            Matrix<int> secondMatrix = new SimmetricMatrix<int>(2) {[0, 1] = 7 };

            SimmetricMatrix<int> sumResult = matrix.Add(secondMatrix);

            int[,] result = { { 7, 7 }, { 7, 0 } };
            for (int i = 0; i < matrix.Size; i++)
            {
                for (int j = 0; j < matrix.Size; j++)
                {
                    Assert.AreEqual(sumResult[i, j], result[i, j]);
                }
            }
        }

        [TestCase()]
        public void Simmetric_Plus_Diagonal_Sum_Result_Test()
        {
            SimmetricMatrix<int> matrix = new SimmetricMatrix<int>(2) {[1, 1] = 1,[1, 0] = 7 };
            Matrix<int> secondMatrix = new DiagonalMatrix<int>(2) {[0, 0] = -5 };

            SimmetricMatrix<int> sumResult = matrix.Add(secondMatrix);

            int[,] result = { { -5, 7 }, { 7, 1 } };
            for (int i = 0; i < matrix.Size; i++)
            {
                for (int j = 0; j < matrix.Size; j++)
                {
                    Assert.AreEqual(sumResult[i, j], result[i, j]);
                }
            }
        }

        [TestCase()]
        public void Diagonal_Plus_Diagonal_Sum_Result_Test()
        {
            Matrix<int> matrix = new DiagonalMatrix<int>(2) {[1, 1] = 1,[0, 0] = 7 };
            Matrix<int> secondMatrix = new DiagonalMatrix<int>(2) {[0, 0] = -14 };

            DiagonalMatrix<int> sumResult = matrix.Add(secondMatrix);

            int[,] result = { { -7, 0 }, { 0, 1 } };
            for (int i = 0; i < matrix.Size; i++)
            {
                for (int j = 0; j < matrix.Size; j++)
                {
                    Assert.AreEqual(sumResult[i, j], result[i, j]);
                }
            }
        }

        #endregion
    }
}
using System;
using Microsoft.CSharp.RuntimeBinder;

namespace Task1
{
    public interface IVisitor<T>
    {
        void Visit(SquareMatrix<T> matrix);
        void Visit(DiagonalMatrix<T> matrix);
        void Visit(SimmetricMatrix<T> matrix);
    }

    public static class MatrixExtension
    {
        public static dynamic Add<T>(this Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix == null )
            {
                throw new ArgumentNullException(nameof(firstMatrix));
            }

            if (secondMatrix == null)
            {
                throw new ArgumentNullException(nameof(secondMatrix));
            }

            if (firstMatrix.Size != secondMatrix.Size)
            {
                throw new InvalidOperationException("Matrixes must be equal by size!");
            }

            MatrixVisitor<T> visitor = new MatrixVisitor<T> {SumResult = secondMatrix};
            firstMatrix.Accept(visitor);
            return visitor.SumResult;
        }
    }

    public class MatrixVisitor<T> : IVisitor<T>
    {
        public dynamic SumResult { get; set; }

        public void Visit(SquareMatrix<T> matrix)
        {
            if (SumResult.GetType() != typeof (SquareMatrix<T>))
            {
                dynamic tempMatrix = SumResult;
                SumResult = matrix;
                Visit(tempMatrix);
                return;
            }
            try
            {
                for (int i = 0; i < matrix.Size; i++)
                {
                    for (int j = 0; j < matrix.Size; j++)
                    {
                        SumResult[i, j] = (dynamic) matrix[i, j] + SumResult[i, j];
                    }
                }
            }
            catch (RuntimeBinderException)
            {
                throw new InvalidOperationException($"Can't sum elements of type {typeof (T).Name}");
            }

        }

        public void Visit(SimmetricMatrix<T> matrix)
        {
            if (SumResult.GetType() == typeof(DiagonalMatrix<T>))
            {
                DiagonalMatrix<T> tempDiagonalMatrix = SumResult;
                SumResult = matrix;
                Visit(tempDiagonalMatrix);
                return;
            }
            try
            {
                for (int i = 0; i < matrix.Size; i++)
                {
                    for (int j = 0; j < matrix.Size; j++)
                    {
                        SumResult[i, j] = (dynamic)matrix[i, j] + SumResult[i, j];
                    }
                }
            }
            catch (RuntimeBinderException)
            {
                throw new InvalidOperationException($"Can't sum elements of type {typeof(T).Name}");
            }
        }

        public void Visit(DiagonalMatrix<T> matrix)
        {
            try
            {
                for (int i = 0; i < matrix.Size; i++)
                {
                    SumResult[i, i] = (dynamic)matrix[i, i] + SumResult[i, i];
                }
            }
            catch (RuntimeBinderException)
            {
                throw new InvalidOperationException($"Can't sum elements of type {typeof(T).Name}");
            }
        }
    }
}

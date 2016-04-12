using System;

namespace Task1
{
    public class SquareMatrix<T> : Matrix<T>
    {
        public SquareMatrix(int size) : base(size)
        {
            matrix = new T[Size*Size];
        }

        protected override T IndexatorGet(int i, int j)
        {
            return matrix[i*Size + j];
        }

        protected override void IndexatorSet(int i, int j, T value)
        {
            matrix[i * Size + j] = value;
        }
    }
}

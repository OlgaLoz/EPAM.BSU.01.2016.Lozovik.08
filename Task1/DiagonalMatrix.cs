using System;

namespace Task1
{
    public class DiagonalMatrix<T> : Matrix<T>
    {
        public DiagonalMatrix(int size) : base(size)
        {
            matrix = new T[Size];
        }

        protected override T IndexatorGet(int i, int j)
        {
            return i == j ? matrix[i] : default(T);
        }

        protected override void IndexatorSet(int i, int j, T value)
        {
            if (i != j)
            {
                throw new ArgumentException("Index 'i' must be equal to index 'j'!");
            }

            matrix[i] = value;
        }
    }
}
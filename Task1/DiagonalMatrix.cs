using System;

namespace Task1
{
    public class DiagonalMatrix<T> : SquareMatrix<T>
    {
        public DiagonalMatrix(int size) : base(size){ }

        public override T this[int i, int j]
        {
            get
            {
                CheckIndex(i, j);
                return matrix[i, j];
            }
            set
            {
                CheckIndex(i, j);
                if (i != j)
                {
                    throw new ArgumentException("Index 'i' must be equal to index 'j'!");
                }

                matrix[i, j] = value;
                OnElementChange(new MatrixIndexEventArgs(i, j));
            }
        }
    }
}
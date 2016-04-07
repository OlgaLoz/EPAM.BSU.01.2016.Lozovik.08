using System;

namespace Task1
{
    public class SquareMatrix<T> 
    {
        protected readonly T[,] matrix;
        protected int size;

        public EventHandler<MatrixIndexEventArgs> ElementChange = delegate { };

        public int Size
        {
            get
            {
                return size;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Size of matrix must be more than 0!");
                }
                size = value;
            }
        }

        public SquareMatrix(int size)
        {
            Size = size;
            matrix = new T[size, size];
        }

        public virtual T this[int i, int j]
        {
            get
            {
                CheckIndex(i, j);
                return matrix[i, j];
            }
            set
            {
                CheckIndex(i, j);
                matrix[i, j] = value;
                OnElementChange(new MatrixIndexEventArgs(i, j));
            }
        }

        public void Accept(IVisitor<T> visitor)
        {
            visitor.Visit((dynamic)this);
        }

        protected virtual void OnElementChange(MatrixIndexEventArgs e)
        {
            ElementChange((dynamic)this, e);
        }

        protected void CheckIndex(int i, int j)
        {
            if (i < 0 || j < 0 || i >= Size || j >= Size)
            {
                throw new InvalidOperationException("Bad index!");
            }
        }
    }
}

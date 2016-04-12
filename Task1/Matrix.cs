using System;

namespace Task1
{
    public abstract class Matrix<T>
    {
        protected T[] matrix;
        private int size;
        public EventHandler<MatrixIndexEventArgs> ElementChange = delegate { };


        public int Size
        {
            get
            {
                return size;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Size of matrix must be more than 0!");
                }
                size = value;
            }
        }

        protected Matrix(int size)
        {
            Size = size;
        }

        public virtual T this[int i, int j]
        {
            get
            {
                CommonCheckIndex(i, j);
                return IndexatorGet(i, j);
            }
            set
            {
                CommonCheckIndex(i, j);
                IndexatorSet(i, j, value);
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

        protected void CommonCheckIndex(int i, int j)
        {
            if (i < 0 || j < 0 || i >= Size || j >= Size)
            {
                throw new InvalidOperationException("Bad index!");
            }
        }

        protected abstract T IndexatorGet(int i, int j);

        protected abstract void IndexatorSet(int i, int j, T value);
    }
}
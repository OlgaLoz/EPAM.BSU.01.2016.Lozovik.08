namespace Task1
{
    public class SimmetricMatrix<T> : Matrix<T>
    {
        public SimmetricMatrix(int size) : base(size)
        {
            matrix = new T[Size * (Size - 1)/2 + Size];
        }

        protected override T IndexatorGet(int i, int j)
        {
            if (i < j)
            {
                return matrix[i * (i - 1) / 2 + i + j];
            }
            return matrix[j * (j - 1) / 2 + j + i];
        }

        protected override void IndexatorSet(int i, int j, T value)
        {
            if (i < j)
            {
                matrix[i * (i - 1) / 2 + i + j] = value;
            }
            else
            {
                matrix[j * (j - 1) / 2 + j + i] = value;
            }
            
            OnElementChange(new MatrixIndexEventArgs(j, i));
        }
    }
}
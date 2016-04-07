namespace Task1
{
    public class SimmetricMatrix<T> : SquareMatrix<T>
    {
        public SimmetricMatrix(int size) : base(size){ }

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

                matrix[i, j] = value;
                matrix[j, i] = value;
                OnElementChange(new MatrixIndexEventArgs(i, j));
                OnElementChange(new MatrixIndexEventArgs(j, i));
            }
        }
    }
}
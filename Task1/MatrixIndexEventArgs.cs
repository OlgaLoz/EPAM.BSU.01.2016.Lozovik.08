namespace Task1
{
     public class MatrixIndexEventArgs
        {
            private readonly int i;
            private readonly int j;

            public int I => i;
            public int J => j;

            public MatrixIndexEventArgs(int i, int j)
            {
                this.i = i;
                this.j = j;
            }
        }

}
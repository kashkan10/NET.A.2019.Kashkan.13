namespace Matrices
{
    public static class Summator<T>
    {
        /// <summary>
        /// Square matrix addition
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>Result of addition</returns>
        public static SquareMatrix<T> Add(IMatrix<T> a, IMatrix<T> b)
        {
            if (b.Array.Length > a.Array.Length)
            {
                IMatrix<T> res = b;
                b = a;
                a = res;
            }

            var cloneA = (T[][])a.Array.Clone() as dynamic;
            var cloneB = (T[][])b.Array.Clone() as dynamic;

            for (int i = 0; i < cloneB.Length; i++)
            {
                for (int j = 0; j < cloneB[i].Length; j++)
                {
                    cloneA[i][j] = cloneA[i][j] + cloneB[i][j];
                }
            }

            return new SquareMatrix<T>(cloneA);
        }
    }
}

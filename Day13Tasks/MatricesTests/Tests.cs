using Matrices;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void SumOfTest1()
        {
            int[][] arr = new int[][]
            {
                new int[] { 1, 0, 0 },
                new int[] { 0, 3, 0 },
                new int[] { 0, 0, 6 }
            };

            int[][] arr1 = new int[][]
            {
                new int[] { 1, 1 },
                new int[] { 1, 3 }
            };

            DiagonalMatrix<int> diagMatrix = new DiagonalMatrix<int>(arr);
            SymmetricalMatrix<int> symmMatrix = new SymmetricalMatrix<int>(arr1);

            int[][] expected = new int[][]
            {
                new int[] { 2, 1, 0 },
                new int[] { 1, 6, 0 },
                new int[] { 0, 0, 6 }
            };

            SquareMatrix<int> actual = diagMatrix + symmMatrix;

            Assert.AreEqual(actual.Array, expected);
        }

        [Test]
        public void SumOfTest2()
        {
            int[][] arr = new int[][]
            {
                new int[] { 1, 0, 0 },
                new int[] { 0, 3, 0 },
                new int[] { 0, 0, 6 }
            };
            int[][] arr1 = new int[][]
            {
                new int[] { 1, 1, 2 },
                new int[] { 1, 3, 8 },
                new int[] { 1, 3, 5 }
            };

            DiagonalMatrix<int> diagMatrix = new DiagonalMatrix<int>(arr);
            SquareMatrix<int> sqMatrix = new SquareMatrix<int>(arr1);

            int[][] expected = new int[][]
            {
                new int[] { 2, 1, 2 },
                new int[] { 1, 6, 8 },
                new int[] { 1, 3, 11 }
            };

            SquareMatrix<int> actual = diagMatrix + sqMatrix;

            Assert.AreEqual(actual.Array, expected);
        }

        [Test]
        public void SumOfTest3()
        {
            int[][] arr = new int[][]
            {
                new int[] { 1, 0, 0 },
                new int[] { 0, 3, 0 },
                new int[] { 0, 0, 6 }
            };
            int[][] arr1 = new int[][]
            {
                new int[] { 1, 1 },
                new int[] { 1, 3 },
            };

            SquareMatrix<int> sqMatrix = new SquareMatrix<int>(arr);
            SymmetricalMatrix<int> symmMatrix = new SymmetricalMatrix<int>(arr1);

            int[][] expected = new int[][]
            {
                new int[] { 2, 1, 0 },
                new int[] { 1, 6, 0 },
                new int[] { 0, 0, 6 }
            };

            SquareMatrix<int> actual = sqMatrix + symmMatrix;

            Assert.AreEqual(actual.Array, expected);
        }
    }
}
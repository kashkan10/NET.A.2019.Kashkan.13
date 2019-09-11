using System;

namespace Matrices
{
    public class DiagonalMatrix<T> : SquareMatrix<T>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="array"></param>
        public DiagonalMatrix(T[][] array) : base(array)
        {
            this.Array = array;
        }

        /// <summary>
        /// Array property
        /// </summary>
        public override T[][] Array
        {
            get
            {
                return this.array;
            }

            set
            {
                if (this.IsCorrect(value))
                {
                    this.array = value;
                }
                else
                {
                    throw new Exception("Cant represent Diagonal Matrix");
                }
            }
        }

        /// <summary>
        /// Overriding of object.ToString()
        /// </summary>
        /// <returns>string representation</returns>
        public override string ToString()
        {
            string result = string.Empty;
            foreach (T[] t in this.array)
            {
                for (int i = 0; i < t.Length; i++)
                {
                    result += t[i] + " ";
                }

                result += $"\n";
            }

            return result;
        }

        /// <summary>
        /// Overriding of SquareMatrix.IsCorrect()
        /// </summary>
        /// <param name="array"></param>
        /// <returns>Check result</returns>
        protected override bool IsCorrect(T[][] array)
        {
            if (!base.IsCorrect(array))
            {
                return false;
            }

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (!array[i][j].Equals(default(T)) && i != j)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}

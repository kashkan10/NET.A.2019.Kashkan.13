using System;

namespace Matrices
{
    public class SquareMatrix<T> : IMatrix<T>
    {
        private T[][] array;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="array"></param>
        public SquareMatrix(T[][] array)
        {
            Array = array;
        }

        public delegate void NewMatrixEventHandler(object sender, NewMatrixEvantArgs e);

        public event NewMatrixEventHandler OnChange;

        /// <summary>
        /// Array property
        /// </summary>
        public virtual T[][] Array
        {
            get
            {
                return array;
            }

            set
            {
                if (IsCorrect(value))
                {
                    array = value;
                }
                else
                {
                    throw new Exception("Cant represent Square Matrix");
                }
            }
        }

        /// <summary>
        /// Event generator
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="value"></param>
        public void ChangeElement(int i, int j, T value)
        {
            Array[i][j] = value;

            OnChanged(this, new NewMatrixEvantArgs(i, j));
        }

        public override string ToString()
        {
            string result = string.Empty;
            foreach (T[] t in array)
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
        /// Matrix validation
        /// </summary>
        /// <param name="array"></param>
        /// <returns>Check result</returns>
        protected virtual bool IsCorrect(T[][] array)
        {
            int length = array.Length;

            foreach (T[] t in array)
            {
                if (t.Length != length)
                {
                    return false;
                }
            }

            return true;
        }

        protected virtual void OnChanged(object sender, NewMatrixEvantArgs e)
        {
            OnChange?.Invoke(sender, e);
        }
    }
}

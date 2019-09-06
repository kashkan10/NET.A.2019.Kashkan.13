using System;

namespace Matrices
{
    public sealed class NewMatrixEvantArgs : EventArgs
    {
        public readonly string Message;

        public NewMatrixEvantArgs(int i, int j)
        {
            this.I = i;
            this.J = j;
            this.Message = string.Format("[{0}],[{1}] element was changed", i, j);
        }

        public int I { get; }

        public int J { get; }
    }
}

using System.Collections.Generic;

namespace CustomBinarySearchTree.Comparers
{
    internal class IntComparer : IComparer<int>
    {
        public int Compare(int a, int b)
        {
            if (a > b)
            {
                return 1;
            }

            if (a < b)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}

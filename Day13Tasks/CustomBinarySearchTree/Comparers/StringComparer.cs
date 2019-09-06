using System.Collections.Generic;

namespace CustomBinarySearchTree.Comparers
{
    internal class StringComparer : IComparer<string>
    {
        public int Compare(string a, string b)
        {
            return string.Compare(a, b);
        }
    }
}

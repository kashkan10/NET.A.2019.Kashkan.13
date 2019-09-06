using System.Collections.Generic;

namespace CustomBinarySearchTree.Comparers
{
    internal class PointComparer : IComparer<Point>
    {
        public int Compare(Point a, Point b)
        {
            if (a.X > b.X)
            {
                return 1;
            }

            if (a.X < b.X)
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

using System.Collections.Generic;

namespace CustomBinarySearchTree.Comparers
{
    internal class BookComparer : IComparer<Book>
    {
        public int Compare(Book a, Book b)
        {
            return string.Compare(a.ISBN, b.ISBN);
        }
    }
}
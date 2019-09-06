using System;
using CustomBinarySearchTree.Comparers;

namespace CustomBinarySearchTree
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            BinaryTree<Book> bookTreeDef = new BinaryTree<Book>();

            bookTreeDef.Insert(new Book("978-1-10-769989-2", "Dog in the hell", "Pushkin", 1997, "RR.C", 234, 333));
            bookTreeDef.Insert(new Book("978-1-10-763989-2", "Dog in the sky", "Pushkin", 1999, "RR.C", 224, 536));
            bookTreeDef.Insert(new Book("978-1-10-739989-2", "Black lake", "Losna", 2008, "RB.C", 238, 621));

            foreach (Book n in bookTreeDef)
            {
                Console.WriteLine(n);
            }

            Console.WriteLine();
            foreach (Book n in bookTreeDef.InOrder())
            {
                Console.WriteLine(n);
            }

            Console.WriteLine();
            foreach (Book n in bookTreeDef.PostOrder())
            {
                Console.WriteLine(n);
            }

            Console.WriteLine();
            BinaryTree<Book> bookTree = new BinaryTree<Book>(new BookComparer());

            bookTree.Insert(new Book("978-1-10-769989-2", "Dog in the hell", "Pushkin", 1997, "RR.C", 234, 333));
            bookTree.Insert(new Book("978-1-10-763989-2", "Dog in the sky", "Pushkin", 1999, "RR.C", 224, 536));
            bookTree.Insert(new Book("978-1-10-739989-2", "Black lake", "Losna", 2008, "RB.C", 238, 621));

            foreach (Book n in bookTree)
            {
                Console.WriteLine(n);
            }

            Console.WriteLine();
            foreach (Book n in bookTree.InOrder())
            {
                Console.WriteLine(n);
            }

            Console.WriteLine();
            foreach (Book n in bookTree.PostOrder())
            {
                Console.WriteLine(n);
            }

            Console.WriteLine();
            BinaryTree<int> intTreeDef = new BinaryTree<int>();
            intTreeDef.Insert(6);
            intTreeDef.Insert(7);
            intTreeDef.Insert(9);
            intTreeDef.Insert(3);
            intTreeDef.Insert(4);
            intTreeDef.Insert(10);
            intTreeDef.Insert(8);
            intTreeDef.Insert(1);
            
            foreach (int n in intTreeDef)
            {
                Console.WriteLine(n);
            }

            Console.WriteLine();
            foreach (int n in intTreeDef.InOrder())
            {
                Console.WriteLine(n);
            }

            Console.WriteLine();
            foreach (int n in intTreeDef.PostOrder())
            {
                Console.WriteLine(n);
            }

            Console.WriteLine();
            BinaryTree<int> intTree = new BinaryTree<int>(new IntComparer());
            intTree.Insert(6);
            intTree.Insert(7);
            intTree.Insert(9);
            intTree.Insert(3);
            intTree.Insert(4);
            intTree.Insert(10);
            intTree.Insert(8);
            intTree.Insert(1);

            foreach (int n in intTree)
            {
                Console.WriteLine(n);
            }

            Console.WriteLine();
            foreach (int n in intTree.InOrder())
            {
                Console.WriteLine(n);
            }

            Console.WriteLine();
            foreach (int n in intTree.PostOrder())
            {
                Console.WriteLine(n);
            }

            Console.WriteLine();
            BinaryTree<string> stringTree = new BinaryTree<string>(new Comparers.StringComparer());
            BinaryTree<string> stringTreeDef = new BinaryTree<string>();
            stringTree.Insert("hawk");
            stringTree.Insert("eagle");
            stringTree.Insert("jaguar");

            stringTreeDef.Insert("hawk");
            stringTreeDef.Insert("eagle");
            stringTreeDef.Insert("jaguar");
            stringTreeDef.Insert("mouse");

            foreach (string n in stringTree)
            {
                Console.WriteLine(n);
            }

            Console.WriteLine();
            foreach (string n in stringTreeDef.InOrder())
            {
                Console.WriteLine(n);
            }

            Console.WriteLine();
            foreach (string n in stringTreeDef.PostOrder())
            {
                Console.WriteLine(n);
            }

            Console.WriteLine();
            BinaryTree<Point> pointTree = new BinaryTree<Point>(new PointComparer());

            pointTree.Insert(new Point(3, 5));
            pointTree.Insert(new Point(6, 5));
            pointTree.Insert(new Point(8, 56));
            pointTree.Insert(new Point(1, 7));

            foreach (Point n in pointTree)
            {
                Console.WriteLine($"{n.X}, {n.Y}");
            }

            Console.WriteLine();
            foreach (Point n in pointTree.InOrder())
            {
                Console.WriteLine($"{n.X}, {n.Y}");
            }

            Console.WriteLine();
            foreach (Point n in pointTree.PostOrder())
            {
                Console.WriteLine($"{n.X}, {n.Y}");
            }

            Console.Read();
        }
    }
}

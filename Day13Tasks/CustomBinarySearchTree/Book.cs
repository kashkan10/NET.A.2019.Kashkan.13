using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace CustomBinarySearchTree
{
    public class Book : IComparable
    {
        private string isbn;
        private double price;
        private int year;
        private int countOfPages;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="isbn"></param>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="year"></param>
        /// <param name="publishing"></param>
        /// <param name="countOfPages"></param>
        /// <param name="price"></param>
        public Book(string isbn, string title, string author, int year, string publishing, int countOfPages, double price)
        {
            ISBN = isbn;
            Title = title;
            Author = author;
            Year = year;
            Publishing = publishing;
            CountOfPages = countOfPages;
            Price = price;
        }

        /// <summary>
        /// ISBN property
        /// </summary>
        public string ISBN
        {
            get
            {
                return isbn;
            }

            private set
            {
                if (Regex.IsMatch(value, @"\d{3}-\d{1}-\d{2}-\d{6}-\d{1}"))
                {
                    isbn = value;
                }
                else
                {
                    throw new FormatException("Wrong format of ISBN");
                }
            }
        }

        /// <summary>
        /// Name property
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// Author property
        /// </summary>
        public string Author { get; private set; }

        /// <summary>
        /// Publishing property
        /// </summary>
        public string Publishing { get; private set; }

        /// <summary>
        /// Year property
        /// </summary>
        public int Year
        {
            get
            {
                return year;
            }

            private set
            {
                if (value < 0)
                {
                    throw new Exception("Year cannot be negative");
                }

                year = value;
            }
        }

        /// <summary>
        /// CountOfPages property
        /// </summary>
        public int CountOfPages
        {
            get
            {
                return countOfPages;
            }

            private set
            {
                if (value < 0)
                {
                    throw new Exception("Count of pages cannot be negative");
                }

                countOfPages = value;
            }
        }

        /// <summary>
        /// Price property
        /// </summary>
        public double Price
        {
            get
            {
                return price;
            }

            private set
            {
                if (value < 0)
                {
                    throw new Exception("Price cannot be negative");
                }

                price = value;
            }
        }

        /// <summary>
        /// Override of GetHashCode() method
        /// </summary>
        /// <returns>Hash code of object</returns>
        public override int GetHashCode()
        {
            return Title.Length * Author.Length * Year;
        }

        /// <summary>
        /// Override of Equals(object obj) method
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Equality result</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            Book book = obj as Book;
            if (book == null)
            {
                return false;
            }

            if (book.GetHashCode() != this.GetHashCode())
            {
                return false;
            }

            return book.ISBN == this.ISBN;
        }

        /// <summary>
        /// IComparable implementation
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Comprasion result</returns>
        public int CompareTo(object obj)
        {
            Book book = obj as Book;
            if (book == null)
            {
                throw new Exception();
            }

            return string.Compare(this.Title, book.Title);
        }

        /// <summary>
        /// Override of ToString() method
        /// </summary>
        /// <returns>String representation</returns>
        public override string ToString()
        {
            return ToString("default");
        }

        /// <summary>
        /// Different formats of string representation
        /// </summary>
        /// <returns>String representation</returns>
        public string ToString(string str)
        {
            CultureInfo.CurrentCulture = new CultureInfo("en-US", false);
            switch (str)
            {
                case "A": return string.Format($"{Author}, {Title}");
                case "B": return string.Format($"{Author}, {Title}, {Publishing}, {Year}");
                case "C": return string.Format($"ISBN 13: {ISBN}, {Author}, {Title}, {Publishing}, {Year}, P. {CountOfPages}");
                case "D": return string.Format($"ISBN 13: {ISBN}, {Author}, {Title}, {Publishing}, {Year}, P. {CountOfPages}, {Price}{NumberFormatInfo.CurrentInfo.CurrencySymbol}");
                default: return string.Format($"{Author}, {Title}, {Year}");
            }
        }
    }
}

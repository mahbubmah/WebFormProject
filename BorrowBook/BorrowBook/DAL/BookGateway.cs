using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BorrowBook.Model;

namespace BorrowBook.DAL
{
    public class BookGateway : Gateway
    {
        private Book aBook;

        public BookGateway() : base("sqlcon")
        {
        }

        public Book GetBookByTitle(string title)
        {

            try
            {
                Connection.Open();
                string query = string.Format("SELECT * FROM Book WHERE Title='{0}'", title);
                Command.CommandText = query;
                SqlDataReader aReader = Command.ExecuteReader();

                bool hasRow = aReader.HasRows;

                if (hasRow)
                {
                    while (aReader.Read())
                    {
                        aBook=new Book();
                        aBook.Id = (int)aReader[0];
                        aBook.Title = aReader[1].ToString();
                        aBook.Author = aReader[2].ToString();
                        aBook.Publisher = aReader[3].ToString();
                    }
                }
                Connection.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("Connection failed", ex);
            }
            return aBook;

        }

        public List<Book> GetAllBooks()
        {
            List<Book> aBooks = new List<Book>();

            try
            {
                Connection.Open();
                string query = string.Format("SELECT * FROM Book");
                Command.CommandText = query;
                SqlDataReader aReader = Command.ExecuteReader();
                bool hasRow = aReader.HasRows;

                if (hasRow)
                {
                    while (aReader.Read())
                    {
                        aBook = new Book();
                        aBook.Id = (int) aReader[0];
                        aBook.Title = aReader[1].ToString();
                        aBook.Author = aReader[2].ToString();
                        aBook.Publisher = aReader[3].ToString();
                        aBooks.Add(aBook);
                    }
                }
                Connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Connection failed", ex);
            }
            return aBooks;
        }
    }
}
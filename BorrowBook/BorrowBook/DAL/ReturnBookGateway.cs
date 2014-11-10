using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BorrowBook.Model;

namespace BorrowBook.DAL
{
    public class ReturnBookGateway:Gateway
    {
        public ReturnBookGateway() : base("sqlcon"){}

        public string ReturnBook(int bookId, int memberId)
        {
            string msg="Return failed";
            try
            {
                Connection.Open();
                string query = string.Format("DELETE FROM Borrow WHERE BookId={0} AND MemberId={1}", bookId, memberId);
                Command.CommandText = query;
                int rowAffected = Command.ExecuteNonQuery();
                Connection.Close();
                if (rowAffected>=1)
                {
                    msg = "Return Successfull";
                    return msg;
                }
                return msg;
            }
            catch (Exception exception)
            {
                throw new Exception("Something went wrong",exception);
            }
        }

        public List<string> GetAllBorrowedBooks(string number)
        {
            List<string> aBooks = new List<string>();

            try
            {
                Connection.Open();
                string query = string.Format("SELECT * FROM View_1 WHERE Number='{0}'", number);
                Command.CommandText = query;
                SqlDataReader aReader = Command.ExecuteReader();
                bool hasRow = aReader.HasRows;

                if (hasRow)
                {
                    while (aReader.Read())
                    {
                        string bookName;
                        bookName = aReader[1].ToString();
                        aBooks.Add(bookName);
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
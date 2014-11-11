using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BorrowBook.DAL
{
    public class BorrowBookGateway:Gateway
    {
        public BorrowBookGateway(): base("sqlcon")
        {
        }

        public string BorrowBook(int memberId, int bookId)
        {
            string msg = "Borrow failed";
            try
            {
                Connection.Open();
                string queryy = string.Format("SELECT * FROM Borrow WHERE MemberId={0} AND BookId={1}",memberId,bookId);
                Command.CommandText = queryy;
                SqlDataReader aReader = Command.ExecuteReader();
                bool hasRow = aReader.HasRows;
                if (hasRow)
                {
                    while (aReader.Read())
                    {
                        string borrow = aReader[3].ToString();
                        if (borrow=="Borrowed")
                        {
                            return "you already borrowed this book";
                        }
                    }
                    
                }
                Connection.Close();
            }
            catch (Exception exception)
            {
                throw new Exception(msg,exception);
            }
            try
            {
                Connection.Open();
                string query = string.Format("INSERT INTO Borrow VALUES({0},{1},'{2}')", memberId,bookId,"Borrowed");
                Command.CommandText = query;
                int rowAffected = Command.ExecuteNonQuery();
                Connection.Close();

                if (rowAffected > 0)
                {
                    return "Borrow Successfull";
                }
            }
            catch (Exception exception)
            {
                throw new Exception(msg, exception);
            }
            return msg;
        }
    }
}
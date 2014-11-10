using System;
using System.Collections.Generic;
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
                string query = string.Format("INSERT INTO Borrow VALUES({0},{1})", memberId,bookId);
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
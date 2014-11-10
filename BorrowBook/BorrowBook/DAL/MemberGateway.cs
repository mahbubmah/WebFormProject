using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BorrowBook.Model;

namespace BorrowBook.DAL
{
    public class MemberGateway:Gateway
    {
        private Member aMember;
        public MemberGateway() : base("sqlcon"){}

        public bool IsThisMemberExist(string number)
        {

            try
            {
                Connection.Open();
                string query = string.Format("SELECT * FROM Member WHERE Number='{0}'", number);
                Command.CommandText = query;
                SqlDataReader aReader = Command.ExecuteReader();

                bool hasRow = aReader.HasRows;

                if (hasRow)
                {
                    return true;
                }
                Connection.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("Connection failed", ex);
            }
            return false;

        }

        public Member GetMemberByNo(string number)
        {
            try
            {
                Connection.Open();
                string query = string.Format("SELECT * FROM Member WHERE Number='{0}'", number);
                Command.CommandText = query;
                SqlDataReader aReader = Command.ExecuteReader();

                bool hasRow = aReader.HasRows;

                if (hasRow)
                {
                    while (aReader.Read())
                    {
                        aMember = new Member();
                        aMember.Id = (int)aReader[0];
                        aMember.Number = aReader[1].ToString();
                    }
                }
                Connection.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("Connection failed", ex);
            }
            return aMember;
        }
    }
}
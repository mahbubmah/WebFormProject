using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace BorrowBook.DAL
{
    public class Gateway
    {
        public SqlCommand Command { get; set; }
        public SqlConnection Connection { get; set; }


        public Gateway(string connectionName)
        {
            Connection = new SqlConnection(WebConfigurationManager.ConnectionStrings[connectionName].ConnectionString);
            Command = new SqlCommand();
            Command.Connection = Connection;
        }
    }
}
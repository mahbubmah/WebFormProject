using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BorrowBook.DAL;

namespace BorrowBook.BLL
{
    public class BorrowBookBLL
    {
        private BorrowBookGateway aBorrowBookGateway;
        public string BorrowBook(int memberId, int bookId)
        {
            aBorrowBookGateway=new BorrowBookGateway();
            string msg=aBorrowBookGateway.BorrowBook(memberId, bookId);
            return msg;
        }
    }
}
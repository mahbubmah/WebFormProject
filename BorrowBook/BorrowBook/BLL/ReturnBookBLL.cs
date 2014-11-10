using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BorrowBook.DAL;

namespace BorrowBook.BLL
{
    
    public class ReturnBookBLL
    {
        private ReturnBookGateway aReturnBookGateway;

        public List<string> GetBorrowedBook(string number)
        {
            aReturnBookGateway=new ReturnBookGateway();
            return aReturnBookGateway.GetAllBorrowedBooks(number);
        }

        public string ReturnBook(int bookId,int memberId)
        {
            aReturnBookGateway=new ReturnBookGateway();
            return aReturnBookGateway.ReturnBook(bookId, memberId);

        }
    }
}
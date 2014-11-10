using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BorrowBook.DAL;
using BorrowBook.Model;

namespace BorrowBook.BLL
{
    
    public class BookBLL
    {
        private BookGateway aBookGateway;
        private Book aBook;
        private Member aMember;

        public Book ABook { get; set; }

        public Book GetBookByTitle(string title)
        {
            aBookGateway=new BookGateway();
            aBook = aBookGateway.GetBookByTitle(title);
            
            return aBook;
        }

        public List<Book> GetAllBook()
        {
            aBookGateway=new BookGateway();
            List<Book> aBooks=new List<Book>();
            aBooks=aBookGateway.GetAllBooks();
            return aBooks;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BorrowBook.Model
{
    public class BorrowBook
    {
        public Book ABook { get; set; }
        public Member AMember { get; set; }

    }
}
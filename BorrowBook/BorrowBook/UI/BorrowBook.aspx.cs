using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Sql;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BorrowBook.BLL;
using BorrowBook.Model;

namespace BorrowBook.UI
{
    public partial class BorrowBook : System.Web.UI.Page
    {
        private BookBLL aBookBll;
        private Book aBook;
        private Member aMember;
        private MemberBLL aMemberBll;
        private BorrowBookBLL aBorrowBookBll;
        private BorrowBook aBorrowBook;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMsg.Text = string.Empty;
                GetAllBookToDorpDown();
            }
        }

        private void GetAllBookToDorpDown()
        {
            aBookBll=new BookBLL();
            List<Book> aBooks= aBookBll.GetAllBook();

            dropDownBooks.DataSource = aBooks;
            dropDownBooks.DataTextField = "Title";
            dropDownBooks.DataValueField = "Id";
            dropDownBooks.DataBind();
        }

        protected void btnBorrow_Click(object sender, EventArgs e)
        {
            string msg;
            try
            {
                aMemberBll=new MemberBLL();
                if (aMemberBll.IsThisMemberExist(txtMemberNo.Text))
                {
                    BorrowBookBLL bBorrowBookBll=new BorrowBookBLL();
                    aMemberBll=new MemberBLL();
                    aBookBll=new BookBLL();
                    
                    aMember=aMemberBll.GetMemberByNo(txtMemberNo.Text);
                    string txt = dropDownBooks.SelectedItem.Text;
                    Book bBook = aBookBll.GetBookByTitle(txt);
                    string msg1 = bBorrowBookBll.BorrowBook(aMember.Id,bBook.Id);
                    lblMsg.Text = msg1;
                }
                else
                {
                    msg = "Sorry, member doesn't exist";
                    lblMsg.Text = msg;
                }
                
            }
            catch (Exception exception)
            {
                msg = exception.Message;
                lblMsg.Text = msg;
            }
        }

        protected void dropDownBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            BorrowBookBLL bBorrowBookBll = new BorrowBookBLL();
            aMemberBll = new MemberBLL();
            aBookBll = new BookBLL();

            aMember = aMemberBll.GetMemberByNo(txtMemberNo.Text);
            string txt = dropDownBooks.SelectedItem.Text;
            Book bBook = aBookBll.GetBookByTitle(txt);

            txtAuthor.Text = bBook.Author;
            txtPublisher.Text = bBook.Publisher;

        }

        protected void btnReturnBook_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReturnBook.aspx");
        }


    }
}
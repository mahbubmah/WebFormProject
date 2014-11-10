using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BorrowBook.BLL;
using BorrowBook.Model;

namespace BorrowBook.UI
{
    public partial class ReturnBook : System.Web.UI.Page
    {
        private ReturnBookBLL aReturnBookBll;
        private Book aBook;
        private Member aMember;
        private BookBLL aBookBll;
        private MemberBLL aMemberBll;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnShowBorrowedBook_Click(object sender, EventArgs e)
        {
            aReturnBookBll=new ReturnBookBLL();
            dropDownListBorrowedBook.DataSource = aReturnBookBll.GetBorrowedBook(txtMemberNo.Text);
            dropDownListBorrowedBook.DataBind();
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                aReturnBookBll = new ReturnBookBLL();
                aMemberBll = new MemberBLL();
                aBookBll = new BookBLL();
                aBook = aBookBll.GetBookByTitle(dropDownListBorrowedBook.SelectedItem.Text);
                aMember = aMemberBll.GetMemberByNo(txtMemberNo.Text);
                string msg = aReturnBookBll.ReturnBook(aBook.Id, aMember.Id);
                dropDownListBorrowedBook.DataSource = aReturnBookBll.GetBorrowedBook(txtMemberNo.Text);
                dropDownListBorrowedBook.DataBind();
                lblMsg.Text = msg;
            }
            catch (Exception exception)
            {
                
                throw new Exception(exception.Message);
            }
            
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BorrowBook.DAL;
using BorrowBook.Model;

namespace BorrowBook.BLL
{
    public class MemberBLL
    {
        private MemberGateway aMemberGateway;
        private Member aMember;


        public bool IsThisMemberExist(string number)
        {
            aMemberGateway=new MemberGateway();
            
            if (aMemberGateway.IsThisMemberExist(number))
            {
                return true;
            }
            return false;

        }

        public Member GetMemberByNo(string number)
        {
            aMemberGateway=new MemberGateway();
            return aMemberGateway.GetMemberByNo(number);
        }
    }
}
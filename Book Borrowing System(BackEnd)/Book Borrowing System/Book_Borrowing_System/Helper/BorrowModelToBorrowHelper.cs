using Book_Borrowing_System.Models;
using Business_Object_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Borrowing_System.Helper
{
    public class BorrowModelToBorrowHelper
    {
        public Borrow BorrowModelToBorrowMapping(BorrowModel e)
        {
            Borrow b = new Borrow();
            b.BorrowId = e.BorrowId;
            b.BookId = e.BookId;
            b.UserId = e.UserId;
            return b;
        }
    }
}

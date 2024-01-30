using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Business_Object_Layer
{
    public class Borrow
    {
        public int BorrowId { get; set; }
        [ForeignKey("Book")]
        public int UserId { get; set; }
        public int BookId { get; set; }
    }
}

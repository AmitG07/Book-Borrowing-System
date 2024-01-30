using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Borrowing_System.Models
{
    public class BookModel
    {
        public int BookId { get; set; }
        public int LentByUserId { get; set; }
        public string BookName { get; set; }
        public float Rating { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public bool IsAvailable { get; set; }
    }
}

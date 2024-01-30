using Book_Borrowing_System.Models;
using Business_Object_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Borrowing_System.Helper
{
    public class BookToBookHelper
    {
        public BookModel BookToBookMapping(Book bm)
        {
            BookModel b = new BookModel();
            b.BookId = bm.BookId;
            b.LentByUserId = bm.LentByUserId;
            b.BookName = bm.BookName;
            b.Rating = bm.Rating;
            b.Author = bm.Author;
            b.Genre = bm.Genre;
            b.Description = bm.Description;
            b.IsAvailable = bm.IsAvailable;
            return b;
        }
    }
}

using Business_Object_Layer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Interface
{
    public interface IBookBL
    {
        public int AddBook(Book book);
        public bool EditBookById(Book value);
        public Book GetBookById(int id);
        public IEnumerable<Book> GetBooks();
        public IEnumerable<Book> GetAllBooks(int id);
        public IEnumerable<Book> GetAllBooksByUser(int id);
        Task<List<Borrow>> BorrowBook(Borrow data);
        public IEnumerable<Borrow> GetAllBorrows();
        public IEnumerable<Borrow> GetMyBorrows(int id);
    }
}

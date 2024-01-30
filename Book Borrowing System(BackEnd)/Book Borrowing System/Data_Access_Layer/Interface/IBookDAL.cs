using Business_Object_Layer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Interface
{
    public interface IBookDAL
    {
        public int AddBook(Book book);
        public bool EditBookById(Book value);
        public Book GetBookById(int id);
        public IEnumerable<Book> GetBooks();
        public IEnumerable<Book> GetAllBooks(int id);
        public IEnumerable<Book> GetAllBooksByUser(int id);
        Task BorrowBook(Borrow data);
        Task<List<Borrow>> GetAllBorrowedBooks();
        public IEnumerable<Borrow> GetAllBorrows();
        public IEnumerable<Borrow> GetMyBorrows(int id);
    }
}

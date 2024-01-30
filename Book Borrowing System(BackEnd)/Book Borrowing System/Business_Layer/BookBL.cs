using Business_Layer.Interface;
using Business_Object_Layer;
using Data_Access_Layer.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer
{
    public class BookBL : IBookBL
    {
        private readonly IBookDAL _bookDAL;

        public BookBL(IBookDAL bookDAL)
        {
            _bookDAL = bookDAL;
        }
        public int AddBook(Book book)
        {
            return _bookDAL.AddBook(book);
        }

        public bool EditBookById(Book value)
        {
            var book = _bookDAL.EditBookById(value);
            return book;
        }

        public IEnumerable<Book> GetBooks()
        {
            var book = _bookDAL.GetBooks();
            if (book != null)
                return book;
            else
                return null;
        }

        public IEnumerable<Book> GetAllBooks(int id)
        {
            var book = _bookDAL.GetAllBooks(id);
            if (book != null)
                return book;
            else
                return null;
        }

        public IEnumerable<Book> GetAllBooksByUser(int id)
        {
            var book = _bookDAL.GetAllBooksByUser(id);
            if (book != null)
                return book;
            else
                return null;
        }

        public Book GetBookById(int id)
        {
            var product = _bookDAL.GetBookById(id);
            return product;
        }


        public async Task<List<Borrow>> BorrowBook(Borrow data)
        {
            await _bookDAL.BorrowBook(data);

            return await _bookDAL.GetAllBorrowedBooks();
        }

        public IEnumerable<Borrow> GetAllBorrows()
        {
            var book = _bookDAL.GetAllBorrows();
            if (book != null)
                return book;
            else
                return null;
        }

        public IEnumerable<Borrow> GetMyBorrows(int id)
        {
            var book = _bookDAL.GetMyBorrows(id);
            if (book != null)
                return book;
            else
                return null;
        }
    }
}

using Business_Object_Layer;
using Data_Access_Layer.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public class BookDAL : IBookDAL
    {
        private readonly ApplicationDbContext _context;

        public BookDAL(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public int AddBook(Book book)
        {
            if (book != null)
            {
                _context.Books.Add(book);
                _context.SaveChanges();
                int id = book.BookId;
                return id;
            }
            else
            {
                return 0;
            }
        }

        public bool EditBookById(Book value)
        {
            value.BookId = value.BookId;
            _context.Books.Update(value);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<Book> GetBooks()
        {
            IEnumerable<Book> books = _context.Books.ToList();
            return books;
        }

        public IEnumerable<Book> GetAllBooks(int id)
        {
            IEnumerable<Book> books = _context.Books.ToList();
            var allBooksforPartiularUser = books.Where(i => i.LentByUserId != id).ToList();
            return allBooksforPartiularUser;
        }

        public IEnumerable<Book> GetAllBooksByUser(int id)
        {
            IEnumerable<Book> books = _context.Books.ToList();
            var allBooksofPartiularUser = books.Where(i => i.LentByUserId == id).ToList();
            return allBooksofPartiularUser;
        }

        public Book GetBookById(int id)
        {
            var book = _context.Books.ToList().FirstOrDefault(c => c.BookId == id);
            return book;
        }

        public async Task BorrowBook(Borrow data)
        {
            // Check if the user has available tokens
            var currUser = await _context.Users.FindAsync(data.UserId);
            if (currUser == null || currUser.Tokens_Available <= 0)
            {
                // User doesn't have available tokens, handle accordingly (throw exception, return error response, etc.)
                // For example, you might want to throw an exception like this:
                throw new InvalidOperationException("User doesn't have available tokens to borrow the book.");
            }

            // updating book not available
            var currBook = await _context.Books.FindAsync(data.BookId);
            if (currBook != null)
            {
                currBook.IsAvailable = true;

                // updating current user token by -1
                currUser.Tokens_Available = currUser.Tokens_Available - 1;

                // updating book user token by +1
                var bookUser = await _context.Users.FindAsync(currBook.LentByUserId);
                if (bookUser != null)
                    bookUser.Tokens_Available = bookUser.Tokens_Available + 1;

                // Save changes to the database
                _context.Borrows.Add(data);
                await _context.SaveChangesAsync();
            }
        }


        public async Task<List<Borrow>> GetAllBorrowedBooks()
        {
            return await _context.Borrows.ToListAsync();
        }

        public IEnumerable<Borrow> GetAllBorrows()
        {
            IEnumerable<Borrow> borrows = _context.Borrows.ToList();
            var allBooksforPartiularUser = borrows.ToList();
            return allBooksforPartiularUser;
        }

        public IEnumerable<Borrow> GetMyBorrows(int id)
        {
            IEnumerable<Borrow> borrows = _context.Borrows.ToList();
            var allBooksforPartiularUser = borrows.Where(i => i.UserId == id).ToList();
            return allBooksforPartiularUser;
        }
    }
}

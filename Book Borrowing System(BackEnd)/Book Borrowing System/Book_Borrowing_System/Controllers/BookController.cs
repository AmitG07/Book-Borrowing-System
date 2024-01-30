using Book_Borrowing_System.Helper;
using Book_Borrowing_System.Models;
using Business_Layer.Interface;
using Business_Object_Layer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Borrowing_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookBL _bookBL;

        public BookController(IBookBL carBL)
        {
            _bookBL = carBL;
        }

        [HttpPost]
        [Route("post")]
        public int Post([FromBody] BookModel value)
        {
            if (value != null)
            {
                Book book = new BookModelToBookHelper().BookModelToBookMapping(value);
                if (ModelState.IsValid)
                {
                    return _bookBL.AddBook(book);
                }
            }
            return 0;
        }

        [HttpGet("{id}")]
        [Route("EditBookById/{id}")]
        public bool EditBookById(int id, [FromBody] BookModel value)
        {
            if (value != null)
            {
                Book book = new BookModelToBookHelper().BookModelToBookMapping(value);
                book.BookId = id;
                if (_bookBL.EditBookById(book))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        [HttpGet()]
        [Route("GetBooks")]
        public IEnumerable<Book> GetBooks()
        {
            return _bookBL.GetBooks();
        }

        [HttpGet("{id}")]
        [Route("GetAllBooks/{id}")]
        public IEnumerable<Book> GetAllBooks(int id)
        {
            return _bookBL.GetAllBooks(id);
        }

        [HttpGet("{id}")]
        [Route("GetAllBooksByUser/{id}")]
        public IEnumerable<Book> GetAllBooksByUser(int id)
        {
            return _bookBL.GetAllBooksByUser(id);
        }


        [HttpGet("{id}")]
        [Route("GetBookById/{id}")]
        public BookModel GetBookById(int id)
        {
            Book book = _bookBL.GetBookById(id);
            if (book != null)
            {
                var prod = new BookToBookHelper().BookToBookMapping(book);
                return prod;
            }
            return null;
        }

        [HttpPost]
        [Route("BorrowBook")]
        public async Task<ActionResult<List<Borrow>>> BorrowBook(BorrowModel data)
        {
            if (data != null)
            {
                var borrowData = MapViewModelToBusinessObject(data);
                return await _bookBL.BorrowBook(borrowData);
            }
            return null;
        }

        private Borrow MapViewModelToBusinessObject(BorrowModel viewModel)
        {
            var borrowedBook = new Borrow
            {
                // Map properties from viewModel to BorrowedBook
                BorrowId = viewModel.BorrowId,
                BookId = viewModel.BookId,
                UserId = viewModel.UserId,
                // Map other properties as needed
            };

            return borrowedBook;
        }

        [HttpGet()]
        [Route("GetAllBorrows")]
        public IEnumerable<Borrow> GetAllBorrows()
        {
            return _bookBL.GetAllBorrows();
        }

        [HttpGet("{id}")]
        [Route("GetMyBorrows/{id}")]
        public IEnumerable<Borrow> GetMyBorrows(int id)
        {
            return _bookBL.GetMyBorrows(id);
        }
    }
}

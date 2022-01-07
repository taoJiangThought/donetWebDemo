using BookManageSystem.Service;
using BookManageSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookManageSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : Controller
    {
        public BooksService _booksService;
        public BooksController(BooksService booksService)
        {
            _booksService = booksService;
        }
        
        
        [HttpGet("getAllBooks")]
        public IActionResult GetAllBooks()
        {
            var allBooks = _booksService.GetAllBooks();
            return Ok(allBooks);
        }
        
        [HttpPost("getBooksByCondition")]
        public IActionResult GetBooksByCondition([FromBody]SearchByConditionParameters searchByCondition)
        {
            var allBooks = _booksService.GetBooksByCondition(searchByCondition);
            return Ok(allBooks);
        }
        
        [HttpPost("addBook")]
        public IActionResult AddBook([FromBody]BookParams book)
        {
            _booksService.AddBook(book);
            return Ok();
        }
        
        [HttpPut("updateBookById/{id}")]
        public IActionResult UpdateBookById(int id, [FromBody]BookParams book)
        {
            var updatedBook = _booksService.UpdateBookById(id, book);
            return Ok(updatedBook);
        }

        [HttpDelete("deleteBookById/{id}")]
        public IActionResult DeleteBookById(int id)
        {
            _booksService.DeleteBookById(id);
            return Ok();
        }
    }
}
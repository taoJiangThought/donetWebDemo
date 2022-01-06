using System.Collections.Generic;
using System.Linq;
using BookManageSystem.Data;
using BookManageSystem.Models;
using BookManageSystem.ViewModels;

namespace BookManageSystem.Service
{
    public class BooksService 
    {

        private BookContext _context;
        public BooksService(BookContext context)
        {
            _context = context;
        }
        public List<Book> GetAllBooks()
        {
            var books = _context.Books.ToList();
            return books.FindAll(n => n.IsDeleted == 0);
        }

        public Book GetBookById(int id)
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == id && n.IsDeleted == 0);
            return _book;
        }

        public List<Book> GetBookByCondition(SearchByConditionParameters conditionParameters)
        {   
            //TODO
            var books = from s in _context.Books select s;
            
            
            return null;
        }

        public void AddBook(BookParams book)
        {
            var dbBook = BookViewToDbBook(book);
            _context.Books.Add(dbBook);
            _context.SaveChanges();
        }

        public Book UpdateBookById(int id, BookParams book)
        {
          var  dbBook = _context.Books.FirstOrDefault(n => n.Id == id);
          if (dbBook != null)
          {
              dbBook.Title = book.Title;
              dbBook.Price = book.Price;
              dbBook.PublishDate = book.PublishDate;
              dbBook.IdentificationCode = book.IdentificationCode;
              dbBook.Type = book.Type;        
              _context.SaveChanges();
          }
          return dbBook;
        }
        
        private static Book BookViewToDbBook(BookParams book)
        {
            var dbBook = new Book()
            {
                Title = book.Title,
                Price = book.Price,
                PublishDate = book.PublishDate,
                IdentificationCode = book.IdentificationCode,
                Type = book.Type
            };
            return dbBook;
        }

        // logic delete
        public void DeleteBookById(int id)
        {
            var  dbBook = _context.Books.FirstOrDefault(n => n.Id == id);
            if (dbBook != null)
            {
                dbBook.IsDeleted = 1;
                _context.SaveChanges();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using BookManageSystem.Models;
using BookManageSystem.Respository;
using BookManageSystem.Service;
using Moq;
using Xunit;

namespace UITestBookManageSystem
{
    public class BookServiceTest
    {
        [Fact]
        public void should_return_the_book_when_get_book_by_id()
        {
            //arrage
            var _booksResp = new Mock<IBooksRespository>();
            var book = new Book()
            {
                Id = 1,
                IdentificationCode = "1",
                IsDeleted = 0,
                Price = 100,
                PublishDate = new DateTime()
            };
            _booksResp.Setup(repo => repo.GetBookById(It.IsAny<int>())).Returns(book);
            var booksService = new BooksService(_booksResp.Object);
            
            //act
            var allBooks = booksService.GetBookById(1);
            
            //assert
            Assert.NotNull(allBooks);
            Assert.Equal(1,allBooks.Id);
        }

        [Fact]
        public void should_return_books_when_get_all_books()
        {
            //arrage
            var _booksResp = new Mock<IBooksRespository>();
            
            _booksResp.Setup(repo => repo.GetAllBooks()).Returns(getMockBooks());
            var booksService = new BooksService(_booksResp.Object);
            
            //act
            var allBooks = booksService.GetAllBooks();
            
            //assert
            Assert.NotNull(allBooks);
            Assert.Equal(1,allBooks.Count);
        }
        
        
        private List<Book> getMockBooks()
        {
            List<Book> books = new List<Book>();
            
            books.Add(new Book()
            {
                Id = 1,
                IdentificationCode = "1",
                IsDeleted = 0,
                Price = 100,
                PublishDate = new DateTime()
            });
            return books;
        }
        
    }
}
public interface IService
{
    bool Get(Func<bool, bool> func);
}
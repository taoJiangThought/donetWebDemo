using System;
using System.Collections.Generic;
using System.Linq;
using BookManageSystem.Models;
using BookManageSystem.Respository;
using BookManageSystem.Service;
using BookManageSystem.ViewModels;
using Moq;
using Xunit;

namespace BookManageSystemTest
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

        [Fact]
        public void should_successful_when_add_a_book()
        {
            //arrage
            var _booksResp = new Mock<IBooksRespository>();
            var bookParams = new BookParams()
            {
                IdentificationCode = "1",
                Price = 100,
                PublishDate = new DateTime()  
            };
            _booksResp.Setup(repo => repo.AddBook(bookParams));
            var booksService = new BooksService(_booksResp.Object); 
            
            //act
            booksService.AddBook(bookParams);
            
            //assert
            _booksResp.Verify(x=>x.AddBook(It.IsAny<BookParams>()),Times.Once);
        }

        [Fact]
        public void should_successful_when_update_book_by_id()
        {
            //arrage
            var _booksResp = new Mock<IBooksRespository>();
            var bookParams = new BookParams()
            {
                IdentificationCode = "1",
                Price = 100,
                PublishDate = new DateTime()  
            };
            _booksResp.Setup(repo => repo.UpdateBookById(1,bookParams)).Returns(getMockBooks()
                [0]);
            var booksService = new BooksService(_booksResp.Object); 
            
            //act
            Book updateBookBy = booksService.UpdateBookById(1,bookParams);

            //assert 
            Assert.Equal(bookParams.Price,updateBookBy.Price);
            Assert.Equal(bookParams.IdentificationCode,updateBookBy.IdentificationCode);
            Assert.Equal(bookParams.PublishDate,updateBookBy.PublishDate);
            
        }

        [Fact]
        public void should_successful_when_delete_book_by_id()
        {
            var _booksResp = new Mock<IBooksRespository>();
            _booksResp.Setup(repo => repo.DeleteBookById(1));
            
            var booksService = new BooksService(_booksResp.Object); 
            
            booksService.DeleteBookById(1);
            
            _booksResp.Verify(x => x.DeleteBookById(It.IsAny<int>()),Times.Once());   
        }

        [Fact]
        public void should_return_the_books_when_query_by_Title_condition()
        {
            var _booksResp = new Mock<IBooksRespository>();
            _booksResp.Setup(repo => repo.GetAllBooks()).Returns(MockAllBooks);
            var searchByConditionParameters = new SearchByConditionParameters()
            {
              
                    Title= "1",
                    OrderByTitle= 0,
                    Page= 1,
                    PageSize = 10

            };
            var booksService = new BooksService(_booksResp.Object);

            var booksByCondition = booksService.GetBooksByCondition(searchByConditionParameters);
            
            Assert.Equal(1,booksByCondition.Count);
            Assert.Collection(booksByCondition,b=>b.Title.Contains('1'));
        }

        [Fact]
        public void should_return_the_books_when_query_by_Title_asc_order()
        {
            var _booksResp = new Mock<IBooksRespository>();
            _booksResp.Setup(repo => repo.GetAllBooks()).Returns(MockAllBooks);
            var searchByConditionParameters = new SearchByConditionParameters()
            {
                OrderByTitle= 0,
                Page= 1,
                PageSize = 10
            };
            var booksService = new BooksService(_booksResp.Object);
            
            var booksByCondition = booksService.GetBooksByCondition(searchByConditionParameters);
            
            Assert.Equal(10,booksByCondition.Count);
            var previous = booksByCondition.First();
            foreach (Book item in booksByCondition)
            {
                if (item != previous)
                {
                    Assert.True(previous.Title.CompareTo(item.Title)<=0);
                }
                previous = item;
            }
            // Assert.OrderDesc(listShouldBeSorted, x => x.StartDate)
        }
        private List<Book> MockAllBooks()
        {
            List<Book> books = new List<Book>();
            for (int i = 0 ; i < 10; i++)
            {
                var book = new Book()
                {
                    Id = i,
                    IdentificationCode = "code"+i,
                    IsDeleted = 0,
                    Price = 100+i,
                    Title = "Title"+i,
                    PublishDate = new DateTime()  
                };
                books.Add(book);
            }
            return books;
        }
    }
}
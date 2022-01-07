using System;
using System.Collections.Generic;
using System.Linq;
using BookManageSystem.Data;
using BookManageSystem.Models;
using BookManageSystem.Respository;
using BookManageSystem.ViewModels;
using PagedList;

namespace BookManageSystem.Service
{
    public class BooksService 
    {

        private BooksRespository _booksRespository;
        public BooksService(BooksRespository booksRespository)
        {
            _booksRespository = booksRespository;
        }
        public List<Book> GetAllBooks()
        {
            return _booksRespository.GetAllBooks();
        }

        public Book GetBookById(int id)
        {
            return _booksRespository.GetBookById(id);
        }
        

        public void AddBook(BookParams book)
        {
            _booksRespository.AddBook(book);
        }

        public Book UpdateBookById(int id, BookParams book)
        {
            return _booksRespository.UpdateBookById(id,book);
        }
        
        // logic delete
        public void DeleteBookById(int id)
        {
          _booksRespository.DeleteBookById(id);
        }

        public IPagedList<Book> GetBooksByCondition(SearchByConditionParameters searchByCondition )
        {
            var allBooks = _booksRespository.GetAllBooks();
            var page = searchByCondition.Page;
            var pageSize = searchByCondition.PageSize;
            if (searchByCondition.GetType() != null)
            {
                allBooks = allBooks.FindAll(n => n.Title.Contains(searchByCondition.Title));
            }

            var orderByTitle = searchByCondition.OrderByTitle;
            if (  orderByTitle == 1)
            {
                 return allBooks.OrderByDescending(book => book.Title).ToPagedList(page,pageSize);
            }else if (orderByTitle == 0)
            {
              return  allBooks.OrderBy(book => book.Title).ToPagedList(page,pageSize);
            }
            else
            {
                throw new ArgumentException("orderByTitle is invalued");
            }
        }
    }
}
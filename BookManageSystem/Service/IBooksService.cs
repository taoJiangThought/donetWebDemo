using System.Collections.Generic;
using BookManageSystem.Models;
using BookManageSystem.ViewModels;
using PagedList;

namespace BookManageSystem.Service
{
    public interface IBooksService
    {
        public List<Book> GetAllBooks();

        public Book GetBookById(int id);


        public void AddBook(BookParams book);

        public Book UpdateBookById(int id, BookParams book);

        // logic delete
        public void DeleteBookById(int id);

        public IPagedList<Book> GetBooksByCondition(SearchByConditionParameters searchByCondition);
    }
}
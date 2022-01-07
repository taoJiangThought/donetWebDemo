using System.Collections.Generic;
using BookManageSystem.Models;
using BookManageSystem.ViewModels;

namespace BookManageSystem.Respository
{
    public interface IBooksRespository
    {
        public List<Book> GetAllBooks();
       

        public Book GetBookById(int id);


        public void AddBook(BookParams book);

        public Book UpdateBookById(int id, BookParams book);


        // logic delete
        public void DeleteBookById(int id);

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class BookServices : IBookServices
    {
        private readonly CRUDContext context;
        public BookServices(CRUDContext context)
        {
            this.context = context;
        }

        public void AddBook(Books book)
        {
            context.Books.Add(book);
            context.SaveChanges();
        }

        public void DeleteBook(int id)
        {
            var book = context.Books.Where(x => x.BookId == id).FirstOrDefault();
            context.Books.Remove(book);
            context.SaveChanges();
        }

        public void EditBook(Books book)
        {
            context.Books.Update(book);
            context.SaveChanges();
        }

        public Books GetBook(int id)
        {
            var book = context.Books.Where(x => x.BookId == id).FirstOrDefault();
            return book;
        }

        public List<Books> GetBooks()
        {
            var books = context.Books.ToList();
            return books;
        }
    }

    public interface IBookServices
    {
        public List<Books> GetBooks();
        public Books GetBook(int id);

        public void AddBook(Books book);
        public void EditBook(Books book);
        public void DeleteBook(int id);
    }
}

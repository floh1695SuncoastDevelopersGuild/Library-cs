using Library.Contexts;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Library.Controllers
{
    public class SearchController : ApiController
    {
        public IEnumerable<Book> Get(string title = null, string author = null, string genre = null, bool? checkedOut = null)
        {
            IEnumerable<Book> books;
            using (var db = new LibraryContext())
            {
                books = db.Books
                    .Include(b => b.BookData)
                    .Include(b => b.BookData.Author)
                    .Include(b => b.BookData.Genre);
                if (title != null)
                {
                    books = books
                        .Where(b => b.BookData.Title == title);
                }
                if (author != null)
                {
                    books = books
                        .Where(b => b.BookData.Author.Name == author);
                }
                if (genre != null)
                {
                    books = books
                        .Where(b => b.BookData.Genre.Name == genre);
                }
                if (checkedOut != null)
                {
                    books = books
                        .Where(b => b.IsCheckedOut == checkedOut);
                }
                books = books.ToList();
            }
            return books;
        }
    }
}

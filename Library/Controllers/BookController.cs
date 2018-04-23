using Library.Contexts;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Library.Controllers
{
    public class BookController : ApiController
    {
        public Book Get(int id)
        {
            Book book;
            using (var db = new LibraryContext())
            {
                book = db.Books.FirstOrDefault(b => b.ID == id);
            }
            return book;
        }

        public Book Post(Book book)
        {
            using (var db = new LibraryContext())
            {
                db.Books.Add(book);
            }
            return book;
        }
    }
}

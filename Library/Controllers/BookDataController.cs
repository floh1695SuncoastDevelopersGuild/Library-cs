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
    public class BookDataController : ApiController
    {
        public BookData Get(int id)
        {
            BookData bookData;
            using (var db = new LibraryContext())
            {
                bookData = db.BookData.FirstOrDefault(bd => bd.ID == id);
            }
            return bookData;
        }

        public BookData Post(BookData bookData)
        {
            using (var db = new LibraryContext())
            {
                db.BookData.Add(bookData);
            }
            return bookData;
        }
    }
}

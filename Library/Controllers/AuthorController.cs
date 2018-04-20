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
    public class AuthorController : ApiController
    {
        public Author Get(int id)
        {
            Author author;
            using (var db = new LibraryContext())
            {
                author = db.Authors.FirstOrDefault(a => a.ID == id);
            }
            return author;
        }

        // TODO: Cannot accept DataTime's that are null
        public Author Post(Author author)
        {
            using (var db = new LibraryContext())
            {
                db.Authors.Add(author);
                db.SaveChanges();
            }
            return author;
        }
    }
}

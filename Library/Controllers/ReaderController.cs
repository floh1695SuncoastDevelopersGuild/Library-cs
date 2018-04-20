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
    public class ReaderController : ApiController
    {
        public Reader Get(int id)
        {
            Reader reader;
            using (var db = new LibraryContext())
            {
                reader = db.Readers.FirstOrDefault(r => r.ID == id);
            }
            return reader;
        }

        public Reader Post(Reader reader)
        {
            using (var db = new LibraryContext())
            {
                db.Readers.Add(reader);
            }
            return reader;
        }
    }
}

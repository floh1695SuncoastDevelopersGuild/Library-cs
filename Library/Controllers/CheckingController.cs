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
    public class CheckingController : ApiController
    {
        [Route("api/checking/in")]
        public bool Get(int id)
        {
            bool rv;
            using (var db = new LibraryContext())
            {
                var book = db.Books
                    .Include(b => b.Ledger)
                    .FirstOrDefault(b => b.ID == id);
                if (book == null || book.IsCheckedOut == false)
                {
                    rv = false;
                }
                else
                {
                    book.IsCheckedOut = false;
                    book.Ledger.
                        Add(new CheckOutLedgerEntry
                        {
                            BookID = id,
                            Timestamp = DateTime.Now,
                            ReaderID = 1 // TODO: Any user for now
                        });
                    rv = true;
                }
                db.SaveChanges();
            }
            return rv;
        }
    }
}

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
    public class CheckingOutController : ApiController
    {
        // NOTE: Note complete
        [Route("api/checking/out")]
        public bool Post(int id)
        {
            bool rv;
            using (var db = new LibraryContext())
            {
                var book = db.Books
                    .Include(b => b.Ledger)
                    .FirstOrDefault(b => b.ID == id);
                if (book == null 
                    || book.IsCheckedOut == true)
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

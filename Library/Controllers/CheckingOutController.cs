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
        [Route("api/checking/out")]
        public bool Post(int id, string email)
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
                    book.IsCheckedOut = true;
                    book.Ledger.
                        Add(new CheckOutLedgerEntry
                        {
                            BookID = id,
                            Timestamp = DateTime.Now,
                            Reader = new Reader { Email = email }
                        });
                    rv = true;
                }
                db.SaveChanges();
            }
            return rv;
        }
    }
}

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
    public class LedgerController : ApiController
    {
        public IEnumerable<CheckOutLedgerEntry> Get()
        {
            IEnumerable<CheckOutLedgerEntry> ledger;
            using (var db = new LibraryContext())
            {
                ledger = db.CheckOutLedger.ToList();
            }
            return ledger;
        }
    }
}

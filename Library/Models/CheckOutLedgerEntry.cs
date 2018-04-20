using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class CheckOutLedgerEntry
    {
        public int ID { get; set; }

        public int BookID { get; set; }
        public Book Book { get; set; }

        public int ReaderID { get; set; }
        public Reader Reader { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
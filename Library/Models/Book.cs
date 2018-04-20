using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class Book
    {
        public int ID { get; set; }

        //public int BookDataID { get; set; }
        //public BookData BookData { get; set; }

        public bool IsCheckedOut { get; set; }
        public DateTime DueBackDate { get; set; }
    }
}
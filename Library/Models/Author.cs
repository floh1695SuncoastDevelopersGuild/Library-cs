using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class Author
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Nullable<DateTime> Born { get; set; }
        public Nullable<DateTime> Died { get; set; }
    }
}
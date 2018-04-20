using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Library.Contexts
{
    public class LibraryContext : DbContext
    {
        public LibraryContext()
            : base("name=Library")
        { }
    }
}
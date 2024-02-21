using System;
using System.Collections.Generic;

namespace INTEXAPP2.Models
{
    public partial class Book
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Link { get; set; }
    }
}

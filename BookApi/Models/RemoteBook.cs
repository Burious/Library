using System;
using System.Collections.Generic;

#nullable disable

namespace Library.Models
{
    public partial class RemoteBook
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Publishment { get; set; }
        public DateTime YearOfPublish { get; set; }
    }
}

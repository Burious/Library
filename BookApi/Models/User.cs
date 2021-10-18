using System;
using System.Collections.Generic;

#nullable disable

namespace Library.Models
{
    public partial class User
    {
        public User()
        {
            RemoteBooks = new HashSet<RemoteBook>();
        }

        public Guid Id { get; set; }
        public string UserName { get; set; }

        public virtual ICollection<RemoteBook> RemoteBooks { get; set; }
    }
}

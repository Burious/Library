using System;
using System.Collections.Generic;

#nullable disable

namespace Library.Models
{
    public partial class User
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
    }
}

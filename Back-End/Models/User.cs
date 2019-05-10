using System;
using System.Collections.Generic;

namespace backEnd.Models
{
    public partial class User
    {
        public long id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
    }
}

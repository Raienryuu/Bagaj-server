using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bAPI.Models
{
    public class UserDataModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
    }
}

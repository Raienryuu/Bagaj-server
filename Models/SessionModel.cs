using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bAPI.Models
{
    [Index(nameof(Token), IsUnique = true)]
    public class SessionModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public UserDataModel User { get; set;}
        public string Token { get; set; }
    }
}

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
        public int FK_UserId { get; set; }
        [ForeignKey("FK_UserId")]
        public virtual UserDataModel UserDataModel { get; set;}
        public string Token { get; set; }
    }
}

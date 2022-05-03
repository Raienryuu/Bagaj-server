using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;


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

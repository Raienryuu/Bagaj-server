using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;


namespace bAPI.Models
{
    [Index(nameof(Name), nameof(Lastname))]
    [Index(nameof(Login), IsUnique = true)]
    public class UserDataModel
    {
        public int Id { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string ContactInfo { get; set; }
        public float Rating { get; set; }
    }
}

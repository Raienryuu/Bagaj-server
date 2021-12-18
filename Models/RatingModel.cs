using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bAPI.Models
{
    public class RatingModel
    {
        public int Id { get; set; }
        [Required]
        [ForeignKey("FK_SenderId")]
        public UserDataModel SenderId { get; set; }
        [Required]
        [ForeignKey("FK_PackageId")]
        public PackageModel PackageId { get; set; }
        [Required]
        [ForeignKey("FK_TransporterId")]
        public UserDataModel TransporterId { get; set; }
        public float Rating { get; set; }
    }
}

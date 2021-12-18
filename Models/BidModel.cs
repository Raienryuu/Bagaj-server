using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bAPI.Models
{
    public class BidModel
    {
        public int Id { get; set; }
        [Required]
        [ForeignKey("FK_PackageId")]
        public PackageModel PackageId { get; set; }
        [Required]
        [ForeignKey("FK_UserId")]
        public UserDataModel BidderId { get; set; }
        public float BidValue { get; set; }
    }
}

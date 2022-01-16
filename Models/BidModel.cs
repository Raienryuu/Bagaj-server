using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bAPI.Models
{
    public class BidModel
    {
        public int Id { get; set; }
        public int PackageId { get; set; }
        [Required]
        [ForeignKey("PackageId")]
        public PackageModel Package { get; set; }
        public int BidderId { get; set; }
        [Required]
        [ForeignKey("BidderId")]
        public UserDataModel Bidder { get; set; }
        public float BidValue { get; set; }
    }
}

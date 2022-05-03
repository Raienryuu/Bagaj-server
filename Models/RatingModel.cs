using System.ComponentModel.DataAnnotations.Schema;

namespace bAPI.Models
{
    public class RatingModel
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        [ForeignKey("SenderId")]
        public UserDataModel Sender { get; set; }
        public int PackageId { get; set; }
        [ForeignKey("PackageId")]
        public PackageModel Package { get; set; }
        public int TransporterId { get; set; }
        [ForeignKey("TransporterId")]
        public UserDataModel Transporter { get; set; }
        public float RatedBySender { get; set; }
        public float RatedByTransporter { get; set; }
    }
}

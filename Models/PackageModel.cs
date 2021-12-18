using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bAPI.Models
{
    public class PackageModel
    {
        public int Id { get; set; }
        [Required]
        [ForeignKey("FK_UserId1")]
        public UserDataModel SenderId { get; set; }
        [ForeignKey("FK_UserId2")]
        public UserDataModel TransporterId { get; set; }
        public string StartVoivodeship { get; set; }
        public string StartPostCode { get; set; }
        public string StartCity { get; set; }
        public string StartStreetAddress { get; set; }
        public string EndVoivodeship { get; set; }
        public string EndPostCode { get; set; }
        public string EndCity { get; set; }
        public string EndStreetAddress { get; set; }
        public float Weight { get; set; }
        [ForeignKey("FK_Lowest_BidId")]
        public BidModel LowestBid { get; set; }
        public int OfferState { get; set; }
        public DateTimeOffset CreationDate { get; set; }
    }
}

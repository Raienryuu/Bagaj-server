using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bAPI.Models
{
    public class BidModel
    {
        public int Id { get; set; }
        public int PackageId { get; set; }
        public int BidderId { get; set; }
        public float BidValue { get; set; }
    }
}

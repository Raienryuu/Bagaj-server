﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bAPI.Models
{
    public class PackageModel
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int TransporterId { get; set; }
        public string StartVoivodeship { get; set; }
        public string StartPostCode { get; set; }
        public string StartCity { get; set; }
        public string StartStreetAddress { get; set; }
        public string EndVoivodeship { get; set; }
        public string EndPostCode { get; set; }
        public string EndCity { get; set; }
        public string EndStreetAddress { get; set; }
        public float Weight { get; set; }
        public BidModel LowestBid { get; set; }
        public int OfferState { get; set; }
    }
}

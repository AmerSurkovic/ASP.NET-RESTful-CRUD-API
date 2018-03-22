using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BannerFlow.Models
{
    public class Banner
    {
        [BsonElement("_id")]
        public int Id { get; set; }
        public string Html { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
    }
}
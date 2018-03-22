﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BannerFlow.Models
{
    public class BannerDetailDTO
    {
        public int Id { get; set; }
        public string Html { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }

        public BannerDetailDTO(Banner banner)
        {
            this.Id = banner.Id;
            this.Html = banner.Html;
            this.Created = banner.Created;
            this.Modified = banner.Modified;
        }
    }
}
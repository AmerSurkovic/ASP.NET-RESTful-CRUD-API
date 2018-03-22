using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BannerFlow.Models
{
    public class BannerDTO
    {
        // We want just HTML sent in a POST method
        // ID, Created, Modified are set by the server side
        public string Html { get; set; }
    }
}
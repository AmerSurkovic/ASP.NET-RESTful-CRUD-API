using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BannerFlow.Validators
{
    public static class HtmlValidator
    {
        public static bool Validate(string html)
        {
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(html);
            if(document.ParseErrors.Count() > 0)
            {
                return false;
            }
            return true;
        }
    }
}
using BannerFlow.Models;
using BannerFlow.Repositories;
using BannerFlow.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BannerFlow.Controllers
{
    public class BannerController : ApiController
    {
        private static BannerService bannerService;

        public BannerController()
        {
            bannerService = new BannerService();
        }

        // GET api/Banner
        public IEnumerable<Banner> Get()
        {
            return bannerService.GetAll();
        }

        // GET api/Banners/int
        public Banner Get(int id)
        {
            var banner = bannerService.Get(id);
            if (banner == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return banner;
        }


        // POST api/Banner
        public HttpResponseMessage Post(BannerDTO value)
        {
            HttpResponseMessage result = null;

            if (ModelState.IsValid)
            {
                try
                {
                    var banner = bannerService.Add(value);
                    result = Request.CreateResponse<Banner>(HttpStatusCode.OK, banner);
                    string newItemURL = Url.Link("DefaultApi", new { id = banner.Id });
                    result.Headers.Location = new Uri(newItemURL);
                }
                catch(Exception ex)
                {
                    Trace.TraceError(ex.Message, ex);
                    result = Request.CreateResponse<string>(HttpStatusCode.InternalServerError, ex.Message);
                }
            }
            else
            {
                result = Request.CreateResponse<string>(HttpStatusCode.BadRequest, "State not valid!");
            }
            return result;
        }

        // PUT api/banner/int
        public HttpResponseMessage Put(int id, BannerDTO value)
        {
            HttpResponseMessage result = null;

            if (ModelState.IsValid)
            {
                try
                {
                    Banner update = bannerService.Put(id, value);
                    result = Request.CreateResponse(HttpStatusCode.Accepted, update);
                }
                catch(Exception ex)
                {
                    Trace.TraceError(ex.Message, ex);
                    result = Request.CreateResponse<string>(HttpStatusCode.InternalServerError, ex.Message);
                }
            }
            else
            {
                result = Request.CreateResponse<string>(HttpStatusCode.BadRequest, "State not valid!");
            }
            return result;

        }

        public HttpResponseMessage Delete(int id)
        {
            HttpResponseMessage result = null;

            try
            {
                bannerService.Delete(id);
                result = Request.CreateResponse(HttpStatusCode.Accepted, "Entry was deleted.");
            }
            catch(Exception ex)
            {
                Trace.TraceError(ex.Message, ex);
                result = Request.CreateResponse<string>(HttpStatusCode.InternalServerError, ex.Message);
            }

            return result;
        }
    }
}

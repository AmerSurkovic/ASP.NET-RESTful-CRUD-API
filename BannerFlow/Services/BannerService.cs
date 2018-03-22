﻿using BannerFlow.Models;
using BannerFlow.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BannerFlow.Services
{
    public class BannerService
    {
        private static IBannerRepository repository;

        private static int key;

        // CTOR
        public BannerService()
        {
            repository = new BannerRepository();
            key = repository.GetLastKey();
            key++;
        }

        // Add an entry logic
        public Banner Add(BannerDTO data)
        {
            Banner input = new Banner();
            input.Created = DateTime.Now;
            input.Modified = DateTime.Now;
            input.Id = key++;
            input.Html = data.Html;

            repository.Add(input);

            return input;
        }

        // Return all entries logic
        public IEnumerable<BannerDetailDTO> GetAll()
        {
            List<BannerDetailDTO> value = new List<BannerDetailDTO>();
            IEnumerable<Banner> banners = repository.GetAll();

            foreach(Banner x in banners)
            {
                value.Add(new BannerDetailDTO(x));
            }
            return value;
        }

        // Return requested entry logic
        public BannerDetailDTO Get(int id)
        {
            BannerDetailDTO value = new BannerDetailDTO(repository.Get(id));

            return value;
        }


        // Edit an entry logic
        public Banner Put(int id, BannerDTO value)
        {
            Banner update = repository.Get(id);
            update.Html = value.Html;
            update.Modified = DateTime.Now;

            repository.Update(id, update);
            return update;
        }

        // Delete an entry logic
        public void Delete(int id)
        {
            repository.Delete(id);
        }

        // Returns an HTML of a specified banner
        public BannerDTO GetHtml(int id)
        {
            Banner banner = repository.Get(id);
            BannerDTO value = new BannerDTO();
            value.Html = banner.Html;

            return value;
        }
    }
}
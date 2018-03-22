using BannerFlow.Models;
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
        public IEnumerable<Banner> GetAll()
        {
            return repository.GetAll();
        }

        // Return requested entry logic
        public Banner Get(int id)
        {
            return repository.Get(id);
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
    }
}
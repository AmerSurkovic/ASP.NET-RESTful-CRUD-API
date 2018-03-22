using BannerFlow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BannerFlow.Repositories
{
    public interface IBannerRepository
    {
        IEnumerable<Banner> GetAll();
        Banner Get(int id);
        Banner Add(Banner item);
        void Delete(int id);
        Banner Update(int id, Banner item);
        int GetLastKey();
    }
}

using BannerFlow.DataTransferObjects;
using BannerFlow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BannerFlow.Services
{
    public interface IBannerService
    {
        Banner Add(BannerDTO data);
        IEnumerable<BannerDTO> GetAll();
        BannerDTO Get(int id);
        Banner Update(int id, BannerDTO data);
        void Delete(int id);
    }
}

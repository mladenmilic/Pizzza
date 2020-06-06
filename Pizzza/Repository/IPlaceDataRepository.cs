using Pizzza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzza.Repository
{
    public interface IPlaceDataRepository 
    {
        Task<List<Place>> GetAll();
        Task<Place> Get(int id);
    }
}

using Pizzza.Models;
using Pizzza.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzza.Repository
{
    public interface IDataRepository
    {

        Task<List<User>> GetAllAsync();
        Task<UserResponse> Get(string username , string password);
    }
}

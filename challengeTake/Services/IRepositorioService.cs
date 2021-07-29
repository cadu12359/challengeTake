using challengeTake.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace challengeTake.Services
{
    public interface IRepositorioService
    {
        Task<object> GetRepositorios();
    }
}

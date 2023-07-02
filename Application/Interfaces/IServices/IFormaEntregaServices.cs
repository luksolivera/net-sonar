using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IFormaEntregaServices
    {
        //Task CreateFormaEntrega();
        Task<IEnumerable<FormaEntrega>> GetAllFormaEntrega();
        Task<FormaEntrega> GetFormaEntregaById(int id);
        Task AddFormaEntrega(FormaEntrega formaEntrega);
        Task UpdateFormaEntrega(FormaEntrega formaEntrega);
        Task DeleteFormaEntrega(int id);
    }
}

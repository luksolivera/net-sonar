using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IMercaderiaServices
    {
        //Task CreateMercaderia();
        Task<IEnumerable<Mercaderia>> GetAllMercaderia();
        Task<Mercaderia> GetMercaderiaById(int id);
        Task AddMercaderia(Mercaderia mercaderia);
        Task UpdateMercaderia(Mercaderia mercaderia);
        Task DeleteMercaderia(int id);
    }
}

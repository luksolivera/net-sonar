using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface ITipoMercaderiaServices
    {
        //Task CreateTipoMercaderia();
        Task<IEnumerable<TipoMercaderia>> GetAllTipoMercaderia();
        Task<TipoMercaderia> GetTipoMercaderiaById(int id);
        Task AddTipoMercaderia(TipoMercaderia tipomercaderia);
        Task UpdateTipoMercaderia(TipoMercaderia tipomercaderia);
        Task DeleteTipoMercaderia(int id);
    }
}

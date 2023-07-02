using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IQuerys
{
    public interface ITipoMercaderiaQuery
    {
        Task<IEnumerable<TipoMercaderia>> GetAll();
        Task<TipoMercaderia> GetById(int id);
    }
}

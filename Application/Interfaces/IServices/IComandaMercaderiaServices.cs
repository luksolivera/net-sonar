using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IComandaMercaderiaServices
    {
        //Task CreateComandaMercaderia();
        Task<IEnumerable<ComandaMercaderia>> GetAllComandaMercaderia();
        Task<ComandaMercaderia> GetComandaMercaderiaById(int id);
        Task AddComandaMercaderia(ComandaMercaderia comandaMercaderia);
        Task UpdateComandaMercaderia(ComandaMercaderia comandaMercaderia);
        Task DeleteComandaMercaderia(int id);
    }
}

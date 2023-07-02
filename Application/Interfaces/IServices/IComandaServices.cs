using Application.UseCase.Requests;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IComandaServices
    {
        Task CreateComanda(List<CreateComandaRequest> ComandaRequest);
        Task<IEnumerable<Comanda>> GetAllComandas();
        Task<Comanda> GetComandaById(Guid id);
        Task AddComanda(Comanda comanda);
        Task UpdateComanda(Comanda comanda);
        Task DeleteComanda(Guid id);
    }
}

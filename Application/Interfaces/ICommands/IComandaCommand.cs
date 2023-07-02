using Application.UseCase.Requests;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.ICommands
{
    public interface IComandaCommand
    {
        Task Create(List<CreateComandaRequest> comandaRequest);
        Task Insert(Comanda comanda);
        Task Update(Comanda comanda);
        Task Delete(Guid id);
    }
}

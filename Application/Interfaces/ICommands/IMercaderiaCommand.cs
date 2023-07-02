using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.ICommands
{
    public interface IMercaderiaCommand
    {
        //Task Create();
        Task Insert(Mercaderia mercaderia);
        Task Update(Mercaderia mercaderia);
        Task Delete(int id);
    }
}

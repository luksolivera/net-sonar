using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.ICommands
{
    public interface ITipoMercaderiaCommand
    {
        //Task Create();
        Task Insert(TipoMercaderia tipomercaderia);
        Task Update(TipoMercaderia tipomercaderia);
        Task Delete(int id);
    }
}

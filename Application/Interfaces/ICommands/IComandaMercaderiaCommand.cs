using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.ICommands
{
    public interface IComandaMercaderiaCommand
    {
        //Task Create();
        Task Insert(ComandaMercaderia comandaMercaderia);
        Task Update(ComandaMercaderia comandaMercaderia);
        Task Delete(int id);
    }
}

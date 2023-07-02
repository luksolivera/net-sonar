using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IQuerys
{
    public interface IFormaEntregaQuery
    {
        Task <IEnumerable<FormaEntrega>> GetAll();
        Task <FormaEntrega> GetById(int id);
    }
}

using Application.Interfaces.ICommands;
using Application.Interfaces.IQuerys;
using Application.Interfaces.Services;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase
{

    public class ComandaMercaderiaServices : IComandaMercaderiaServices
    {
        private readonly IComandaMercaderiaCommand _comandaMercaderiaCommand;
        private readonly IComandaMercaderiaQuery _comandaMercaderiaQuery;

        public ComandaMercaderiaServices(IComandaMercaderiaCommand comandaMercaderiaCommand, IComandaMercaderiaQuery comandaMercaderiaQuery)
        {
            _comandaMercaderiaCommand = comandaMercaderiaCommand;
            _comandaMercaderiaQuery = comandaMercaderiaQuery;
        }

        public async Task AddComandaMercaderia(ComandaMercaderia mercaderia)
        {
            await _comandaMercaderiaCommand.Insert(mercaderia);
        }

        //public Task CreateComandaMercaderia()
        //{
        //    throw new NotImplementedException();
        //}

        public async Task DeleteComandaMercaderia(int id)
        {
            await _comandaMercaderiaCommand.Delete(id);
        }

        public async Task<IEnumerable<ComandaMercaderia>> GetAllComandaMercaderia()
        {
            return await _comandaMercaderiaQuery.GetAll();
        }

        public async Task<ComandaMercaderia> GetComandaMercaderiaById(int id)
        {
            return await _comandaMercaderiaQuery.GetById(id);
        }

        public async Task UpdateComandaMercaderia(ComandaMercaderia comandaMercaderia)
        {
            await _comandaMercaderiaCommand.Update(comandaMercaderia);
        }
    }
}

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
    public class MercaderiaServices : IMercaderiaServices
    {
        private readonly IMercaderiaCommand _mercaderiaCommand;
        private readonly IMercaderiaQuery _mercaderiaQuery;

        public MercaderiaServices(IMercaderiaCommand mercaderiaCommand, IMercaderiaQuery mercaderiaQuery)
        {
            _mercaderiaCommand = mercaderiaCommand;
            _mercaderiaQuery = mercaderiaQuery;
        }

        public async Task AddMercaderia(Mercaderia mercaderia)
        {
            await _mercaderiaCommand.Insert(mercaderia);
        }

        //public Task CreateMercaderia()
        //{
        //    throw new NotImplementedException();
        //}

        public async Task DeleteMercaderia(int id)
        {
            await _mercaderiaCommand.Delete(id);
        }

        public async Task<IEnumerable<Mercaderia>> GetAllMercaderia()
        {
            return await _mercaderiaQuery.GetAll();
        }

        public async Task<Mercaderia> GetMercaderiaById(int id)
        {
            return await _mercaderiaQuery.GetById(id);
        }

        public async Task UpdateMercaderia(Mercaderia mercaderia)
        {
            await _mercaderiaCommand.Update(mercaderia);
        }
    }
}

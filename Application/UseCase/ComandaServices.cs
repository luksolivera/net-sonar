using Application.Interfaces.ICommands;
using Application.Interfaces.IQuerys;
using Application.Interfaces.Services;
using Application.UseCase.Requests;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.UseCase
{
    public class ComandaServices : IComandaServices
    {
        private readonly IComandaCommand _comandaCommand;
        private readonly IComandaQuery _comandaQuery;

        public ComandaServices(IComandaCommand comandaCommand, IComandaQuery comandaQuery)
        {
            _comandaCommand = comandaCommand;
            _comandaQuery = comandaQuery;
        }

        public async Task<IEnumerable<Comanda>> GetAllComandas()
        {
            return await _comandaQuery.GetAll();
        }

        public async Task<Comanda> GetComandaById(Guid id)
        {
            return await _comandaQuery.GetById(id);
        }

        public async Task AddComanda(Comanda comanda)
        {
            await _comandaCommand.Insert(comanda);
        }

        public async Task UpdateComanda(Comanda comanda)
        {
            await _comandaCommand.Update(comanda);
        }

        public async Task DeleteComanda(Guid id)
        {
            await _comandaCommand.Delete(id);
        }

        public async Task CreateComanda (List<CreateComandaRequest> ComandaRequest) 
        {
            await _comandaCommand.Create(ComandaRequest);
        }
    }
}

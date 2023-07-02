using Domain.Entities;
using Infraestructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces.ICommands;
using Application.UseCase.Requests;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Infraestructure.Command
{
    public class ComandaCommand : IComandaCommand
    {
        private readonly AppDbcontext _context;
        public ComandaCommand(AppDbcontext context)
        {
            _context = context;
        }
       
        public async Task Insert(Comanda comanda)
        {

            await _context.Comanda.AddAsync(comanda);

            await _context.SaveChangesAsync();

        }
        public async Task Update(Comanda comanda)
        {
            _context.Entry(comanda).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            Comanda comanda = await _context.Comanda.FindAsync(id);
            _context.Comanda.Remove(comanda);
            await _context.SaveChangesAsync();
        }


        public async Task Create(List<CreateComandaRequest> comandaRequests)
        {
            var groupedRequests = comandaRequests.GroupBy(cr => cr.ComandaId);

            foreach (var group in groupedRequests)
            {
                Comanda newComanda = new Comanda
                {
                    FormaEntregaId = group.First().FormaEntregaId,
                    Fecha = DateTime.Now,
                    ComandaMercaderia = new List<ComandaMercaderia>()
                };

                foreach (var comandaRequest in group)
                {
                    ComandaMercaderia newComandaMercaderia = new ComandaMercaderia
                    {
                        MercaderiaId = comandaRequest.MercaderiaId,
                        Mercaderia = _context.Mercaderia.FirstOrDefault(m => m.MercaderiaId == comandaRequest.MercaderiaId),
                        Comanda = newComanda,
                        ComandaId = comandaRequest.ComandaId
                    };

                    newComanda.ComandaMercaderia.Add(newComandaMercaderia);
                    newComanda.PrecioTotal += newComandaMercaderia.Mercaderia.Precio;
                    _context.ComandaMercaderia.Add(newComandaMercaderia);
                }

                _context.Comanda.Add(newComanda);
            }

            _context.SaveChanges();
        }

    }
}











using Application.Interfaces.ICommands;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Commands
{
    public class MercaderiaCommand : IMercaderiaCommand
    {
        private readonly AppDbcontext _context;
        public MercaderiaCommand(AppDbcontext context)
        {
            _context = context;
        }

        public async Task Insert(Mercaderia mercaderia)
        {

            await _context.Mercaderia.AddAsync(mercaderia);

            await _context.SaveChangesAsync();

        }
        public async Task Update(Mercaderia mercaderia)
        {
            _context.Entry(mercaderia).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Mercaderia mercaderia = await _context.Mercaderia.FindAsync(id);
            _context.Mercaderia.Remove(mercaderia);
            await _context.SaveChangesAsync();
        }

        //public Task Create()
        //{
        //    throw new NotImplementedException();
        //}
    }
}

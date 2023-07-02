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
    public class FormaEntregaCommand : IFormaEntregaCommand
    {
        private readonly AppDbcontext _context;
        public FormaEntregaCommand(AppDbcontext context)
        {
            _context = context;
        }

        public async Task Insert(FormaEntrega FormaEntrega)
        {

            await _context.FormaEntrega.AddAsync(FormaEntrega);

            await _context.SaveChangesAsync();

        }
        public async Task Update(FormaEntrega FormaEntrega)
        {
            _context.Entry(FormaEntrega).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            FormaEntrega FormaEntrega = await _context.FormaEntrega.FindAsync(id);
            _context.FormaEntrega.Remove(FormaEntrega);
            await _context.SaveChangesAsync();
        }

        //public Task Create()
        //{
        //    throw new NotImplementedException();
        //}
    }
}

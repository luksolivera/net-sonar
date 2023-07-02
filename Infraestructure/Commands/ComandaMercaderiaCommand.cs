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
    public class ComandaMercaderiaCommand :IComandaMercaderiaCommand
    {
        private readonly AppDbcontext _context;
        public ComandaMercaderiaCommand(AppDbcontext context)
        {
            _context = context;
        }

        public async Task Insert(ComandaMercaderia comandaMercaderia)
        {

            await _context.ComandaMercaderia.AddAsync(comandaMercaderia);

            await _context.SaveChangesAsync();

        }
        public async Task Update(ComandaMercaderia comandaMercaderia)
        {
            _context.Entry(comandaMercaderia).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            ComandaMercaderia comandaMercaderia = await _context.ComandaMercaderia.FindAsync(id);
            _context.ComandaMercaderia.Remove(comandaMercaderia);
            await _context.SaveChangesAsync();
        }

        //public Task Create()
        //{
        //    throw new NotImplementedException();
        //}
    }
}

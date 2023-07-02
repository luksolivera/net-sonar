using Application.Interfaces.IQuerys;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Querys
{
    public class ComandaQuery : IComandaQuery
    {
        private readonly AppDbcontext _context;
        public ComandaQuery(AppDbcontext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Comanda>> GetAll()
        {
            return await _context.Comanda
           .Include(c => c.ComandaMercaderia) 
           .ToListAsync();
        }
        public async Task<Comanda> GetById(Guid id)
        {
            return await _context.Comanda.FindAsync(id);
        }
    }
}

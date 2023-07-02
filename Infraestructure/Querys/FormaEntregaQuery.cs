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
    public class FormaEntregaQuery : IFormaEntregaQuery
    {
        private readonly AppDbcontext _context;
        public FormaEntregaQuery(AppDbcontext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<FormaEntrega>> GetAll()
        {
            return await _context.FormaEntrega.ToListAsync();
        }
        public async Task<FormaEntrega> GetById(int id)
        {
            return await _context.FormaEntrega.FindAsync(id);
        }
    }
}

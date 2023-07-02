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
    public class MercaderiaQuery : IMercaderiaQuery
    {
        private readonly AppDbcontext _context;
        public MercaderiaQuery(AppDbcontext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Mercaderia>> GetAll()
        {
            return await _context.Mercaderia.ToListAsync();
        }
        public async Task<Mercaderia> GetById(int id)
        {
            return await _context.Mercaderia.FindAsync(id);
        }
    }
}

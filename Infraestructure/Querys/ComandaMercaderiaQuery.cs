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
    public class ComandaMercaderiaQuery : IComandaMercaderiaQuery
    {
        private readonly AppDbcontext _context;
        public ComandaMercaderiaQuery(AppDbcontext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ComandaMercaderia>> GetAll()
        {
            return await _context.ComandaMercaderia.ToListAsync();
        }
        public async Task<ComandaMercaderia> GetById(int id)
        {
            return await _context.ComandaMercaderia.FindAsync(id);
        }
    }
}

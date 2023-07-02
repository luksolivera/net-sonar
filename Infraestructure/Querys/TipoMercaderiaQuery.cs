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
    public class TipoMercaderiaQuery : ITipoMercaderiaQuery
    {
        private readonly AppDbcontext _context;
        public TipoMercaderiaQuery(AppDbcontext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TipoMercaderia>> GetAll()
        {
            return await _context.TipoMercaderia.ToListAsync();
        }
        public async Task<TipoMercaderia> GetById(int id)
        {
            return await _context.TipoMercaderia.FindAsync(id);
        }
    }
}

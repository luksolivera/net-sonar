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
    public class TipoMercaderiaCommand : ITipoMercaderiaCommand
    {
        private readonly AppDbcontext _context;
        public TipoMercaderiaCommand(AppDbcontext context)
        {
            _context = context;
        }
        
        public async Task Insert(TipoMercaderia tipoMercaderia)
        {

            await _context.TipoMercaderia.AddAsync(tipoMercaderia);

            await _context.SaveChangesAsync();

        }
        public async Task Update(TipoMercaderia tipoMercaderia)
        {
            _context.Entry(tipoMercaderia).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            TipoMercaderia tipoMercaderia = await _context.TipoMercaderia.FindAsync(id);
            _context.TipoMercaderia.Remove(tipoMercaderia);
            await _context.SaveChangesAsync();
        }

        //public Task Create()
        //{
        //    throw new NotImplementedException();
        //}
    }
}

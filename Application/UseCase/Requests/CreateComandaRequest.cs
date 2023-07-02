using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.UseCase.Requests
{
    public class CreateComandaRequest
    {
        public CreateComandaRequest(int formaEntregaId, int mercaderiaId)
        {
            FormaEntregaId = formaEntregaId;
            MercaderiaId = mercaderiaId;
        }
        public Guid ComandaId { get; set; }
        public int FormaEntregaId { get; set; }
        public int PrecioTotal { get; set; }
        public DateTime Fecha { get; set; }
        public int MercaderiaId { get; set; }
    }
}

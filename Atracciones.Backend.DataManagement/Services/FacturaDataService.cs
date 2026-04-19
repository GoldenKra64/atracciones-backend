using Atracciones.Backend.DataAccess.Repositories.Interfaces;
using Atracciones.Backend.DataManagement.Interfaces;
using Atracciones.Backend.DataManagement.Mappers;
using Atracciones.Backend.DataManagement.Models.Factura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataManagement.Services
{
    public class FacturaDataService : IFacturaDataService
    {
        private readonly IFacturaRepository _repo;

        public FacturaDataService(IFacturaRepository repo)
        {
            _repo = repo;
        }

        public async Task<FacturaModel?> GetByReservaAsync(int reservaId)
        {
            var data = await _repo.GetByReservaAsync(reservaId);
            return data == null ? null : FacturaMapper.ToModel(data);
        }
    }
}

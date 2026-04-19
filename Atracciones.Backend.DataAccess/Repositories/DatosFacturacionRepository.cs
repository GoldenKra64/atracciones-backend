using Atracciones.Backend.DataAccess.Context;
using Atracciones.Backend.DataAccess.Entities;
using Atracciones.Backend.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataAccess.Repositories
{
    public class DatosFacturacionRepository : Repository<DatosFacturacion>, IDatosFacturacionRepository
    {
        public DatosFacturacionRepository(AtraccionesDbContext context) : base(context) { }
    }
}

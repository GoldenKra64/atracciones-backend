using Atracciones.Backend.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataManagement.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IClienteRepository ClienteRepository { get; }
        IResenaRepository ResenaRepository { get; }
        IUsuarioRepository UsuarioRepository { get; }
        IReservaRepository ReservaRepository { get; }
        ITicketRepository TicketRepository { get; }
        IAtraccionRepository AtraccionRepository { get; }
        IImagenRepository ImagenRepository { get; }
        ICategoriaRepository CategoriaRepository { get; }
        IDestinoRepository DestinoRepository { get; }
        IIncluyeRepository IncluyeRepository { get; }
        IFacturaRepository FacturaRepository { get; }
        IDatosFacturacionRepository DatosFacturacionRepository { get; }
        IHorarioRepository HorarioRepository { get; }

        Task<int> SaveChangesAsync();

        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}

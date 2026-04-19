using Atracciones.Backend.Business.DTOs.Cliente;
using Atracciones.Backend.DataManagement.Models.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.Mappers
{
    public static class ClienteBusinessMapper
    {
        public static ClienteCreateModel ToCreateModel(CreateClienteRequest request)
        {
            return new ClienteCreateModel
            {
                UsuarioId = request.UsuarioId,
                TipoIdentificacion = request.TipoIdentificacion,
                NumeroIdentificacion = request.NumeroIdentificacion,
                Correo = request.Correo
            };
        }

        public static ClienteUpdateModel ToUpdateModel(UpdateClienteRequest request)
        {
            return new ClienteUpdateModel
            {
                Id = request.Id,
                Correo = request.Correo
            };
        }

        public static ClienteResponse ToResponse(ClienteModel model)
        {
            return new ClienteResponse
            {
                Id = model.Id,
                Guid = model.Guid,
                NumeroIdentificacion = model.NumeroIdentificacion,
                Correo = model.Correo,
                Nombres = model.Nombres
            };
        }
    }
}

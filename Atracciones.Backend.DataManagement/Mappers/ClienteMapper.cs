using Atracciones.Backend.DataAccess.Entities;
using Atracciones.Backend.DataManagement.Models.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataManagement.Mappers
{
    public static class ClienteMapper
    {
        public static ClienteModel ToModel(Cliente entity)
        {
            return new ClienteModel
            {
                Id = entity.CliId,
                Guid = entity.CliGuid,
                Estado = entity.CliEstado,

                TipoIdentificacion = entity.CliTipoIdentificacion,
                NumeroIdentificacion = entity.CliNumeroIdentificacion,
                Correo = entity.CliCorreo,
                Nombres = entity.CliNombres,
                Apellidos = entity.CliApellidos,
                Telefono = entity.CliTelefono
            };
        }

        public static Cliente ToEntity(ClienteCreateModel model)
        {
            return new Cliente
            {
                UsuId = model.UsuarioId,
                CliTipoIdentificacion = model.TipoIdentificacion,
                CliNumeroIdentificacion = model.NumeroIdentificacion,
                CliCorreo = model.Correo,
                CliNombres = model.Nombres,
                CliApellidos = model.Apellidos,
                CliEstado = "ACT"
            };
        }
        public static void UpdateEntity(Cliente entity, ClienteUpdateModel model)
        {
            entity.CliTipoIdentificacion = model.TipoIdentificacion;
            entity.CliNumeroIdentificacion = model.NumeroIdentificacion;
            entity.CliCorreo = model.Correo;
            entity.CliNombres = model.Nombres;
            entity.CliApellidos = model.Apellidos;
        }
    }
}

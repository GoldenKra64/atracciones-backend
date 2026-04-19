using Atracciones.Backend.DataAccess.Entities;
using Atracciones.Backend.DataManagement.Models.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataManagement.Mappers
{
    public static class UsuarioMapper
    {
        public static UsuarioModel ToModel(Usuario entity)
        {
            return new UsuarioModel
            {
                Id = entity.UsuId,
                Guid = entity.UsuGuid,
                Estado = entity.UsuEstado,
                Login = entity.UsuLogin
            };
        }
        public static Usuario ToEntity(UsuarioCreateModel entity)
        {
            return new Usuario
            {
                UsuGuid = Guid.NewGuid(),
                UsuLogin = entity.Login,
                UsuPasswordHash = entity.Password,
                UsuarioRoles = entity.RolIds.Select(rolId => new UsuarioRol { RolId = rolId }).ToList(),
                UsuEstado = "ACT",
            };
        }
        public static void UpdateEntity(Usuario entity, UsuarioUpdateModel model)
        {
            entity.UsuLogin = model.Login;
        }
    }
}

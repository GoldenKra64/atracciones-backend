using Atracciones.Backend.DataAccess.Repositories.Interfaces;
using Atracciones.Backend.DataManagement.Interfaces;
using Atracciones.Backend.DataManagement.Mappers;
using Atracciones.Backend.DataManagement.Models.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataManagement.Services
{
    public class UsuarioDataService : IUsuarioDataService
    {
        private readonly IUsuarioRepository _repo;

        public UsuarioDataService(IUsuarioRepository repo)
        {
            _repo = repo;
        }

        // ===============================
        // CREATE
        // ===============================
        public async Task<int> CreateAsync(UsuarioCreateModel model)
        {
            var entity = UsuarioMapper.ToEntity(model);

            await _repo.CreateAsync(entity);

            return entity.UsuId;
        }

        // ===============================
        // UPDATE
        // ===============================
        public async Task UpdateAsync(UsuarioUpdateModel model)
        {
            var entity = await _repo.GetByIdAsync(model.Id)
                ?? throw new Exception("Usuario no encontrado");

            UsuarioMapper.UpdateEntity(entity, model);

            await _repo.UpdateAsync(entity);
        }

        // ===============================
        // GET BY ID
        // ===============================
        public async Task<UsuarioModel?> GetByIdAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);

            return entity == null
                ? null
                : UsuarioMapper.ToModel(entity);
        }

        // ===============================
        // LOGIN
        // ===============================
        public async Task<UsuarioModel?> LoginAsync(string login, string password)
        {
            var entity = await _repo.LoginAsync(login, password);

            return entity == null
                ? null
                : UsuarioMapper.ToModel(entity);
        }

        // ===============================
        // CHANGE PASSWORD
        // ===============================
        public async Task ChangePasswordAsync(int usuarioId, string actual, string nuevo)
        {
            var entity = await _repo.GetByIdAsync(usuarioId)
                ?? throw new Exception("Usuario no encontrado");

            if (entity.UsuPasswordHash != actual)
                throw new Exception("Password actual incorrecto");

            entity.UsuPasswordHash = nuevo;

            await _repo.UpdateAsync(entity);
        }

        // ===============================
        // SOFT DELETE
        // ===============================
        public async Task SoftDeleteAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id)
                ?? throw new Exception("Usuario no encontrado");

            entity.UsuEstado = "INA";

            await _repo.UpdateAsync(entity);
        }
    }
}

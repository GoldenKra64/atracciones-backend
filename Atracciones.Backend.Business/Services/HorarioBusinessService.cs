using Atracciones.Backend.Business.DTOs.Horario;
using Atracciones.Backend.Business.Exceptions;
using Atracciones.Backend.Business.Interfaces;
using Atracciones.Backend.Business.Mappers;
using Atracciones.Backend.Business.Validators;
using Atracciones.Backend.DataManagement.Interfaces;
using Atracciones.Backend.DataManagement.Models.Horario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.Services
{
    public class HorarioBusinessService : IHorarioBusinessService
    {
        private readonly IHorarioDataService _dataService;

        public HorarioBusinessService(IHorarioDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task<int> CreateAsync(CreateHorarioRequest request)
        {
            HorarioValidator.ValidateCreate(request);

            var model = HorarioBusinessMapper.ToCreateModel(request);
            return await _dataService.CreateAsync(model);
        }

        public async Task<IEnumerable<HorarioDto>> GetAllAsync()
        {
            var data = await _dataService.GetAllAsync();
            return data.Select(HorarioBusinessMapper.ToResponse);
        }

        public async Task LogicalDeleteAsync(int id)
        {
            await _dataService.SoftDeleteAsync(id);
        }

        public async Task UpdateAsync(UpdateHorarioRequest request)
        {
            HorarioValidator.ValidateUpdate(request);

            var model = HorarioBusinessMapper.ToUpdateModel(request);
            await _dataService.UpdateAsync(model);
        }
    }
}

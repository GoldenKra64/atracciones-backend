using Atracciones.Backend.Business.DTOs.Atracciones;
using Atracciones.Backend.Business.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.Validators
{
    public static class AtraccionValidator
    {
        public static void ValidateCreate(CreateAtraccionRequest request)
        {
            var errors = new Dictionary<string, string[]>();

            if (string.IsNullOrWhiteSpace(request.Nombre))
                errors["Nombre"] = new[] { "Obligatorio" };

            if (request.DestinoId <= 0)
                errors["DestinoId"] = new[] { "Inválido" };

            if (request.PrecioReferencia != null && request.PrecioReferencia < 0)
                errors["Precio"] = new[] { "No puede ser negativo" };

            if (!request.CategoriaIds.Any())
                errors["Categorias"] = new[] { "Debe tener al menos una categoría" };

            if (request.IdiomaIds != null && request.IdiomaIds.Any(i => i <= 0))
                errors["Idiomas"] = new[] { "Idiomas inválidos" };

            if (request.IncluyeIds != null && request.IncluyeIds.Any(i => i <= 0))
                errors["Incluyes"] = new[] { "Incluyes inválidos" };

            if (errors.Any())
                throw new ValidationException(errors);
        }

        public static void ValidateUpdate(UpdateAtraccionRequest request)
        {
            if (request.Id <= 0)
                throw new ValidationException("Id inválido");

            ValidateCreate(request);
        }
    }
}

using Atracciones.Backend.Business.DTOs;
using Atracciones.Backend.Business.Interfaces;
using Atracciones.Backend.Business.Services;
using Atracciones.Backend.Business.Validators;
using Atracciones.Backend.DataAccess.Context;
using Atracciones.Backend.DataAccess.Entities;
using Atracciones.Backend.DataAccess.Queries;
using Atracciones.Backend.DataAccess.Queries.Interfaces;
using Atracciones.Backend.DataAccess.Repositories;
using Atracciones.Backend.DataAccess.Repositories.Interfaces;
using Atracciones.Backend.DataManagement.Interfaces;
using Atracciones.Backend.DataManagement.Services;
using Microsoft.EntityFrameworkCore;

namespace Atracciones.Backend.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // ===============================
            // DB CONTEXT
            // ===============================
            services.AddDbContext<AtraccionesDbContext>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("AtraccionesDbPG")));

            // ===============================
            // DATA SERVICES
            // ===============================
            services.AddScoped<IClienteDataService, ClienteDataService>();
            services.AddScoped<IAtraccionDataService, AtraccionDataService>();
            services.AddScoped<IDestinoDataService, DestinoDataService>();
            services.AddScoped<IUsuarioDataService, UsuarioDataService>();
            services.AddScoped<ICategoriaDataService, CategoriaDataService>();
            services.AddScoped<IFacturaDataService, FacturaDataService>();
            services.AddScoped<IIdiomaDataService, IdiomaDataService>();
            services.AddScoped<IImagenDataService, ImagenDataService>();
            services.AddScoped<IIncluyeDataService, IncluyeDataService>();
            services.AddScoped<INoIncluyeDataService, NoIncluyeDataService>();
            services.AddScoped<IResenaDataService, ResenaDataService>();
            services.AddScoped<IReservaDataService, ReservaDataService>();
            services.AddScoped<ITicketDataService, TicketDataService>();
            services.AddScoped<IHorarioDataService, HorarioDataService>();
            services.AddScoped<ITagDataService, TagDataService>();

            // ===============================
            // QUERIES
            // ===============================
            services.AddScoped<IClienteQuery, ClienteQuery>();
            services.AddScoped<IAtraccionQuery, AtraccionQuery>();
            services.AddScoped<IDestinoQuery, DestinoQuery>();
            services.AddScoped<ICategoriaQuery, CategoriaQuery>();
            services.AddScoped<IIdiomaQuery, IdiomaQuery>();
            services.AddScoped<IResenaQuery, ResenaQuery>();
            services.AddScoped<IReservaQuery, ReservaQuery>();
            services.AddScoped<ITicketQuery, TicketQuery>();
            services.AddScoped<IHorarioQuery, HorarioQuery>();
            services.AddScoped<ITagQuery, TagQuery>();

            // ===============================
            // REPOSITORIES
            // ===============================
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IAtraccionRepository, AtraccionRepository>();
            services.AddScoped<IDestinoRepository, DestinoRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IFacturaRepository, FacturaRepository>();
            services.AddScoped<IImagenRepository, ImagenRepository>();
            services.AddScoped<IIncluyeRepository, IncluyeRepository>();
            services.AddScoped<INoIncluyeRepository, NoIncluyeRepository>();
            services.AddScoped<IResenaRepository, ResenaRepository>();
            services.AddScoped<IRepository<Idioma>, IdiomaRepository>();
            services.AddScoped<IReservaRepository, ReservaRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<IHorarioRepository, HorarioRepository>();
            // services.AddScoped<ITagRepository, TagRepository>();

            // ===============================
            // UNIT OF WORK
            // ===============================
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            // ===============================
            // UNIT OF WORK
            // ===============================
            services.AddScoped<JwtSettings>();

            // ===============================
            // SERVICES (BUSINESS)
            // ===============================
            services.AddScoped<IClienteBusinessService, ClienteBusinessService>();
            services.AddScoped<IAtraccionBusinessService, AtraccionBusinessService>();
            services.AddScoped<IDestinoBusinessService, DestinoBusinessService>();
            services.AddScoped<IUsuarioBusinessService, UsuarioBusinessService>();
            services.AddScoped<ICategoriaBusinessService, CategoriaBusinessService>();
            services.AddScoped<IFacturaBusinessService, FacturaBusinessService>();
            services.AddScoped<IIdiomaBusinessService, IdiomaBusinessService>();
            services.AddScoped<IImagenBusinessService, ImagenBusinessService>();
            services.AddScoped<IIncluyeBusinessService, IncluyeBusinessService>();
            services.AddScoped<INoIncluyeBusinessService, NoIncluyeBusinessService>();
            services.AddScoped<IResenaBusinessService, ResenaBusinessService>();
            services.AddScoped<IReservaBusinessService, ReservaBusinessService>();
            services.AddScoped<ITicketBusinessService, TicketBusinessService>();
            services.AddScoped<IHorarioBusinessService, HorarioBusinessService>();
            services.AddScoped<ITagBusinessService, TagBusinessService>();


            return services;
        }
    }
}
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Seguros.Application.Interfaces;
using Seguros.Application.Services;
using Seguros.Domain.Account;
using Seguros.Domain.Interfaces;
using Seguros.Infra.Data.Context;
using Seguros.Infra.Data.Identity;
using Seguros.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seguros.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
            });

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = configuration["Jwt:Issuer"] ?? throw new InvalidOperationException("JWT issuer is not configured."),
                    ValidAudience = configuration["Jwt:Audience"] ?? throw new InvalidOperationException("JWT audience is not configured."),
                    IssuerSigningKey = new SymmetricSecurityKey(
                        System.Text.Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"] ?? throw new InvalidOperationException("JWT key is not configured."))),
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IApoliceRepository, ApoliceRepository>();
            services.AddScoped<IContatoRepository, ContatoRepository>();
            services.AddScoped<ISeguradoraRepository, SeguradoraRepository>();
            services.AddScoped<IPagamentoRepository, PagamentoRepository>();
            services.AddScoped<IParcelaRepository, ParcelaRepository>();
            services.AddScoped<ISinistroRepository, SinistroRepository>();            
            services.AddScoped<IArquivoApoliceRepository, ArquivoApoliceRepository>();

            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IEnderecoService, EnderecoService>();
            services.AddScoped<IAuthenticate, AuthenticateService>();
            services.AddScoped<IApoliceService, ApoliceService>();
            services.AddScoped<IContatoService, ContatoService>();
            services.AddScoped<ISeguradoraService, SeguradoraService>();
            services.AddScoped<IPagamentoService, PagamentoService>();
            services.AddScoped<IParcelaService, ParcelaService>();
            services.AddScoped<ISinistroService, SinistroService>();
            services.AddScoped<IArquivoApoliceService, ArquivoApoliceService>();

            return services;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using Seguros.API.Middleware;
using Seguros.Infra.Data.Context;
using Seguros.Infra.Ioc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddInfrastructure(builder.Configuration);

// Garantir registro explícito caso a extensão não esteja executando como esperado
// (opcional — remove se duplicar registros)
builder.Services.AddScoped<Seguros.Domain.Interfaces.IClienteRepository, Seguros.Infra.Data.Repositories.ClienteRepository>();
builder.Services.AddScoped<Seguros.Application.Interfaces.IClienteService, Seguros.Application.Services.ClienteService>();


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Description = "JWT Authorization header using the Bearer scheme."
    });
    options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        [new OpenApiSecuritySchemeReference("bearer", document)] = []
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<ExceptionMiddleware>();

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    dbContext.Database.Migrate();
}

app.Run();

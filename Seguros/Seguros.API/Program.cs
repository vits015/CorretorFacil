using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi;
using Seguros.API.Middleware;
using Seguros.Infra.Data.Context;
using Seguros.Infra.Ioc;
using Amazon;
using Amazon.S3;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var accessKey = builder.Configuration["Supabase:S3AccessKey"]!;
var secretKey = builder.Configuration["Supabase:S3SecretKey"]!;

var s3Config = new AmazonS3Config
{
    ServiceURL =
        "https://yqpcbpwirvidfombpggu.storage.supabase.co/storage/v1/s3",

    AuthenticationRegion = "us-east-1",
    ForcePathStyle = true
};

builder.Services.AddSingleton<IAmazonS3>(
    new AmazonS3Client(accessKey, secretKey, s3Config));

builder.Services.AddControllers();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .RequireRole("Administrador")
        .Build();
});

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    //dbContext.Database.Migrate();
}

app.Run();

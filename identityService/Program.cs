using Bussines.identityBussines.implementations;
using Bussines.identityBussines.interfaces;
using Bussines.inventoryBussines.interfaces;
using Data.interfaces.Identity;
using Data.Models;
using Data.Models.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<DbContext,MonsaSessionContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>) );
builder.Services.AddScoped(typeof(IUsuarioData), typeof(UsuarioData));
builder.Services.AddScoped(typeof(IUsuarioBussines), typeof(UsuarioBussines));
builder.Services.AddScoped(typeof(ITipoDocumentoData), typeof(TipoDocumentoData));
builder.Services.AddScoped(typeof(ITipoDocumentoBusines), typeof(TipoDocumentoBussines));

builder.Services.AddScoped(typeof(IAuditoriaData), typeof(AuditoriaData));
builder.Services.AddScoped(typeof(IAuditoriaBussines), typeof(AuditoriaBussines));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

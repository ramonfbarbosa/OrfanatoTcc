using FluentValidation;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OrfanatoAPI.Context;
using OrfanatoAPI.Models;
using OrfanatoAPI.Repositories;
using OrfanatoAPI.Services;
using OrfanatoAPI.Validators;
using System.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

string connectionString = builder.Configuration.GetConnectionString("ORFANATO_MANAGER");
builder.Services.AddTransient<IDbConnection>(conn => new SqlConnection(connectionString));
builder.Services.AddDbContext<OrfanatoContext>(options =>
{
    options.UseSqlServer(connectionString);
    options.UseLazyLoadingProxies();
});

builder.Services.AddTransient<IOrfanatoRepository, OrfanatoRepository>();
builder.Services.AddTransient<IOrfanatoService, OrfanatoService>();
builder.Services.AddTransient<IValidator<Orfanato>, OrfanatoValidator>();
builder.Services.AddTransient<IImagensRepository, ImagensRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

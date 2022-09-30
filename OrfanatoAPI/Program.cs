using OrfanatoAPI.Repositories;
using OrfanatoAPI.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddTransient<IOrfanatoRepository, OrfanatoRepository>();
builder.Services.AddTransient<IImagensRepository, ImagensRepository>();
builder.Services.AddTransient<IOrfanatoService, OrfanatoService>();
builder.Services.AddTransient<IImagensService, ImagensService>();
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

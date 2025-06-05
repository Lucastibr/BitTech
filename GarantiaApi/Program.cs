using Core.Domain;
using Core.Repository;
using Data.Repository;
using Service.Interfaces;
using Service.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IRepository<Garantia>, RepositoryBase<Garantia>>();
builder.Services.AddSingleton<IHttpService<Garantia>, HttpServiceBase<Garantia>>();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.MapOpenApi();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

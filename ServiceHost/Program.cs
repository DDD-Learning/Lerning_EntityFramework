using Application;
using Domain.Model.Orders;
using Microsoft.EntityFrameworkCore;
using Persistence.EF;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<Persistence.EF.OrderDbContext>(options =>
{
    options.UseSqlServer();
});

builder.Services.AddControllers()
    .AddApplicationPart(Assembly.Load(new AssemblyName(nameof(RestApi))));

builder.Services.AddHealthChecks();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHealthChecks("/health");
});

app.MapControllers();

app.Run();

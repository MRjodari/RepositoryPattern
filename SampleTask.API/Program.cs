using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SampleTask.Application.CQRS.Commands;
using SampleTask.Application.Interfaces.Repos;
using SampleTask.Domain.Entities;
using SampleTask.Persistence.Context;
using SampleTask.Persistence.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "SampleTask API", Version = "v1" });
    c.EnableAnnotations();
});


builder.Services.AddMediatR(typeof(SaveCustomerCommand));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

//builder.Services.AddScoped<IGenericRepository<Customer>, GenericRepository<Customer>>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddDbContext<AppDbContext>(option =>
                    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var config = new AutoMapper.MapperConfiguration(cfg =>
{ cfg.AddProfile(new SampleTask.Application.AutoMapperConfig());
});
var mapper=config.CreateMapper();
builder.Services.AddSingleton(mapper);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

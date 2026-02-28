using System.Reflection;
using CleanProduct.Application;
using CleanProduct.Application.Common.Behaviors;
using CleanProduct.Application.Features.Products.Commands.CreateProduct;
using CleanProduct.Application.Features.Products.Queries.GetProducts.GetProductsQuery;
using CleanProduct.Application.Features.ProductTypes.Commands.CreateProductType;
using CleanProduct.Application.Interfaces;
using CleanProduct.Application.Mapping;
using CleanProduct.Infrastructure.Persistence;
using CleanProduct.Infrastructure.Repository;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.





// MediatR + validation pipeline
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateProductCommandValidator>());
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

//MediatR Exmple from previous project

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
    Assembly.GetAssembly(typeof(CreateProductCommandHandler)) ,
    Assembly.GetAssembly(typeof(CreateProductTypeCommandHandler))

));



//MediatR for CQRS
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

//Add FluentValidation 
builder.Services.AddScoped<IValidator<CreateProductCommand>, CreateProductCommandValidator>();

//Add AutoMapper

builder.Services.AddAutoMapper(cfg => { }, typeof(GetProductsQueryHandler).Assembly);
builder.Services.AddAutoMapper(typeof(ProductTypeProfile).Assembly);
builder.Services.AddAutoMapper(typeof(ProductProfile).Assembly);


//DI for repositories
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductTypeRepository, ProductTypeRepository>();

//add sql server connection 
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));





builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

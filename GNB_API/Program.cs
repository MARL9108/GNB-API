using AutoMapper;
using GNB_Repository.Base;
using GNB_Repository.Context;
using GNB_Repository.Models;
using GNB_Service.Mapper;
using GNB_Service.Repository;
using GNB_Service.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient<IGnbAPI, GnbAPIService>();
builder.Services.AddScoped<IConversionRate, ConversionRateService>();
builder.Services.AddScoped<ITransaction, TransactionService>();
builder.Services.AddScoped<IRateRepository, RateRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddDbContext<GNBContext>(
    options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly(typeof(GNBContext).Assembly.FullName))
    );

builder.Services.AddControllers();

// Auto Mapper Configurations
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MapperProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

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

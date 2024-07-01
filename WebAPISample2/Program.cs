using Microsoft.EntityFrameworkCore;
using WebAPISample.Repository;
using WebAPISample.Service;
using WebAPISample2.EF;
using WebAPISample2.Infrastructure;
using WebAPISample2.Interface.Repository;
using WebAPISample2.Interface.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// ConnectDB
builder.Services.AddDbContext<SampleDbContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("SampleDbContextConnection")));
// AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Services
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ISampleRepository, SampleRepository>();
builder.Services.AddScoped<ISampleService, SampleService>();

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
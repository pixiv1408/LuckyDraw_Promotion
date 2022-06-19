using CMS_Lucky;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CMS_Lucky.Data;
using TransactionLibrary.Interface;
using TransactionLibrary.UnitOfWork;
using TransactionLibrary.IService;
using TransactionLibrary.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CMS_LuckyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CMS_LuckyContext") ?? throw new InvalidOperationException("Connection string 'CMS_LuckyContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.ServicesCollection(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IPositionService, PositionService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

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

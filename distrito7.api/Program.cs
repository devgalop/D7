using System.Net;
using System.ComponentModel;
using distrito7.api.Data;
using distrito7.api.Data.Repositories;
using distrito7.core.Interfaces;
using distrito7.core.Services;
using Microsoft.EntityFrameworkCore;
using dotenv.net;
using dotenv.net.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
DotEnv.Load();
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IMapperService, MapperService>();
builder.Services.AddScoped<ISecurityService, SecurityService>();
builder.Services.AddScoped<IPaymentPlanService, PaymentPlanService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<DataContext>(options =>
{
    string dbServer = EnvReader.GetStringValue("DBSERVER");
    string dbName = EnvReader.GetStringValue("DBNAME");
    string connectionString = $"Server={dbServer};Database={dbName};Trusted_Connection=True;TrustServerCertificate=True;";
    options.UseSqlServer(builder.Configuration.GetConnectionString("D7"));
    options.UseSqlServer(connectionString);
});
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

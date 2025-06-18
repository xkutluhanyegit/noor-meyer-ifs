using Application.Interfaces;
using Application.Services;
using Infrastracture.Persistence.Repositories.Dapper.NoorEmployeeRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

var connectionString = "User Id=IFSAPP;Password=TIMETRAVEL;Data Source=192.168.48.20:1521/PROD";



builder.Services.AddScoped<ITestNoorEmpService, TestNoorEmployeeService>();
builder.Services.AddScoped<INoorEmployeeRepository>(provider =>
    new NoorEmployeeRepository(connectionString));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapControllers();
app.Run();


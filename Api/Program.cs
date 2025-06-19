using Application.Interfaces;
using Application.Services;
using Infrastracture.ExternalServices.MeyerApi.Interfaces;
using Infrastracture.ExternalServices.MeyerApi.Services;
using Infrastracture.Persistence.Repositories.Dapper.NoorEmployeeRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

var connectionString = "User Id=IFSAPP;Password=TIMETRAVEL;Data Source=192.168.48.20:1521/PROD";


builder.Services.AddScoped<INoorEmployeeImgService, NoorEmployeeImgService>();
builder.Services.AddScoped<INoorEmployeeImgRepository>(provider =>
    new NoorEmployeeImgRepository(connectionString));
builder.Services.AddScoped<INoorEmployeeService, NoorEmployeeService>();
builder.Services.AddScoped<INoorEmployeeRepository>(provider =>
    new NoorEmployeeRepository(connectionString));


builder.Services.AddScoped<IMeyerSetSicilFotografService, MeyerSetSicilFotografService>();

builder.Services.AddScoped<IMeyerTokenService,MeyerTokenService>();
builder.Services.AddHttpClient<MeyerTokenService>();


builder.Services.AddScoped<IMeyerSetSicilService,MeyerSetSicilService>();
builder.Services.AddHttpClient<MeyerSetSicilService>();




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


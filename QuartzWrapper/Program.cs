using System.Reflection;
using Quartz.Abstraction.Configuration;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//var jobConfiguration = new JobAbstractService();
//jobConfiguration.JobRunnerConfiguration(Assembly.GetExecutingAssembly());

builder.Services.JobRunnerConfiguration(Assembly.GetExecutingAssembly());

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

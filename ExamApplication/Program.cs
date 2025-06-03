using ExamApplication.Data;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();



var conStringDba = builder.Configuration.GetConnectionString("OracleDb");

builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseOracle(conStringDba));


using (OracleConnection con = new OracleConnection(conStringDba))
{
    using (OracleCommand cmd = con.CreateCommand())
    {
        try
        {
            con.Open();
            Console.WriteLine("Successfully connected to Oracle Database");

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}


 var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(builder =>
        builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());


}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

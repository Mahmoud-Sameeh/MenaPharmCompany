using Data;
using Data.Repoitories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MenaPharmCompanyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MenaPharmCompanyContext")
                         ?? throw new InvalidOperationException("Connection string 'MenaPharmCompanyContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options =>
    options.AllowAnyHeader()
           .AllowAnyMethod()
           .AllowAnyOrigin());
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

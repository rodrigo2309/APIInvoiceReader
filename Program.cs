using APIInvoiceReader.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddDbContext<InvoiceReaderDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configuração da String de Conexão
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<InvoiceReaderDbContext_MySQL>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddDbContext<InvoiceReaderDbContext, InvoiceReaderDbContext>();
builder.Services.AddTransient<IReaderService, ReaderService>();
builder.Services.AddTransient<IAccountTypeService, AccountTypeService>();
builder.Services.AddTransient<IAccountTypeRepository, AccountTypeRepository>();
builder.Services.AddControllers();

// Adicione serviços de CORS
builder.Services.AddCors(options =>
{
  options.AddPolicy("AllowSpecificOrigin", policy =>
  {
    policy.WithOrigins("http://127.0.0.1:5500") // Permite uma origem específica
          .AllowAnyHeader()
          .AllowAnyMethod();
  });

  options.AddPolicy("AllowAllOrigins", policy =>
  {
    policy.AllowAnyOrigin() // Permite todas as origens
            .AllowAnyHeader()
            .AllowAnyMethod();
  });
});

var app = builder.Build();

app.UseCors("AllowAllOrigins");

app.UseRouting();

app.MapControllers();

// app.UseEndpoints(endpoints =>
// {
//   endpoints.MapControllerRoute(
//     name: "default",
//     pattern: "{controller:Home}/{action=Index}/{id?}");
// });

app.Run();

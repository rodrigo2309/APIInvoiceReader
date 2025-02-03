using APIInvoiceReader.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddDbContext<TodoContext>(opt =>
//     opt.UseInMemoryDatabase("TodoList"));

builder.Services.AddDbContext<InvoiceReaderDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddTransient<IReaderService, ReaderService>();

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

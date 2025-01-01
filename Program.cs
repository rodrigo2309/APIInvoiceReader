using APIInvoiceReader.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddTransient<IReaderService, ReaderService>();

// builder.Services.AddDbContext<TodoContext>(opt =>
//     opt.UseInMemoryDatabase("TodoList"));

var app = builder.Build();

app.UseRouting();

app.MapControllers();

// app.UseEndpoints(endpoints =>
// {
//   endpoints.MapControllerRoute(
//     name: "default",
//     pattern: "{controller:Home}/{action=Index}/{id?}");
// });

app.Run();

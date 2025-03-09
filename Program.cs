using System.Text;
using APIInvoiceReader.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;


var builder = WebApplication.CreateBuilder(args);

// Configuração da String de Conexão
var connectionString = builder.Configuration.GetConnectionString("ConnectionPostgre");

// builder.Services.AddDbContext<InvoiceReaderDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// builder.Services.AddDbContext<InvoiceReaderDbContextPostgre>(options =>
//     options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSqlConnection")));
builder.Services.AddDbContext<InvoiceReaderDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddDbContext<InvoiceReaderDbContext, InvoiceReaderDbContext>();
builder.Services.AddTransient<IReaderService, ReaderService>();
builder.Services.AddTransient<IAccountTypeService, AccountTypeService>();
builder.Services.AddTransient<ITokenService, TokenService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IAccountTypeRepository, AccountTypeRepository>();
builder.Services.AddControllers();

var key = Encoding.ASCII.GetBytes(Settings.Secret);

builder.Services.AddAuthentication(x =>
{
  x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
  x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
  x.RequireHttpsMetadata = false;
  x.SaveToken = true;
  x.TokenValidationParameters = new TokenValidationParameters
  {
    ValidateIssuerSigningKey = true,
    IssuerSigningKey = new SymmetricSecurityKey(key),
    ValidateIssuer = false,
    ValidateAudience = false
  };
});


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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// app.UseEndpoints(endpoints =>
// {
//   endpoints.MapControllerRoute(
//     name: "default",
//     pattern: "{controller:Home}/{action=Index}/{id?}");
// });

app.Run();

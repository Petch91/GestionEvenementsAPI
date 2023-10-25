using DAL_ADO.Interfaces;
using DAL_ADO.Services;
using GestionEvenementsAPI.Tools;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Data.SqlClient;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient(sp => new SqlConnection(builder.Configuration.GetConnectionString("default")));

builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IEventTypeDayService, EventTypeDayService>();
builder.Services.AddScoped<IEventTypeService, EventTypeService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IStatusService, StatusService>();

builder.Services.AddScoped<TokenManager>();

builder.Services.AddAuthorization(options =>
{
   options.AddPolicy("AdminPolicy", o => o.RequireRole("Admin"));
   options.AddPolicy("ModoPolicy", o => o.RequireRole("Admin", "Modo"));

   options.AddPolicy("IsConnected", o => o.RequireAuthenticatedUser());
});

// Expliquer à l'api comment valider le token
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
        options => options.TokenValidationParameters = new TokenValidationParameters()
        {
           ValidateLifetime = true,
           ValidateIssuer = true,
           ValidIssuer = "monserverapi.com",
           ValidateIssuerSigningKey = true,
           IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(TokenManager._secretKey)),
           ValidateAudience = false
        }

    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   app.UseSwagger();
   app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

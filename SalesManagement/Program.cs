
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SalesManagement.Core.Interfaces;
using SalesManagement.Core.Models;
using SalesManagement.Infrastructure;
using SalesManagement.Infrastructure.ServiceExtension;
using SalesManagement.Services;
using SalesManagement.Services.Interfaces;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// My Written Code Start
// db context register
object value = builder.Services.AddDIServices(builder.Configuration);
// service register
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IUnitService, UnitService>();
builder.Services.AddScoped<IUnitConvertionService, UnitConvertionService>();
builder.Services.AddScoped<IPharmacyService, PharmacyService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderItemService, OrderItemsService>();
builder.Services.AddScoped<ISalesTargetService, SalesTargetService>();
builder.Services.AddScoped<ISalesAchivementService, SalesAchivementService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IStockService, StockService>();

// enable cors
builder.Services.AddCors(option => option.AddPolicy("corsPolicy",policy=> policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod()));

// identity 
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(option =>
{
    option.Password.RequiredLength = 4;
    option.Password.RequireUppercase = false;
    option.Password.RequireLowercase = false;
    option.Password.RequireDigit = false;
    option.Password.RequireNonAlphanumeric = false;
    option.User.RequireUniqueEmail = true;
    
}).AddEntityFrameworkStores<DbContextClass>().AddDefaultTokenProviders();

// jwt bearer token generate
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer( option =>
{
    option.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "https://localhost:7140",
        ValidAudience = "https://localhost:7140",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345superSecretKey@345"))
    };
});

// register ITokenService
builder.Services.AddTransient<ITokenService, TokenService>();
// My Written Code End

// Add services to the container.

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

// My Written Code Start
app.UseCors("corsPolicy");
// My Written Code End

app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

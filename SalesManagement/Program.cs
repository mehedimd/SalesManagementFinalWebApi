
using SalesManagement.Infrastructure.ServiceExtension;
using SalesManagement.Services;
using SalesManagement.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// My Written Code Start
object value = builder.Services.AddDIServices(builder.Configuration);
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

builder.Services.AddCors(option => option.AddPolicy("corsPolicy",policy=> policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod()));
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

app.UseAuthorization();

app.MapControllers();

app.Run();

using Cart.Data;
using Cart.Extensions;
using Cart.Services;
using Cart.Services.IService;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//connect to DB
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("myconnection"));
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.AddAuth();
builder.AddSwaggenGenExtension();


builder.Services.AddScoped<IProduct, ProductService>();
//builder.Services.AddScoped<ICart, CartService();
//builder.Services.AddScoped<ICoupon, CouponService>();
builder.Services.AddScoped<IBuyer, BuyerService>();

builder.Services.AddHttpClient("Products", c => c.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ServiceURl:TourService")));
builder.Services.AddHttpClient("Coupon", c => c.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ServiceURl:CouponService")));
builder.Services.AddHttpClient("Buyers", c => c.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ServiceURl:BuyerService")));

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

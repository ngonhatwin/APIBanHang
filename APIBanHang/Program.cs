using APIBanHang.Data;
using APIBanHang.Models;
using APIBanHang.Repository;
using APIBanHang.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<XyzContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDB")));
builder.Services.AddScoped<IRepository<MKhachHang>, KhachHangRepository>();
builder.Services.AddScoped<IKhachHangServices, KhachHangServices>();
builder.Services.AddScoped<IRepository<MNhanVien>, NhanVienRepository>();
builder.Services.AddScoped<INhanVienServices, NhanVienServices>();
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

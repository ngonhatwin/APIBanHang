using APIBanHang.Data;
using APIBanHang.Models;
using APIBanHang.Repository;
using APIBanHang.Services;
using APIBanHang.Key;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using APIBanHang.Filter;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Add filter Global
builder.Services.AddControllers(options =>
{
    options.Filters.AddService<AsyncResourceFilter>();
    options.Filters.AddService<AsyncResultFilter>();
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<XyzContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDB"));
    //có thể sử dụng câu lệnh dưới đây để notracking toàn cục
    //options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});


builder.Services.AddScoped<AsyncResourceFilter>();
builder.Services.AddScoped<AsyncResultFilter>();

builder.Services.AddScoped<IAccountService,AccountServices>();
builder.Services.AddScoped<IDonDatHangService,DonDatHangServices>();
builder.Services.AddScoped<IKhachHangService,KhachHangServices>();
builder.Services.AddScoped<ILoaiHangService,LoaiHangServices>();
builder.Services.AddScoped<IMatHangService,MatHangServices>();
builder.Services.AddScoped<INhaCungCapService,NhaCungCapServices>();
builder.Services.AddScoped<INhanVienService,NhanVienServices>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(MyRepository<>));

//--------
builder.Services.Configure<AppSetting>(builder.Configuration.GetSection("AppSettings"));
//lấy giá trị secretkey
var secretKey = builder.Configuration["AppSettings:SecretKey"];
//chuyển đổi từ string sang mảng byte
//SymmetricSecurityKey, được sử dụng trong JWT,
//yêu cầu secret key ở dạng mảng byte.
var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            //tự cấp token
            ValidateIssuer = false,
            ValidateAudience = false,
            //ký vào token
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),
            ClockSkew = TimeSpan.Zero,
        };
        //cấu hình nhận token từ header
        opt.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                context.Token = context.Request.Headers["Authorization"].FirstOrDefault()?.Replace("Bearer ", "");
                Console.WriteLine($"Đã Nhận token");
                return Task.CompletedTask;
            }
        };
    });

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI BanHang", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});
//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
//})
//            .AddCookie()
//            .AddGoogle(options =>
//            {
//                options.ClientId = "510349039903-s3ih8s9j2caniqhrokunmkq25orsaegu.apps.googleusercontent.com";
//                options.ClientSecret = "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";
//            });
builder.Services.AddAuthorization();
builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(builder =>
    builder
        .WithOrigins("https://wssxmg.csb.app", "https://cq28hs.csb.app") // Thêm tất cả các địa chỉ của ứng dụng React của bạn
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
);
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

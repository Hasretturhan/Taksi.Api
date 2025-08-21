using Taksi.Data;
using Taksi.Data.Repository;
using Taksi.Business.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using System.Linq; // ResolveConflictingActions için gerekli

var builder = WebApplication.CreateBuilder(args);

// DbContext ayarı
builder.Services.AddDbContext<TaksiDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repository ve Service DI ayarları
builder.Services.AddScoped<IPassengerRepository, PassengerRepository>();
builder.Services.AddScoped<PassengerService>();

builder.Services.AddScoped<IDriverRepository, DriverRepository>();
builder.Services.AddScoped<DriverService>();

builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<PaymentService>();

builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<AddressService>();

builder.Services.AddScoped<ITripRepository, TripRepository>();
builder.Services.AddScoped<TripService>();

builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
builder.Services.AddScoped<VehicleService>();

builder.Services.AddScoped<ICouponRepository, CouponRepository>();
builder.Services.AddScoped<CouponService>();

builder.Services.AddScoped<IBonusRepository, BonusRepository>();
builder.Services.AddScoped<BonusService>();

builder.Services.AddScoped<ISupportRequestRepository, SupportRequestRepository>();
builder.Services.AddScoped<SupportRequestService>();

// Controllers (döngüsel referanslara karşı güvenli)
// NOT: Burada AddControllers bir kez çağrılır; aşağıdaki ikinci çağrı kaldırıldı.
builder.Services.AddControllers().AddJsonOptions(o =>
    o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Swagger ve diğer servisler
builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
    c.CustomSchemaIds(t => t.FullName);
    c.MapType<DateOnly>(() => new OpenApiSchema { Type = "string", Format = "date" });
    c.MapType<TimeOnly>(() => new OpenApiSchema { Type = "string", Format = "time" });

    // Sadece teşhis için:
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

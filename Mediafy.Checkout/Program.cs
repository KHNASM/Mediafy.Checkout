using Mediafy.Checkout.Business.Configurations;
using Mediafy.Checkout.Business.Implementation;
using Mediafy.Checkout.Business.Interfaces;
using Mediafy.Checkout.DataAccess.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);


string connectionString = builder.Configuration.GetConnectionString("Default");

builder.Services.Configure<CountriesConfiguration>(builder.Configuration.GetSection(nameof(CountriesConfiguration)));
builder.Services.Configure<ValidationRules>(builder.Configuration.GetSection(nameof(ValidationRules)));
builder.Services.Configure<ExternalApiConfiguration>(builder.Configuration.GetSection(nameof(ExternalApiConfiguration)));

builder.Services.AddDbContext<MediafyInMemoryContext>(opt => opt.UseSqlite(connectionString));

builder.Services.AddHttpClient();

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.TryAddScoped<IOfferHandler, OfferHandler>();
builder.Services.TryAddScoped<IApiGateway, ApiGateway>();

//builder.Services.EnableSensitiveDataLogging();
var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();

app.Run();
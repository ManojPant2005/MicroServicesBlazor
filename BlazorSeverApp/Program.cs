using BlazorSeverApp.Data;
using BlazorSeverApp.Infrastructure.Authentication;
using BlazorSeverApp.Infrastructure;
using BlazorSeverApp.Services.IServices;
using BlazorSeverApp.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor()
    .AddCircuitOptions(options => { options.DetailedErrors = true; });

//added
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();

//builder.Services.AddHttpContextAccessor();

ApplicationConstants.ProductApiUrl = builder.Configuration["ServiceUrls:ProductApiUrl"];
ApplicationConstants.CouponApiUrl = builder.Configuration["ServiceUrls:CouponApiUrl"];
ApplicationConstants.AuthApiUrl = builder.Configuration["ServiceUrls:AuthApiUrl"];
ApplicationConstants.CartApiUrl = builder.Configuration["ServiceUrls:CartApiUrl"];

builder.Services.AddHttpClient();
builder.Services.AddHttpClient<IProductService, ProductService>();
builder.Services.AddHttpClient<ICouponService, CouponService>();
builder.Services.AddHttpClient<IAuthService, AuthServices>();
builder.Services.AddHttpClient<ICartService, CartService>();

builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICouponService, CouponService>();
builder.Services.AddScoped<IAuthService, AuthServices>();
builder.Services.AddScoped<ICartService, CartService>();
//builder.Services.AddScoped<ITokenProviderService, TokenCookieProviderService>();
builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

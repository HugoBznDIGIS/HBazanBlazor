using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using PL.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();

//// CORS
//var httpClientHandler = new HttpClientHandler();
//httpClientHandler.ServerCertificateCustomValidationCallback =
//    (message, cert, chain, errors) => true;

//builder.Services.AddSingleton(new HttpClient(httpClientHandler)
//{
//    BaseAddress = new Uri("http://localhost:5117/api/")
//});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

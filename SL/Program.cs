using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("Policy1",
//        policy =>
//        {
//            policy.WithOrigins("http://localhost:5042", URL de la capa PL "http://localhost:5117/api/paciente/"); URL de la capa SL

//        });
//    options.AddPolicy("AnotherPolicy",
//        policy =>
//        {
//            policy.WithOrigins("http://localhost:5042")  URL de la capa PL
//            .AllowAnyHeader()
//            .AllowAnyMethod();
//        });
//});
//app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

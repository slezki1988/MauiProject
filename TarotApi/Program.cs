/*using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<GradioService>();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()  // разрешает запросы с любого источника
               .AllowAnyMethod()  // разрешает любой HTTP метод
               .AllowAnyHeader(); // разрешает любые заголовки
    });
});
builder.WebHost.UseUrls("http://localhost:5051", "https://localhost:7191");

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

//app.UseHttpsRedirection();

app.UseAuthorization();

// Если ваше приложение использует промежуточное ПО для разработки, включите его здесь, например:
// app.UseDeveloperExceptionPage();

app.UseCors(); // Включение CORS

app.UseRouting();

// app.UseAuthorization(); // Если у вас есть авторизация

app.MapControllers(); // Если вы используете контроллеры
app.Run();
*/
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<GradioService>();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
builder.WebHost.UseUrls("http://localhost:5051");
builder.Services.AddHttpClient<GradioService>(client =>
{
    client.BaseAddress = new Uri("https://dvruette-fabric--dxn4w.hf.space/");
    client.Timeout = TimeSpan.FromSeconds(500);
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();  // Рекомендуется для отладки
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty;  // Это делает Swagger UI стартовой страницей
    });
}

//app.UseHttpsRedirection();

app.UseCors(); // Включение CORS

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();




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
        builder.AllowAnyOrigin()  // ��������� ������� � ������ ���������
               .AllowAnyMethod()  // ��������� ����� HTTP �����
               .AllowAnyHeader(); // ��������� ����� ���������
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

// ���� ���� ���������� ���������� ������������� �� ��� ����������, �������� ��� �����, ��������:
// app.UseDeveloperExceptionPage();

app.UseCors(); // ��������� CORS

app.UseRouting();

// app.UseAuthorization(); // ���� � ��� ���� �����������

app.MapControllers(); // ���� �� ����������� �����������
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
    app.UseDeveloperExceptionPage();  // ������������� ��� �������
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty;  // ��� ������ Swagger UI ��������� ���������
    });
}

//app.UseHttpsRedirection();

app.UseCors(); // ��������� CORS

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();




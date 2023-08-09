using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using StockApp.Application;
using StockApp.Infrastructure;
using StockApp.Infrastructure.Data;
using StockApp.Infrastructure.RabbitMQ;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();


builder.Services.AddCors(options =>
    options.AddDefaultPolicy(policy =>
        policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader())
    );

builder.Services
    .AddApplicationLayer()
    .AddInfrastructureLayer(builder.Configuration);

builder.Services.Configure<RabbitMqConfig>         (builder.Configuration.GetSection("RabbitMqConfig"));

#region Swagger

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    string buildDate = $"build: {File.GetLastWriteTime(Assembly.GetExecutingAssembly().Location).ToShortDateString()}";
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = buildDate,
        Title = "Stock REST API",
        Description = "Описание контроллеров"
    });
    options.EnableAnnotations();
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
    options.IncludeXmlComments(xmlPath);
});

#endregion


var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");
app.UseCors();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<DataContext>();
    //dataContext.Database.EnsureCreated();
    dataContext.Database.Migrate();
}

app.Run();
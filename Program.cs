using System.Runtime.InteropServices.ComTypes;
using System.Text.Json.Serialization;
using B_Analysis_BackEnd.Models;
using B_Analysis_BackEnd.Repository;
using B_Analysis_BackEnd.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<IMatchRepository, MatchRepository>();
builder.Services.AddScoped<IMatchService, MatchService>();

builder.Services.AddScoped<IAnalysisService, AnalysisService>();


builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers().AddJsonOptions(
    options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
builder.Services.AddDbContext<BAnalysisContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQLConnection")));

// TODO: Check the behavior of this call and add variable to enable/disable it
builder.Services.BuildServiceProvider().GetRequiredService<BAnalysisContext>().Database.Migrate();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:4200") 
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpClient("myHttpClient", client => { client.Timeout = TimeSpan.FromMinutes(120); });
builder.Services.AddSwaggerGen();

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseCors();
app.UseAuthorization();

app.MapControllers();
app.Run();
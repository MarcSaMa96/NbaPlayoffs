using Microsoft.EntityFrameworkCore;
using NbaPlayoffs.Domain;
using NbaPlayoffs.Domain.Models;
using NbaPlayoffs.Domain.Repositories.Implementations;
using NbaPlayoffs.Domain.Repositories.Interfaces;
using NbaPlayoffs.Services.Implementations;
using NbaPlayoffs.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<NbaPlayoffContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("NbaPlayoffConnectionString")));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ITeamRecordRepository, TeamRecordRepository>();
builder.Services.AddScoped<IPlayoffGuessHeaderRepository, PlayoffGuessHeaderRepository>();
builder.Services.AddScoped<IFavouriteTeamRepository, FavouriteTeamRepository>();
builder.Services.AddScoped<ITeamServices, TeamServices>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IClasificacionServices, ClasificacionServices>();
builder.Services.AddScoped<IPlayoffServices, PlayoffServices>();
builder.Services.AddScoped<IFavouriteTeamServices, FavouriteTeamServices>();


// Add Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();

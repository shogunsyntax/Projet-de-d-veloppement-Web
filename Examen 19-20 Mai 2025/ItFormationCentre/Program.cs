using Microsoft.EntityFrameworkCore;
using ItFormationCentre.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(); // Ajoutez les contrôleurs
builder.Services.AddRazorPages(); // Ajoutez Razor Pages

// Configuration de la chaîne de connexion
builder.Services.AddDbContext<ItFormationCentreDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.UseStaticFiles(); // Ajoutez cette ligne pour servir les fichiers statiques

// Configurez les points de terminaison
app.MapControllers(); // Ajoutez cette ligne pour mapper les contrôleurs
app.MapRazorPages(); // Ajoutez cette ligne pour mapper les Razor Pages

app.Run();
using api.src.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// TO DO: Agregar CloudinarySettings


string connectionString = Environment.GetEnvironmentVariable("DATABASE_URL") ?? "Data Source=database.db";

// Como no debemos tener credenciales en codigo, el nombre de la base de datos será "Data Source-nombre.db"
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddControllers();


// TO DO: Agregar Repositorys con builder.Srevices.AddScoped

// TO DO: Agregar Identity
// TO DO: Agregar Authentication JWT
// TO DO: Agregar Autorización

// Configurar CORS para permitir cualquier origen (Lo necesita el Frontend)
builder.Services.AddCors();


var app = builder.Build();

// Crea los Scope para la Base de datos
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<DataContext>();

    // Migraciones pendientes
    await context.Database.MigrateAsync();

    DataSeeder.Initialize(services);
}




if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Usa CORS
app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

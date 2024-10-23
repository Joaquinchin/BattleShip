using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Agregamos los controladores
builder.Services.AddControllers();

// Configuración de Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // Configuración básica de Swagger
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Tu API", Version = "v1" });
});

// Servicios personalizados (sin base de datos)
builder.Services.AddScoped<IFileStorageService, FileStorageService>();
builder.Services.AddScoped<IUsuarioService, UsuarioDbService>();
builder.Services.AddScoped<ILibroService, LibroDbService>();
builder.Services.AddScoped<ITemaService, TemaDbService>();

var app = builder.Build();

// Configurar el pipeline de la aplicación
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();



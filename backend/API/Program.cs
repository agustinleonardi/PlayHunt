using F2kProject.Application.Abstractions;
using F2kProject.Application.Services;
using F2kProject.Infrastructure.Mappings;
using F2kProject.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// AutoMapper - Buscar perfiles en Infrastructure y Application
builder.Services.AddAutoMapper(typeof(GameMappingProfile).Assembly);

// Memory Cache
builder.Services.AddMemoryCache();

// Dependency Injection
builder.Services.AddHttpClient<IFreeToGameClient, FreeToGameClient>();
builder.Services.AddScoped<ICacheService, MemoryCacheService>();
builder.Services.AddScoped<IGamesService, GamesService>();

// CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("https://play-hunt-front.netlify.app")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();
app.MapControllers();

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
app.Urls.Add($"http://0.0.0.0:{port}");

app.Run();

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
        policy.AllowAnyOrigin();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();
app.MapControllers();

app.MapFallbackToFile("index.html");

app.Run();

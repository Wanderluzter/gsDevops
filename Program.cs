using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Conexão com banco PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Serviços da API
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddRazorPages();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

// 3. Injeção de dependências – REPOSITORIES
builder.Services.AddScoped<UsuarioGSRepository>();
builder.Services.AddScoped<AlertaRepository>();

// 4. Injeção de dependências – SERVICES
builder.Services.AddScoped<UsuarioGSService>();
builder.Services.AddScoped<AlertaService>();

var app = builder.Build();

// 5. Middleware
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();
app.MapRazorPages();

app.Run();

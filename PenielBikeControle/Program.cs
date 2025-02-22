using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PenielBikeControle.Data;
using PenielBikeControle.Mappers.Clientes;
using PenielBikeControle.Mappers.Funcionarios;
using PenielBikeControle.Mappers.ProdutosCliente;
using PenielBikeControle.Mappers.Vendas;
using PenielBikeControle.Models;
using PenielBikeControle.Repositories;
using PenielBikeControle.Repositories.Iterfaces;

var builder = WebApplication.CreateBuilder(args);

// Configuracao do DbContext
builder.Services.AddDbContext<DataContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    ));


// Configuracao do Identity
builder.Services.AddIdentity<Usuario, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false; 
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1); 
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;
    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedEmail = false;
})
.AddEntityFrameworkStores<DataContext>()
.AddDefaultTokenProviders();


// Configuracao da sessao e autenticacao
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Login";
    options.AccessDeniedPath = "/Account/AccessDenied";
    options.ExpireTimeSpan = TimeSpan.FromDays(5);
    options.SlidingExpiration = true;
});


// Repositories
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IVendaRepository, VendaRepository>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IFuncionarioRepository, FuncionarioReposytory>();
builder.Services.AddScoped<IItemVendaRepository, ItemVendaRepository>();
builder.Services.AddScoped<ITipoProdEstoqRepository, TipoProdEstoqRepository>();
builder.Services.AddScoped<IProdutoEstoqueRepository, ProdutoEstoqueRepository>();
builder.Services.AddScoped<IProdutoClienteRepository, ProdutoClienteRepository>();


// Mappers
builder.Services.AddScoped<FuncionarioMapper>();
builder.Services.AddScoped<FuncionarioMapperConfiguration>();
builder.Services.AddScoped<ClienteMapper>();
builder.Services.AddScoped<ClienteMapperConfiguration>();
builder.Services.AddScoped<ProdutoClienteMapper>();
builder.Services.AddScoped<ProdutoClienteMapperConfiguration>();
builder.Services.AddScoped<VendaMapper>();
builder.Services.AddScoped<VendaMapperConfiguration>();

//Associa protecao contra ataques CSRF (Cross-Site Request Forgery) a todas as requisições HTTP POST, PUT, DELETE ou PATCH.
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");

app.Run();
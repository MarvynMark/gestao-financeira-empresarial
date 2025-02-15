using PenielBikeControle.Data;
using PenielBikeControle.Mappers.Clientes;
using PenielBikeControle.Mappers.Funcionarios;
using PenielBikeControle.Mappers.ProdutosCliente;
using PenielBikeControle.Mappers.Vendas;
using PenielBikeControle.Repositories;
using PenielBikeControle.Repositories.Iterfaces;

var builder = WebApplication.CreateBuilder(args);

// repositories
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IVendaRepository, VendaRepository>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IFuncionarioRepository, FuncionarioReposytory>();
builder.Services.AddScoped<IItemVendaRepository, ItemVendaRepository>();
builder.Services.AddScoped<ITipoProdEstoqRepository, TipoProdEstoqRepository>();
builder.Services.AddScoped<IProdutoEstoqueRepository, ProdutoEstoqueRepository>();
builder.Services.AddScoped<IProdutoClienteRepository, ProdutoClienteRepository>();
builder.Services.AddDbContext<DataContext>();

// mappers
builder.Services.AddScoped<FuncionarioMapper>();
builder.Services.AddScoped<FuncionarioMapperConfiguration>();

builder.Services.AddScoped<ClienteMapper>();
builder.Services.AddScoped<ClienteMapperConfiguration>();

builder.Services.AddScoped<ProdutoClienteMapper>();
builder.Services.AddScoped<ProdutoClienteMapperConfiguration>();

builder.Services.AddScoped<VendaMapper>();
builder.Services.AddScoped<VendaMapperConfiguration>();



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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();

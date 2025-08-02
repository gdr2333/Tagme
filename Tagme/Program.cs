using Microsoft.EntityFrameworkCore;
using Tagme.Components;
using Tagme.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContextFactory<TagContext>();

builder.Services.AddSingleton<IdlotDbService>();

builder.Services.AddScoped<LinkInfo>();

var app = builder.Build();

app.Services.GetService(typeof(IdlotDbService));

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

class IdlotDbService
{
    public IdlotDbService(IDbContextFactory<TagContext> dbFactory)
    {
        using var context = dbFactory.CreateDbContext();
        context.Database.EnsureCreated();
        context.SaveChanges();
    }
}
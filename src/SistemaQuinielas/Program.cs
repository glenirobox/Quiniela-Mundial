using SistemaQuinielas.Pages;

var builder = WebApplication.CreateBuilder(args);

// Registrar Blazor e Interactividad Servidor
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

// Requerido en .NET 9/10 para entregar blazor.web.js y contenido estático
app.MapStaticAssets();

app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
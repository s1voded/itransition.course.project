using PersonalCollection.Application.Extensions;
using PersonalCollection.Domain;
using PersonalCollection.Persistence.Extensions;
using PersonalCollectionWebApp.Extensions;
using PersonalCollectionWebApp.Hubs;
using PersonalCollectionWebApp.Components;
using static PersonalCollection.Domain.Constants;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddPresentationLayer();
builder.Services.AddApplicationLayer(builder.Configuration);
builder.Services.AddPersistenceLayer(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

var supportedCultures = new[] { EN, RU };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(EN)
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);

app.MapControllers();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.MapHub<CommentsHub>(Constants.HubName);

app.Run();

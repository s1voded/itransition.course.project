using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using MudBlazor.Services;
using PersonalCollection.Application.Extensions;
using PersonalCollection.Domain;
using PersonalCollection.Domain.Entities;
using PersonalCollection.Persistence.Extensions;
using PersonalCollectionWebApp.Components;
using PersonalCollectionWebApp.Components.Account;
using PersonalCollectionWebApp.Extensions;
using PersonalCollectionWebApp.Policies.Requirements;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(Constants.PolicyCanManageCollection, policy =>
        policy.AddRequirements(new AllowedManageCollectionRequirement(), new UserNotBlockedRequirement(false)));
    options.AddPolicy(Constants.PolicyAdminOnly, policy =>
        policy.AddRequirements(new IsAdminRequirement()));
    options.AddPolicy(Constants.PolicyUserNotBlocked, policy =>
        policy.AddRequirements(new UserNotBlockedRequirement(false)));
    options.AddPolicy(Constants.PolicyUserNotBlockedOrAnonymous, policy =>
        policy.AddRequirements(new UserNotBlockedRequirement(true)));
});

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

builder.Services.AddApplicationLayer();
builder.Services.AddPersistenceLayer(builder.Configuration);

builder.Services.AddMudServices(x => x.PopoverOptions.ThrowOnDuplicateProvider = false);
builder.Services.AddHandlersServices();

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

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();

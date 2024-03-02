using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using PersonalCollectionWebApp;
using PersonalCollectionWebApp.Components;
using PersonalCollectionWebApp.Components.Account;
using PersonalCollectionWebApp.Data;
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

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

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

builder.Services.AddAutoMapper((typeof(Program)));
builder.Services.AddMudServices(x => x.PopoverOptions.ThrowOnDuplicateProvider = false);
builder.Services.AddRepositories();
builder.Services.AddMyServices();
builder.Services.AddHandlersServices();

var app = builder.Build();

//add default data in db if db empty
//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;
//    await SeedData.InitializeAsync(services);
//}

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

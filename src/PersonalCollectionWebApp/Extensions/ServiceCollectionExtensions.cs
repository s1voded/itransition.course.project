﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using MudBlazor.Services;
using PersonalCollection.Domain.Entities;
using PersonalCollection.Persistence.Contexts;
using PersonalCollectionWebApp.Components.Account;
using PersonalCollectionWebApp.Policies.Handlers;
using PersonalCollectionWebApp.Policies.Requirements;
using static PersonalCollection.Domain.Constants;

namespace PersonalCollectionWebApp.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddPresentationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRazorComponents().AddInteractiveServerComponents();
            services.AddIdentityServices(configuration);
            services.AddAuthorizationWithPolicies();
            services.AddMudServices(x => x.PopoverOptions.ThrowOnDuplicateProvider = false);
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddControllers(); //controller for change culture
        }

        private static void AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCascadingAuthenticationState();
            services.AddScoped<IdentityUserAccessor>();
            services.AddScoped<IdentityRedirectManager>();
            services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = IdentityConstants.ApplicationScheme;
                options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            })
                .AddGoogle(googleOptions =>
                {
                    googleOptions.ClientId = configuration["Authentication:Google:ClientId"];
                    googleOptions.ClientSecret = configuration["Authentication:Google:ClientSecret"];
                })
                .AddIdentityCookies();

            services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddSignInManager()
                .AddDefaultTokenProviders();

            services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();
        }

        private static void AddAuthorizationWithPolicies(this IServiceCollection services)
        {
            services.AddScoped<IAuthorizationHandler, IsCollectionOwnerHandler>();
            services.AddScoped<IAuthorizationHandler, IsAdminHandler>();
            services.AddScoped<IAuthorizationHandler, UserNotBlockedHandler>();

            services.AddAuthorizationBuilder()
                .AddPolicy(PolicyCanManageCollection, policy => policy.AddRequirements(new AllowedManageCollectionRequirement(), new UserNotBlockedRequirement(false)))
                .AddPolicy(PolicyAdminOnly, policy => policy.AddRequirements(new IsAdminRequirement()))
                .AddPolicy(PolicyUserNotBlocked, policy => policy.AddRequirements(new UserNotBlockedRequirement(false)))
                .AddPolicy(PolicyUserNotBlockedOrAnonymous, policy => policy.AddRequirements(new UserNotBlockedRequirement(true)));
        }
    }
}

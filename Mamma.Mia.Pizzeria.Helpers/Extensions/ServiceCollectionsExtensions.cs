﻿using Mamma.Mia.Pizzeria.Domain.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mamma.Mia.Pizzeria.DataAccess.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.IdentityModel.Tokens;

namespace Mamma.Mia.Pizzeria.Helpers.Extensions
{
    public static class ServiceCollectionsExtensions
    {
        public class ConfigBuilder
        {
            public IServiceCollection Services { get; set; }
            public IConfiguration Configuration { get; }
            public IdentityBuilder IdentityBuilder { get; set; }
            public AuthenticationBuilder AuthenticationBuilder { get; set; }

            public ConfigBuilder(IServiceCollection services, IConfiguration configuration)
            {
                Services = services;
                Configuration = configuration;
            }
        }

        public static ConfigBuilder AddPostgreSqlDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("ConnectionString").Value;
            services.AddDbContext<MammaMiaPizzeriaDbContext>(options =>
            options.UseNpgsql(connectionString));

            return new(services, configuration);
        }

        public static ConfigBuilder AddSwager(this ConfigBuilder builder)
        {
            builder.Services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "Standard Authorisation header using the Bearer scheme, e.g" +
                    "\bearer {token} \"",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.OperationFilter<SecurityRequirementsOperationFilter>();
            });
            return builder;
        }

        public static ConfigBuilder AddIdentity(this ConfigBuilder builder)
        {
            builder.IdentityBuilder = builder.Services.AddIdentityCore<User>(option =>
            {
                option.SignIn.RequireConfirmedAccount = true;
            })
            .AddEntityFrameworkStores<MammaMiaPizzeriaDbContext>()
            .AddDefaultTokenProviders();
            return builder;
        }

        public static ConfigBuilder AddCors(this ConfigBuilder builder)
        {
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CORSPolicy", builder => builder.AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
                .SetIsOriginAllowed((hosts) => true));
            });
            return builder;
        }

        public static ConfigBuilder AddAuthentication(this ConfigBuilder builder)
        {
            builder.AuthenticationBuilder = builder.Services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            });
            return builder;
        }

        public static ConfigBuilder AddJWT(this ConfigBuilder builder, IConfiguration configuration)
        {
            var Token = configuration.GetSection("Token").Value;
            builder.AuthenticationBuilder.AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.
                    GetBytes(Token)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });
            return builder;
        }

    }
}

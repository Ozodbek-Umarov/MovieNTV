using Microsoft.OpenApi.Models;

namespace MovieNTV.Configurations;

public static class SwaggerConfiguration
{
    public static void ConfigurationSwaggerAuthorize(this IServiceCollection services,
        IConfiguration config)
    {
        services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Description =
                "Kwt Authorization header using the Baerer scheme. " +
                "Exemple: \"Authoriztion: Bearer {token}\"",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] {}
                }
            });
        });
    }
}

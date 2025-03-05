using OperationOOP.Api.Endpoints;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace OperationOOP.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //Configure services
            builder.Services.AddAuthorization();

            // builder.Services.AddAuthorization();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.CustomSchemaIds(type => type.FullName?.Replace('+', '.'));
                options.InferSecuritySchemes();
                options.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Title = "Plant Management API",
                        Version = "v1",
                        Description = "API for managing and keep journals for your beloved plants.",
                    }
                );
                options.TagActionsBy(api => new[] { api.GroupName });
            });

            builder.Services.AddSingleton<IDatabase, Database>();
            builder.Services.AddSingleton<IPlantService, PlantService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapEndpoints<Program>();

            app.Run();
        }
    }
}

using OperationOOP.Api.Endpoints;

namespace OperationOOP.Api
{
    public class Program
    {
        public record Address(string Street, string City);

        public record Person(string Name, Address HomeAddress);

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthorization();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.CustomSchemaIds(type => type.FullName?.Replace('+', '.'));
                options.InferSecuritySchemes();
            });

            builder.Services.AddSingleton<IDatabase, Database>();

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


using ButterflyCalculatorAPI.Endpoints;
using Microsoft.OpenApi.Models;

namespace ButterflyCalculatorAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(setup => setup.SwaggerDoc("v1", new OpenApiInfo()
            {
                Description = "Minimal Api for simple arithmetic calculations.",
                Title = "Calculator Api",
                Version = "v1",
                Contact = new OpenApiContact()
                {
                    Name = "Lachlan Wilson",
                    Email = "lachlanjwilson@hotmail.com"
                }
            }));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapAddEndpoint();
            app.MapSubtractEndpoint();
            app.MapMultiplyEndpoint();
            app.MapDivideEndpoint();

            app.Run();
        }
    }
}

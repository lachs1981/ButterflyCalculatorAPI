using ButterflyCalculatorAPI.Helpers;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ButterflyCalculatorAPI.Tests")]

namespace ButterflyCalculatorAPI.Endpoints
{
    public static class AddEndpoint
    {
        public static void MapAddEndpoint(this WebApplication app)
        {
            app.MapGet("/add", (HttpContext context) =>
            {
                if (!TryGetOperands(context, out var op1, out var op2, out var errorMessage))
                    return Results.BadRequest(errorMessage);

                return Results.Ok(new { Operand1 = op1, Operand2 = op2, Operation = "add", Result = Add(op1, op2) });
            })
            .WithName("Add")
            .WithOpenApi(operation =>
            {
                OpenApiHelper.TackOnOperationDetails(operation, "Addition Endpoint", "Adds operands 1 and 2 and returns the result.", 1, 2, 3);
                return operation;
            });
        }

        private static bool TryGetOperands(HttpContext context, out double op1, out double op2, out string errorMessage)
        {
            return CommonEndpointHelper.TryGetOperands(context, out op1, out op2, out errorMessage);
        }

        internal static double Add(double op1, double op2)
        {
            return op1 + op2;
        }
    }
}

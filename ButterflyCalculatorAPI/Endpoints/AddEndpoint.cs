using Microsoft.OpenApi.Any;
using System.Reflection.Metadata;

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

                return Results.Ok(new { Operand1 = op1, Operand2 = op2, Operation = "add", Result = op1 + op2 });
            })
            .WithName("Add")
            .WithOpenApi(operation => new(operation)
            {
                Summary = "Adds operands 1 and 2 and returns the result.",
                Description = "This is a description"
            });
        }

        private static bool TryGetOperands(HttpContext context, out double op1, out double op2, out string errorMessage)
        {
            return CommonEndpointHelper.TryGetOperands(context, out op1, out op2, out errorMessage);
        }
    }
}

using ButterflyCalculatorAPI.Helpers;
using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ButterflyCalculatorAPI.Tests")]

namespace ButterflyCalculatorAPI.Endpoints
{
    public static class DivideEndpoint
    {
        public static void MapDivideEndpoint(this WebApplication app)
        {
            app.MapGet("/divide", (HttpContext context) =>
            {
                if (!TryGetOperands(context, out var op1, out var op2, out var errorMessage))
                    return Results.BadRequest(errorMessage);

                if (op2 == 0)
                    return Results.BadRequest("Division by zero is not allowed.");

                return Results.Ok(new { Operand1 = op1, Operand2 = op2, Operation = "divide", Result = Divide(op1, op2) });
            })
            .WithName("Divide")
            .WithOpenApi(operation =>
            {
                OpenApiHelper.TackOnOperationDetails(operation, "Division Endpoint", "Divides operand 1 by 2 and returns the result.", 6, 2, 3);
                return operation;
            });
        }

        private static bool TryGetOperands(HttpContext context, out double op1, out double op2, out string errorMessage)
        {
            return CommonEndpointHelper.TryGetOperands(context, out op1, out op2, out errorMessage);
        }

        internal static double Divide(double op1, double op2)
        {
            return op1 / op2;
        }
    }
}

using ButterflyCalculatorAPI.Helpers;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ButterflyCalculatorAPI.Tests")]

namespace ButterflyCalculatorAPI.Endpoints
{
    public static class MultiplyEndpoint
    {
        public static void MapMultiplyEndpoint(this WebApplication app)
        {
            app.MapGet("/multiply", (HttpContext context) =>
            {
                if (!TryGetOperands(context, out var op1, out var op2, out var errorMessage))
                    return Results.BadRequest(errorMessage);

                return Results.Ok(new { Operand1 = op1, Operand2 = op2, Operation = "multiply", Result = Multiply(op1, op2) });
            })
            .WithName("Multiply")
            .WithOpenApi(operation =>
            {
                OpenApiHelper.TackOnOperationDetails(operation, "Multiplication Endpoint", "Multiplies operands 1 and 2 and returns the result.", 2, 2, 4);
                return operation;
            });
        }

        private static bool TryGetOperands(HttpContext context, out double op1, out double op2, out string errorMessage)
        {
            return CommonEndpointHelper.TryGetOperands(context, out op1, out op2, out errorMessage);
        }

        internal static double Multiply(double op1, double op2)
        {
            return op1 * op2;
        }
    }
}

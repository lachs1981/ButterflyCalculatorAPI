namespace ButterflyCalculatorAPI.Endpoints
{
    public static class SubtractEndpoint
    {
        public static void MapSubtractEndpoint(this WebApplication app)
        {
            app.MapGet("/subtract", (HttpContext context) =>
            {
                if (!TryGetOperands(context, out var op1, out var op2, out var errorMessage))
                    return Results.BadRequest(errorMessage);

                return Results.Ok(new { Operand1 = op1, Operand2 = op2, Operation = "subtract", Result = op1 - op2 });
            });
        }

        private static bool TryGetOperands(HttpContext context, out double op1, out double op2, out string errorMessage)
        {
            return CommonEndpointHelper.TryGetOperands(context, out op1, out op2, out errorMessage);
        }
    }
}

namespace ButterflyCalculatorAPI.Endpoints
{
    public static class CommonEndpointHelper
    {
        public static bool TryGetOperands(HttpContext context, out double op1, out double op2, out string errorMessage)
        {
            op1 = 0;
            op2 = 0;
            errorMessage = string.Empty;

            if (!context.Request.Query.TryGetValue("op1", out var op1Value) ||
                !context.Request.Query.TryGetValue("op2", out var op2Value))
            {
                errorMessage = "Missing query parameters. Provide op1 and op2.";
                return false;
            }

            if (!double.TryParse(op1Value, out op1) || !double.TryParse(op2Value, out op2))
            {
                errorMessage = "Invalid operands. Ensure op1 and op2 are numbers.";
                return false;
            }

            return true;
        }
    }
}

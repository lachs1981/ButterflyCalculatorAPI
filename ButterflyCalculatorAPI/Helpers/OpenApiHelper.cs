using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace ButterflyCalculatorAPI.Helpers
{
    public class OpenApiHelper
    {
        public static void TackOnOperationDetails(OpenApiOperation operation, string summary, string description, double exampleOperand1, double exampleOperand2, double exampleResult)
        {
            operation.Summary = summary;
            operation.Description = description;
            operation.Parameters = new List<OpenApiParameter>
                {
                    new OpenApiParameter
                    {
                        Name = "op1",
                        In = ParameterLocation.Query,
                        Required = true,
                        Description = "The first operand.",
                        Schema = new OpenApiSchema { Type = "number" }
                    },
                    new OpenApiParameter
                    {
                        Name = "op2",
                        In = ParameterLocation.Query,
                        Required = true,
                        Description = "The second operand.",
                        Schema = new OpenApiSchema { Type = "number" }
                    }
                };
            operation.Responses["200"] = new OpenApiResponse
            {
                Description = "OK",
                Content = new Dictionary<string, OpenApiMediaType>
                    {
                        {
                            "application/json",
                            new OpenApiMediaType
                            {
                                Schema = new OpenApiSchema
                                {
                                    Type = "object",
                                    Properties = new Dictionary<string, OpenApiSchema>
                                    {
                                        { "Operand1", new OpenApiSchema { Type = "number" } },
                                        { "Operand2", new OpenApiSchema { Type = "number" } },
                                        { "Operation", new OpenApiSchema { Type = "string" } },
                                        { "Result", new OpenApiSchema { Type = "number" } }
                                    }
                                },
                                Example = new OpenApiObject
                                {
                                    ["Operand1"] = new OpenApiDouble(exampleOperand1),
                                    ["Operand2"] = new OpenApiDouble(exampleOperand2),
                                    ["Operation"] = new OpenApiString(operation.OperationId),
                                    ["Result"] = new OpenApiDouble(exampleResult)
                                }
                            }
                        }
                    }
            };
            operation.Responses["400"] = new OpenApiResponse
            {
                Description = "Bad request due to missing or invalid parameters."
            };
        }
    }
}

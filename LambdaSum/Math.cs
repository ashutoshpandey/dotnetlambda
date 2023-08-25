using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]
namespace LambdaSum
{
    public class Data
    {
        public int First { get; set; }
        public int Second { get; set; }
    }

    public class Math
    {
        public APIGatewayProxyResponse Add(Data data, ILambdaContext context)
        {
            var response = new APIGatewayProxyResponse()
            {
                Headers = new Dictionary<string, string>()
                {
                    { "Access-Control-Allow-Origin", "*" },
                    { "Access-Control-Allow-Headers", "*" },
                    { "Access-Control-Allow-Methods", "OPTIONS,POST" }
                }
            };

            response.Body = "Sum = " + (data.First + data.Second);

            return response;
        }
    }
}
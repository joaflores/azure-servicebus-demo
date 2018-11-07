
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.ServiceBus;
using System.Text;

namespace FunctionMsgSender
{
    public static class MessageSender
    {
        const string ServiceBusConnectionString = "Endpoint=sb://midemo.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=s9qJYjRBeLarxAMeNPhQ3B3J/sTHpZks2h+kV8n40co=";
        const string TopicName = "topicdemo1";
        static ITopicClient topicClient;

        [FunctionName("SendMessage")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)]HttpRequest req, ILogger log)
        {
            //log.LogInformation("C# HTTP trigger function processed a request.");

           
            string messageException = "";
            bool isOk;

            string msg = await new StreamReader(req.Body).ReadToEndAsync();

            topicClient = new TopicClient(ServiceBusConnectionString, TopicName);

            //crear mensaje
            var message = new Message(Encoding.UTF8.GetBytes(msg));

            try
            {
                //enviar mensaje
                await topicClient.SendAsync(message);
                isOk = true;
            }
            catch (Exception ex)
            {
                isOk = false;
                messageException = ex.Message;
            }
            finally
            {
                //cerrar cliente
                await topicClient.CloseAsync();
            }

            return isOk != false
                ? (ActionResult)new OkObjectResult("Ok")
                : new BadRequestObjectResult(messageException);
        }
    }
}

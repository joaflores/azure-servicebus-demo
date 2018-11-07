using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace FunctionMsgReceiver
{
    public static class MessageReceiver
    {
        [FunctionName("ReceiveMessage")]
        public static void Run(
            [ServiceBusTrigger("topicdemo1", "subs2", Connection = "ServiceBus_Connection")]string mySbMsg,
            [Blob("data/MessageStore.txt", FileAccess.ReadWrite, Connection = "Blob_Connection")] TextWriter data,
            ILogger log){
            log.LogInformation($"C# ServiceBus topic trigger function processed message: {mySbMsg}");
           
            try
            {
                data.WriteLine(mySbMsg);
            }
            catch(Exception e)
            {
                log.LogInformation(e.InnerException.Message);
            }
            finally
            {
                data.Close();
            }
        }
    }
}

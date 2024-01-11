using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomMessageBus
{
    internal class MessageBus : IMessageBus
    {
        private readonly string connectionString = "Endpoint=sb://learnmessaging.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=1c1QcOReJd74M+wmq9Q++ae9iiqfN33LU+ASbHpFfiM=";
        public async Task PublishMessage(object message, string Topic_Queue_Name)
        {
            var client = new ServiceBusClient(connectionString);

            ServiceBusSender sender = client.CreateSender(Topic_Queue_Name);
            var body = JsonConvert.SerializeObject(message);

            ServiceBusMessage theMessage = new ServiceBusMessage(Encoding.UTF8.GetBytes(body))
            {
                CorrelationId = Guid.NewGuid().ToString(),
            };

            //send the message 
            await sender.SendMessageAsync(theMessage);

            //free the Resources/Clean uP
            await sender.DisposeAsync();
        }
    }
}

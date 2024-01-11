
using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using MailKit;
using Email.Models.Dtos;
using Email.Services;
using MailService = Email.Services.MailService;

namespace Email.Messaging
{
    public class AzureServiceBusConsumer : IAzureServiceBusConsumer
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        private readonly string _queueName;
        private readonly ServiceBusProcessor _emailProcessor;
        private readonly ServiceBusProcessor _orderProcessor;
        private readonly MailService _mailService;
        private readonly EmailsService _email;

        public AzureServiceBusConsumer(IConfiguration configuration)
        {
            _configuration = configuration;
            //_connectionString = _configuration.GetValue<string>("AzureConnectionString");
            _connectionString = _configuration.GetSection("AzureServices:AzureConnectionString").Value;
            //_queueName = _configuration.GetValue<string>("QueueAndTopics:registerQueue");
            _queueName = _configuration.GetSection("AzureServices:QueueAndTopics:registerQueue").Value;

            var client = new ServiceBusClient(_connectionString);
            _emailProcessor = client.CreateProcessor(_queueName);


        }

        public async Task Start()
        {
            _emailProcessor.ProcessMessageAsync += OnRegisterUser;
            _emailProcessor.ProcessErrorAsync += ErrorHandler;
            await _emailProcessor.StartProcessingAsync();

        }

        public async Task Stop()
        {
            await _emailProcessor.StopProcessingAsync();
            await _emailProcessor.DisposeAsync();
        }

        private Task ErrorHandler(ProcessErrorEventArgs args)
        {
            // send an email to admin
            return Task.CompletedTask;
        }

        private async Task OnRegisterUser(ProcessMessageEventArgs arg)
        {
            var message = arg.Message;
            var body = Encoding.UTF8.GetString(message.Body);
            var user = JsonConvert.DeserializeObject<UserMessageDto>(body);

            try
            { 
                await arg.CompleteMessageAsync(arg.Message);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

namespace StockApp.Infrastructure.RabbitMQ
{
    public class RabbitMqConfig
    {
        public string Hostname { get; set; }
        
        public int Port { get; set; }

        public string Exchange { get; set; }
        
        public string QueueName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}

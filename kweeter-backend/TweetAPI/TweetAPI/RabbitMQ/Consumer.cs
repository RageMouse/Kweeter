using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace TweetAPI.RabbitMQ
{
    public class Consumer : BackgroundService
    {
        private IConnection _connection;
        private IModel _channel;

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // when the service is stopping
            // dispose these references
            // to prevent leaks
            if (stoppingToken.IsCancellationRequested)
            {
                _channel.Dispose();
                _connection.Dispose();
                return Task.CompletedTask;
            }
            string _url = "amqps://gxqclfxu:tRmJiShnFDlE8lIl6lj0S9jpYw23HZlZ@rattlesnake.rmq.cloudamqp.com/gxqclfxu";
            // create a connection and open a channel, dispose them when done
            var factory = new ConnectionFactory
            {
                Uri = new Uri(_url)
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            // ensure that the queue exists before we access it
            var queueName = "tweetQueue";
            bool durable = false;
            bool exclusive = false;
            bool autoDelete = true;

            _channel.QueueDeclare(queueName, durable, exclusive, autoDelete, null);

            var consumer = new EventingBasicConsumer(_channel);

            // add the message receive event
            consumer.Received += (model, deliveryEventArgs) =>
            {
                var body = deliveryEventArgs.Body.ToArray();
                // convert the message back from byte[] to a string
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine("** Received message: {0} by Consumer thread **", message);
                // ack the message, ie. confirm that we have processed it
                // otherwise it will be requeued a bit later
                _channel.BasicAck(deliveryEventArgs.DeliveryTag, false);
            };

            // start consuming
            _ = _channel.BasicConsume(consumer, queueName);
            return Task.CompletedTask;
        }
    }
}

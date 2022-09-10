using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace RabbitMQClient
{
    class Receiver
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            dynamic body;
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare("BasicTest", false, false, false, null);
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine("received a message:{0}", message);
                };
                channel.BasicConsume("BasicTest", true, consumer);

                Console.ReadLine();
             
             
            }
        }
    }
}

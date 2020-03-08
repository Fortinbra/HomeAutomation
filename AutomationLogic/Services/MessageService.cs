﻿using BecauseImClever.HomeAutomation.Abstractions;
using RabbitMQ.Client;
using System;
using System.Text;

namespace BecauseImClever.HomeAutomation.AutomationLogic.Services
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Minor Code Smell", "S1450:Private fields only used as local variables in methods should become local variables", Justification = "<Pending>")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1303:Do not pass literals as localized parameters", Justification = "<Pending>")]
    public class MessageService : IMessageService
    {
        private readonly ConnectionFactory _factory;
        private readonly IConnection _conn;
        readonly IModel _channel;

        public MessageService()
        {
            Console.WriteLine("About to write to rabbitMQ");
            _factory = new ConnectionFactory() { HostName = "localhost", Port = 5672, UserName = "guest", Password = "guest" };
            _conn = _factory.CreateConnection();
            _channel = _conn.CreateModel();
            _channel.QueueDeclare(queue: "hello",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);
        }

        public bool Enqueue(string message)
        {
            var body = Encoding.UTF8.GetBytes("Server Processed " + message);
            _channel.BasicPublish(exchange: "", routingKey: "hello",
                basicProperties: null,
                body: body);
            Console.WriteLine(" [x] Published {0} to RabbitMQ", message);
            return true;
        }
    }
}
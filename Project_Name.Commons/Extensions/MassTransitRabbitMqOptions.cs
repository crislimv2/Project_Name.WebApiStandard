namespace Project_Name.Commons.Extensions
{
    public class MassTransitRabbitMqOptions
    {
        public bool UseRabbitMQ { set; get; }

        public string Host { set; get; } = "localhost";

        public string Username { set; get; } = "guest";

        public string Password { set; get; } = "guest";
    }
}

﻿namespace TechChallenge.Hackthon.Infrastructure.Settings;

public record RabbitMqOptions
{
    public const string AppSettingsSection = "RabbitMqSettings";

    public string Host { get; set; } = string.Empty;
    public string VirtualHost { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string QueueName { get; set; } = string.Empty;
}

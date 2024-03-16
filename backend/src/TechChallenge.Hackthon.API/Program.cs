using TechChallenge.Hackthon.Application.Settings;
using TechChallenge.Hackthon.Infrastructure.Settings;

var builder = WebApplication.CreateBuilder(args);

var rabbitMqOptions = new RabbitMqOptions();

builder.Configuration
    .GetSection(RabbitMqOptions.AppSettingsSection)
    .Bind(rabbitMqOptions);

builder.Services.AddMongoDb(builder.Configuration);
builder.Services.AddGateways();
builder.Services.AddServices();
builder.Services.AddConsumers(rabbitMqOptions);
builder.Services.AddUseCases();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

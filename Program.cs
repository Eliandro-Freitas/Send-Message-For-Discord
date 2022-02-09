using JNogueira.Discord.Webhook.Client;
using JNogueira.Logger.Discord;
using LogandoNoDiscord;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

var configurationSection = app.Configuration.GetSection("DiscordWebhookUrl").Value;
using (var scope = app.Services.CreateScope())
{
    var httpContext = scope.ServiceProvider.GetRequiredService<IHttpContextAccessor>();
    var loggerFactory = scope.ServiceProvider.GetRequiredService<ILoggerFactory>();
    var discordLoggerOptions = new DiscordLoggerOptions(configurationSection)
    {
        ApplicationName = "Connecting in Discord...",
        EnvironmentName = app.Environment.EnvironmentName,
        UserName = "BotMessage",
    };
    loggerFactory.AddDiscord(discordLoggerOptions, httpContext);
}

var discordClient = new DiscordWebhookClient(configurationSection);
var message = new ConfigureDiscordMessage().Message();
await discordClient.SendToDiscord(message);
app.Run();
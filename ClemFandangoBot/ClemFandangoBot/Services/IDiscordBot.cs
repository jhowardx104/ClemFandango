namespace ClemFandangoBot.Services;

public interface IDiscordBot
{
    Task ConnectAsync();
    Task DisconnectAsync();
    Task SendMessageAsync(string message);
    Task ProcessMessageAsync(string message);
}
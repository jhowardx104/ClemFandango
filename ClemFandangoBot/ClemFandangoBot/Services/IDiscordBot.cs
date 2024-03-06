using Discord;
using Discord.WebSocket;

namespace ClemFandangoBot.Services;

public interface IDiscordBot
{
    Task LogAsync(LogMessage message);
    Task ReadyAsync();
    Task MessageReceivedAsync(SocketMessage message);
    Task InstallCommandsAsync();
}
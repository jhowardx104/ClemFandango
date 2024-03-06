using Discord;
using Discord.WebSocket;

namespace ClemFandangoBot.Services;

public interface IDiscordBot: IDisposable
{
    Task LogAsync(LogMessage message);
    Task ReadyAsync();
    Task SlashCommandHandler(SocketSlashCommand command);
}
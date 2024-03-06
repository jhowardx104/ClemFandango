using Discord.Interactions;

namespace ClemFandangoBot.Services.Commands;

public class JokeModule: InteractionModuleBase
{
    [SlashCommand("whoami", "Find out who this bot is.")]
    public async Task WhoIsThat()
    {
        await RespondAsync("Hello, this is Clem Fandango. Can you hear me?");
    }
}
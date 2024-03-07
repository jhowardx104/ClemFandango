using Discord.Interactions;

namespace ClemFandangoBot.Services.Commands;

public class DestinyModule: InteractionModuleBase
{
    [SlashCommand("nightfall", "Returns details about the current nightfall.")]
    public async Task Nightfall()
    {
        await RespondAsync("The current nightfall is The Devils' Lair. The modifiers are: Arach-NO!, Overload, and Champions: Mob.");
    }
}
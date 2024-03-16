using Discord;
using Discord.Interactions;

namespace ClemFandangoBot.Services.Commands;

public class JokeModule: InteractionModuleBase
{
    private static int BadLuckCounter = 0;
    private readonly List<string> _insults = new()
    {
        "Try again later, Power Bottom.",
        "There are guns other than Osteo Striga.",
        "Did you know that Hunters are one of three classes available in the game, Destiny 2?",
        "Stop helping me."
    };
    
    [SlashCommand("whoami", "Find out who this bot is.")]
    public async Task WhoIsThat()
    {
        if (Context.User.Username == "invisibleninja92" 
            || Context.User.Username == "jkmstr101"
            || Context.User.Username == "its_eso")
        {
            await BuildRandomWhoIsThat();
            BadLuckCounter++;
            return;
        }

        if (BadLuckCounter > 6)
        {
            await SendFUUUUUU();
            return;
        }
        
        await RespondAsync($"Hello {Context.User.Username}, this is Clem Fandango. Can you hear me?");
        BadLuckCounter++;
    }

    private async Task BuildRandomWhoIsThat()
    {
        var rand = new Random().Next(0, _insults.Count);

        if (rand == _insults.Count || BadLuckCounter > 6)
        {
            await SendFUUUUUU();
        }
        else
        {
            await RespondAsync(_insults[rand]);
        }
    }

    private async Task SendFUUUUUU()
    {
        var embBuilder = new EmbedBuilder()
            .WithImageUrl("https://i.makeagif.com/media/2-03-2021/925pfm.gif")
            .Build();
        
        await RespondAsync(embeds: new [] { embBuilder });
        BadLuckCounter = 0;
    }
}
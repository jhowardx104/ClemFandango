using Discord.Interactions;

namespace ClemFandangoBot.Services.Commands;

public class JokeModule: InteractionModuleBase
{
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
            return;
        }
        
        await RespondAsync($"Hello {Context.User.Username}, this is Clem Fandango. Can you hear me?");
    }

    private async Task BuildRandomWhoIsThat()
    {
        await RespondAsync(GetRandomInsult());
    }

    private string GetRandomInsult()
    {
        var rand = new Random().Next(0, _insults.Count - 1);
        return _insults[rand];
    }
    
    
}
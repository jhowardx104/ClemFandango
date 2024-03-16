using ClemFandangoBot.Services.Commands.Data;
using Discord;
using Discord.Interactions;

namespace ClemFandangoBot.Services.Commands;

public class JokeModule: InteractionModuleBase
{
    private static int BadLuckCounter = 0;
    
    private readonly Dictionary<string, List<string>> _insults = Dictionaries.InsultDictionary;
    
    [SlashCommand("whoami", "Find out who this bot is.")]
    public async Task WhoIsThat()
    {
        if (_insults.ContainsKey(Context.User.Username))
        {
            await BuildRandomWhoIsThat(Context.User.Username);
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
    
    [SlashCommand("fuuuuuuuuuuu", "Frustration.")]
    public async Task FUUUUUUUUUU()
    {
        await SendFUUUUUU();
    }

    [SlashCommand("insult", "Insult someone.")]
    public async Task Insult(IUser user)
    {
        if (_insults.ContainsKey(user.Username))
        {
            await BuildRandomWhoIsThat(user.Username, true, user);
            BadLuckCounter++;
            return;
        }

        await RespondAsync($"I don't know who {user.Mention} is, but I'm sure they're horrible.");
        BadLuckCounter++;
    }

    private async Task BuildRandomWhoIsThat(string username, bool isInsult = false, IUser? user = null)
    {
        var rand = new Random().Next(0, _insults[username].Count);

        if (rand == _insults[username].Count || BadLuckCounter > 6)
        {
            await SendFUUUUUU();
        }
        else
        {
            var insultMessage = _insults[username][rand];
            if (isInsult)
            {
                insultMessage = $"{user!.Mention}, {insultMessage}";
            }
            await RespondAsync(insultMessage);
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
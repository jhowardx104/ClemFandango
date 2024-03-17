using ClemFandangoBot.Services.Commands.Data;
using Discord.Interactions;

namespace ClemFandangoBot.Services.Commands;

public class DestinyModule: InteractionModuleBase
{
    private readonly Dictionary<Dictionaries.Nightfalls, string> _nightfallSummaries = Dictionaries.NightfallSummaries;
    private readonly Dictionary<Dictionaries.ChampionTypes, string> _championSummaries = Dictionaries.ChampionTypeSummaries;
    
    [SlashCommand("nightfall", "Returns details about the requested nightfall.")]
    public async Task Nightfall(Dictionaries.Nightfalls nightfall)
    {
        await RespondAsync(_nightfallSummaries[nightfall]);
    }
    
    [SlashCommand("champions", "Returns details about the requested champion type.")]
    public async Task Champions(Dictionaries.ChampionTypes championType)
    {
        await RespondAsync(_championSummaries[championType]);
    }
}
using System.Text.RegularExpressions;
using Discord.Interactions;

namespace ClemFandangoBot.Services.Commands;

public class DiceModule: InteractionModuleBase
{
    const string DiceRollPattern = @"^\d+d\d+$";
    const string DiceRollWithModifierPattern = @"^\d+d\d+([+-x/]\d+)?$";
    
    [SlashCommand("coin-flip", "Flip a coin.")]
    public async Task CoinFlip()
    {
        var random = new Random();
        var result = random.Next(0, 2) == 0 ? "Heads" : "Tails";
        await RespondAsync($"You flipped a coin! The result is {result}.");
    }
    
    [SlashCommand("roll", "Roll some dice.")]
    public async Task RollDice(string diceRoll)
    {
        diceRoll = diceRoll.Replace(" ", "");
        if (!Regex.IsMatch(diceRoll, DiceRollWithModifierPattern))
        {
            await RespondAsync("Invalid dice roll format. Please use the format `1d20` or `1d20+5`.");
            return;
        }

        var operationIndex = diceRoll.IndexOfAny(new [] { '+', '-', 'x', '/' });

        var operation = "";
        var modifier = "";
        if(operationIndex != -1)
        {
            operation = diceRoll[operationIndex].ToString();
            modifier = diceRoll.Substring(operationIndex + 1);
        }
        else
        {
            operationIndex = diceRoll.Length;
        }
        
        var dice = diceRoll.Substring(0, operationIndex);
        var diceParts = dice.Split('d');
        var numberOfDice = int.Parse(diceParts[0]);
        var diceSize = int.Parse(diceParts[1]);
        var diceAverage = (diceSize + 1) * 0.5 * numberOfDice;
        
        var diceRolls = new List<int>();
        var random = new Random();
        for (var i = 0; i < numberOfDice; i++)
        {
            diceRolls.Add(random.Next(1, diceSize + 1));
        }

        var result = operation switch
        {
            "+" => diceRolls.Sum() + int.Parse(modifier),
            "-" => diceRolls.Sum() - int.Parse(modifier),
            "x" => diceRolls.Sum() * int.Parse(modifier),
            "/" => diceRolls.Sum() / int.Parse(modifier),
            _ => diceRolls.Sum()
        };

        await RespondAsync($"You rolled {diceRoll} (Avg. {diceAverage})! The result is {result} (Rolls: {String.Join(",", diceRolls)}).");
    }
    
    [SlashCommand("dice-average", "Get the average roll for a given dice.")]
    public async Task DiceAverage(string diceRoll)
    {
        diceRoll = diceRoll.Replace(" ", "");
        if (!Regex.IsMatch(diceRoll, DiceRollPattern))
        {
            await RespondAsync("Invalid dice roll format. Please use the format `1d20`.");
            return;
        }

        var diceParts = diceRoll.Split('d');
        var numberOfDice = int.Parse(diceParts[0]);
        var diceSize = int.Parse(diceParts[1]);
        var diceAverage = (diceSize + 1) * 0.5 * numberOfDice;
        
        await RespondAsync($"The average roll for {diceRoll} is {diceAverage}.");
    }
}
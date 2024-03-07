﻿using System.Text.RegularExpressions;
using Discord.Interactions;

namespace ClemFandangoBot.Services.Commands;

public class DiceModule: InteractionModuleBase
{
    const string DiceRollPattern = @"^\d+d\d+([+-x/]\d+)?$";
    
    [SlashCommand("roll", "Roll some dice.")]
    public async Task RollDice(string diceRoll)
    {
        if (!Regex.IsMatch(diceRoll, DiceRollPattern))
        {
            await RespondAsync("Invalid dice roll format. Please use the format `1d20` or `1d20+5`.");
            return;
        }
        
        //Split the dice roll into the dice roll (ex. 1d20) and the modifier (ex. +/-/x/÷ 5)
        diceRoll = diceRoll.Replace(" ", "");
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

        await RespondAsync($"You rolled {diceRoll}! The result is {result} (Rolls: {String.Join(",", diceRolls)}).");
    }
}
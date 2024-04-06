using Discord.Interactions;

namespace ClemFandangoBot.Services.Commands.Data;

public static class Dictionaries
{
    public static readonly Dictionary<string, List<string>> InsultDictionary = new() 
    {
        { 
            "invisibleninja92", 
            new List<string>
            {
                "Try again later, Power Bottom.",
                "There are guns other than Osteo Striga.",
                "Did you know that Hunters are one of three classes available in the game Destiny 2?",
                "Stop helping me.",
                "Yeah, but what's your Mobility?",
                "Need a healing grenade?",
                "Sick Blade Barrage. Do it again.",
                "Twinks are ruining my life.",
                "Double Primary? In a GM? *Groundbreaking.*"
            } 
        },
        {
            "jkmstr101", 
            new List<string>
            {
                "Bit past your bed time, eh?",
                "No, ociffer, it's, \"Hi, how are you?\"",
                "Ghost pushing you off the chair, or are you just bad?",
                "Yeah, sometimes I have to walk my dogs to not call these chuckle fucks out, too."
            }
        },
        {
            "its_eso", 
            new List<string>
            {
                "You're a Titan main.", 
                "You're a Power Bottom.",
                "8 o'Clock, time for meds."
            }
        },
        {
            "theconcussed",
            new List<string>
            {
                "We have a two gummy limit for a reason... (It's you. You're the reason.)",
                "No, ociffer, it's, \"Hi, how are you?\"",
                "What's that whip-cracking sound?",
                "Which cat \"turned off your pc\" this time?",
                "GG! Go rinse off."
            }
        },
        {
            "salt_chan",
            new List<string>
            {
                "Close the fucking door, Brian can hear you screaming.",
                "So many flavors and you chose salt?",
                "Oh, hey! Thought you'd be in Virginia... Or Japan... Or California... ",
                "Taco Bell says sober up before your next order."
            }
        },
        {
            "mr_blindshot",
            new List<string>
            {
                "Surprised you pulled yourself away from Reddit long enough to talk to a Discord Bot.",
                "We can all hear you playing Toxic... Through Chandler's mic.",
                "Finn isn't being needy, he's *worried about you.*"
            }
        },
        {
            "toastiewizard",
            new List<string>
            {
                "Reported.",
                "If autism were an extreme sport... You'd still be mediocre.",
                "Yeah, yeah, they're definitely cheating.",
                "You survived a cult... Just to wind up *here.*"
            }
        },
        {
            "laisyn",
            new List<string>
            {
                "Twinks are ruining my life.",
                "We can tell how drunk you are by how loud you are.",
                "Ah, look, the brand ambassador for Panic Wells!"
            }
        },
        {
            "therockinhobo",
            new List<string>
            {
                "You fight your mom yet?",
                "Sing me the choccy milk song.",
                "You're daddy's lil chocolate chunk.",
                "Look everyone! It's Le Rockin Hob."
            }
        },
        {
            "brake4birds",
            new List<string>
            {
                "You survived a cult... Just to wind up *here.*",
                "Crochet a little sweater for my last fucking brain cell.",
                "Incoming folklore dump in 3... 2... 1..."
            }
        },
        {
            "ludaire",
            new List<string>
            {
                "I can't even call you a power bottom because you'll think it's a compliment.",
                "Did you know that Hunters are one of three classes available in the game Destiny 2?",
                "So... Gambit?",
                "Have you had enough wine to do pvp activities yet?"
            }
        },
        {
            "ajisspicy",
            new List<string>
            {
                "Taco Bell says sober up before your next order.",
                "You shout \"get a job\" a lot for someone who hates her job...",
                "The best part of games with you is the complimentary jazz album that comes with it. SKE-DEE-DEE-DEE-DEE-DEEEE"
            }
        },
        {
            "sizzlingspoony",
            new List<string>
            {
                "The only man with a soul patch I will ever trust.",
                "No... Don't make me insult him. He's the only good one here.",
                "Why do they keep you in a microwave? Is it for your own safety?"
            }
        }
    };
    
    public static readonly Dictionary<DockerContainer, string> DockerContainerNames = new()
    {
        { DockerContainer.Palworld, "/Palworld" },
    };

    public enum DockerContainer
    {
        [ChoiceDisplay("Palworld")]
        Palworld = 0,
    }

    public enum Nightfalls
    {
        [ChoiceDisplay("Birthplace of the Vile")]
        BirthplaceOfTheVile = 0,
        [ChoiceDisplay("Hypernet Current")]
        HypernetCurrent = 1,
        [ChoiceDisplay("Lake of Shadows")]
        LakeOfShadows = 2,
        [ChoiceDisplay("Heist Battlegrounds: Moon")]
        HeistBattlegroundsMoon = 3,
        [ChoiceDisplay("PsiOps Battlegrounds: Cosmodrome")]
        PsiOpsBattlegroundsCosmodrome = 4,
        [ChoiceDisplay("Heist Battlegrounds: Europa")]
        HeistBattlegroundsEuropa = 5,
        [ChoiceDisplay("Heist Battlegrounds: Mars")]
        HeistBattlegroundsMars = 6,
        [ChoiceDisplay("The Lightblade")]
        Lightblade = 7,
        [ChoiceDisplay("The Scarlet Keep")]
        ScarletKeep = 8,
        [ChoiceDisplay("The Devil's Lair")]
        DevilsLair = 9,
        [ChoiceDisplay("PsiOps Battleground: Moon")]
        PsiOpsBattlegroundMoon = 10,
        [ChoiceDisplay("The Disgraced")]
        Disgraced = 11,
        [ChoiceDisplay("Fallen S.A.B.E.R.")]
        FallenSABER = 12,
        [ChoiceDisplay("The Glassway")]
        Glassway = 13,
        [ChoiceDisplay("Proving Grounds")]
        ProvingGrounds = 14,
        [ChoiceDisplay("The Arms Dealer")]
        ArmsDealer = 15,
        [ChoiceDisplay("The Insight Terminus")]
        InsightTerminus = 16,
        [ChoiceDisplay("Warden of Nothing")]
        WardenOfNothing = 17,
        [ChoiceDisplay("Exodus Crash")]
        ExodusCrash = 18,
        [ChoiceDisplay("The Inverted Spire")]
        InvertedSpire = 19,
        [ChoiceDisplay("The Corrupted")]
        Corrupted = 20
    };
    
    public static Dictionary<Nightfalls, string> NightfallSummaries = new()
    {
        { Nightfalls.BirthplaceOfTheVile, "It's the dumb one on the Throne World with the Scorn sniper boss that teleports you back through the whole damn thing. (Overload, Unstoppable.)" },
        { Nightfalls.HypernetCurrent, "The one with the silly little sparrow race in the middle and the big Taken Hydra boss. (Overload, Unstoppable.)" },
        { Nightfalls.LakeOfShadows, "Y'know that speedrun one? With all the Taken? Yeah, now it's an escort mission, and it sucks. (Antibarrier, Unstoppable.)" },
        { Nightfalls.HeistBattlegroundsMoon, "That warmind one with the sniper boss and all the scorn and you have that awful room in the middle? That one. (Antibarrier, Unstoppable.)" },
        { Nightfalls.PsiOpsBattlegroundsCosmodrome, "Remember the Lucent Hive season? It's the one with the Hive Knight and the throwing shields and that horrible room in the middle. (Antibarrier, Unstoppable.)" },
        { Nightfalls.HeistBattlegroundsEuropa, "The one where you go through the Bray facility to get to the big Shrieker boss, and Clovis just stares and never helps. (Antibarrier, Unstoppable.)" },
        { Nightfalls.HeistBattlegroundsMars, "Something something something, big axe hive boss. Dunk the things, don't get slammed. (Antibarrier, Unstoppable.)" },
        { Nightfalls.Lightblade, "Chase that one guy through the Lucent brood in the Throne World. You know the one. (Antibarrier, Unstoppable.)" },
        { Nightfalls.ScarletKeep, "Go fuck up a witch boss inside the haunted ass moon. (Antibarrier, Unstoppable.)" },
        { Nightfalls.DevilsLair, "Go to the Cosmodrome. Survive the hack. Kill the big tank. Then deal with the big spiky Servitor. (Antibarrier, Overload.)" },
        { Nightfalls.PsiOpsBattlegroundMoon, "Did you ever wish the Scarlet Keep was backwards, white, and you fought Savathun at the end? Then you did this to us. (Antibarrier, Unstoppable.)" },
        { Nightfalls.Disgraced, "That bitch witch that keeps running in the New Light tutorial? That one. (Antibarrier, Unstoppable.)" },
        { Nightfalls.FallenSABER, "You know when you're really good at combat scenarios but can't walk a ball down a hallway without dying to the environment? That one. (Antibarrier, Overload.)" },
        { Nightfalls.Glassway, "Fix another Bray mess, I guess? Fight Fallen to get to the Hydra boss and fight way too many chickens. (Antibarrier, Overload.)" },
        { Nightfalls.ProvingGrounds, "Fight Caiatl's champion... Even though she's an ally now... Fuck continuity, I guess. (Antibarrier, Unstoppable.)" },
        { Nightfalls.ArmsDealer, "They made this one harder (*and* dumber) and the new boss is a guy replacing the old boss. (Antibarrier, Unstoppable.)" },
        { Nightfalls.InsightTerminus, "The Vex and the Cabal are fighting on Nessus, and it's time to third-party their shit and kill a big Psion. (Antibarrier, Unstoppable.)" },
        { Nightfalls.WardenOfNothing, "There's an angry Servitor pretending to be Variks at that place where Cayde ate shit. Do somethin' 'bout it. (Antibarrier, Overload, Unstoppable.)" },
        { Nightfalls.ExodusCrash, "Failsafe has Fallen in her brain and needs a lobotomy about it. They're only a little invisible, but definitely real... (Antibarrier, Overload.)" },
        { Nightfalls.InvertedSpire, "Okay, look, we're third-partying on Nessus again, but this time it's a Vex Minotaur boss, so it's different! (Antibarrier, Unstoppable.)" },
        { Nightfalls.Corrupted, "So the only reason we don't kill this Taken Techeun is specifically because Petra's eyepatch told us not to. Just so we're clear. (Overload, Unstoppable.)" }
    };

    public enum ChampionTypes
    {
        Overload = 0,
        [ChoiceDisplay("Anti-Barrier")]
        Antibarrier = 1,
        Unstoppable = 2
    }

    public static Dictionary<ChampionTypes, string> ChampionTypeSummaries = new()
    {
        {
            ChampionTypes.Antibarrier,
            "Time to burst their bubbles! Unraveling and Volatile rounds can do the trick. Any non-stunning weapon can pop one of these fuckos if you’re Radiant. And Stasis freeze can sometimes delay their barrier, but not break it. Wishender is always choice, or you can dust off Arbalest, Revision Zero, Eriana’s Vow, or The Lament. For Season 23, you get stunning sidearms, congrats, Bungie hates you. Or live a Captain America fantasy with Second Chance."
        },
        {
            ChampionTypes.Overload,
            "Need those assholes to just *stop shooting and healing*? Stasis can Slow them… You can give’em a Jolt, or Suppress them. Or whip out Divinity, Le Monarque, Thunderlord, or Wavesplitter (just get an Orb first!). For Season 23, you could use Autos or Pulses, or take your chances on Rockets… or use Secant Filaments or Lucky Raspberry, if you need to be special."
        },
        {
            ChampionTypes.Unstoppable,
            "Creeps rollin’ up on you without consent? Try some Arc Blind, green uppies, or try and get a Shatter or Ignition near them. If you need an intrinsic because you won’t pay to win, try Bastion, Malfeasance, Devil’s Ruin, or Leviathan’s Breath. Or Arthrys’s Embrace if you want to risk it all with trick shots and get reported."
        }
    };
}
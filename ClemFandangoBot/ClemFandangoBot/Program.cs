// See https://aka.ms/new-console-template for more information

using ClemFandangoBot;
using ClemFandangoBot.Services;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.ConfigureServices();

var serviceProvider = services.BuildServiceProvider();
var bot = serviceProvider.GetRequiredService<IDiscordBot>();
await bot.ConnectAsync();
await bot.DisconnectAsync();
Console.ReadLine();

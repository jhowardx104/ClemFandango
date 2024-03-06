// See https://aka.ms/new-console-template for more information

using ClemFandangoBot;
using ClemFandangoBot.Services;
using Discord;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.ConfigureServices();

var serviceProvider = services.BuildServiceProvider();
var client = serviceProvider.GetRequiredService<IDiscordClient>();
await Task.Delay(-1);
client.Dispose();
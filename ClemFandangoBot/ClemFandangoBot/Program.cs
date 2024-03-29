﻿// See https://aka.ms/new-console-template for more information

using ClemFandangoBot;
using ClemFandangoBot.Services;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.ConfigureServices();

var serviceProvider = services.BuildServiceProvider();
var client = serviceProvider.GetRequiredService<IDiscordBot>();
await Task.Delay(-1);
client.Dispose();
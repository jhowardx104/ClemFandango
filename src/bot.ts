import { Client } from 'discord.js';
import { secrets } from '../secrets';

const client = new Client({ intents: ['Guilds', 'GuildMessages']});

const prefix = '!'; // Change this to your desired command prefix

client.on('ready', () => {
  console.log(`Bot is ready!`);
});

client.on('messageCreate', (message) => {
  if (!message.content.startsWith(prefix) || message.author.bot) return;

  const args = message.content.slice(prefix.length).trim().split(/ +/);
  const command = args.shift()!.toLowerCase();

  console.log('Command:', command);

  if (command === 'clemfandango') {
    message.channel.send('Yes, I can hear you, Clem Fandango.');
  }
});

client.login(secrets.discord.token); // Replace with your Discord bot token

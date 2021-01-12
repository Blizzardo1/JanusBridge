using System;
using System.Linq;

namespace JanusBridge
{
  internal static class Program {
    internal static Random Random { get; }

    static Program() {
      Random = new Random();
    }

    private static void GetInfo(IUser user) {
      if (user is DiscordUser d) {
        Console.WriteLine($"Id: {d.Id}:{d.User}#{d.Discriminator:0000} has {d.Guilds.Count} guilds joined.");
        d.Guilds.ForEach(Console.WriteLine);
        Console.WriteLine($"\n{d.Connections.Count} connection(s) in relation made.");
        d.Connections.ForEach(Console.WriteLine);
        Console.WriteLine($"User was last seen {DateTime.FromFileTime(d.LastOnline):f}");
        Console.WriteLine($"{'-'.Repeat(32)}");
      }
      else if (user is IrcUser i) {
        Console.WriteLine($"Id: {i.Id}:{i.User}@{i.Hostname} has {i.Channels.Count} channels joined.");
        i.Channels.ForEach(Console.WriteLine);
        Console.WriteLine($"\n{i.Connections.Count} connection(s) in relation made.");
        i.Connections.ForEach(Console.WriteLine);
        Console.WriteLine($"User appears to be {( i.IsAway ? "away" : "available" )}");
        Console.WriteLine($"User was last seen {DateTime.FromFileTime(i.LastOnline):f}");
        Console.WriteLine($"{'-'.Repeat(32)}");
      }
    }

    private static void Main(string[] args) {
      var user = new DiscordUser("GeneralKenobi", 1);
      var irc = new IrcUser("blizzardo1", "blizzeta.net");
      GetInfo(user);
      Console.WriteLine();
      GetInfo(irc);
    }
  }
}
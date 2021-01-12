#region Header
// JanusBridge >JanusBridge >IrcUSer.cs\n Copyright (C) Adonis Deliannis, 2021\nCreated 12 01, 2021
#endregion

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace JanusBridge {
    public class IrcUser : IUser {
        #region Implementation of IUser

        /// <inheritdoc />
        public string User { get; private set; }

        /// <inheritdoc />
        public string Id { get; private set; }

        /// <inheritdoc />
        public List< string > Connections { get; private set; }

        /// <inheritdoc />
        public long LastOnline { get; private set; }

        #endregion

        public string Hostname { get; private set; }

        public List< string > Channels { get; private set; }

        public bool IsAway { get; private set; }

        public IrcUser(string user, string hostname) {
            User = user;
            Hostname = hostname;
            IsAway = Program.Random.Next(0, 100) % 2 == 0;
            LastOnline = DateTime.Now.GetRandomTimeLong();
            
            Connections = new List< string >(new []{"irc:irc.geekshed.net", "discord:DiscordPlusPlus"});
            Channels = new List< string >(new [] {"#theshed", "#script-help", "#insanityplayground"});
            Id = $"{User}@{hostname}".GenerateId();
        }
    }
}
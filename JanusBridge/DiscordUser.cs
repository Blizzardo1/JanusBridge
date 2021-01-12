#region Header
// JanusBridge >JanusBridge >DiscordUser.cs\n Copyright (C) Adonis Deliannis, 2021\nCreated 12 01, 2021
#endregion

using System;
using System.Collections.Generic;

namespace JanusBridge {
    public class DiscordUser : IUser {
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

        public uint Discriminator { get; private set; }

        public List< ulong > Guilds { get; private set; }

        public DiscordUser(string user, uint discriminator) {
            User = user;
            Discriminator = discriminator;
            LastOnline = DateTime.Now.GetRandomTimeLong();
            Connections = new List< string >(new[] {"discord:DiscordPlusPlus", "irc:irc.geekshed.net"});
            Id = $"{User}#{Discriminator}".GenerateId();
            Guilds = new List< ulong >(new ulong[]{573489584954489549, 5839055325325328902, 5238563626243745834, 54677623626312421});
        }
    }
}
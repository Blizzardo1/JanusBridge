#region Header
// JanusBridge >JanusBridge >IUser.cs\n Copyright (C) Adonis Deliannis, 2021\nCreated 12 01, 2021
#endregion

using System.Collections.Generic;

namespace JanusBridge {
    public interface IUser {
        string User { get; }
        string Id { get; }
        List< string > Connections { get; }
        long LastOnline { get; }
    }
}
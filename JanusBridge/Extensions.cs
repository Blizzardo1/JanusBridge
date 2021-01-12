#region Header
// JanusBridge >JanusBridge >Extensions.cs\n Copyright (C) Adonis Deliannis, 2021\nCreated 12 01, 2021
#endregion

using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace JanusBridge {
    internal static class Extensions {
        public static string GetString(this byte[] b) => Encoding.UTF8.GetString(b);
        public static string GetHex(this byte[] b) => BitConverter.ToString(b).Replace("-", "").ToLower();
        public static byte[] GetBytes(this string s) => Encoding.UTF8.GetBytes(s);
        
        public static long GetRandomTimeLong(this DateTime dt ) => 
            DateTime.FromFileTimeUtc(dt.ToFileTimeUtc() -
                                     Program.Random.Next(0, int.MaxValue)).ToFileTime();

        public static string Repeat(this char c, int len) => string.Join("", Enumerable.Repeat(c, len));

        public static string GenerateId(this string pretext) => SHA256.Create().ComputeHash(pretext.GetBytes()).GetHex();
    }
}
﻿using System.Text;

namespace UrlShortener.Utility
{
    public class UrlShortenerHelper
    {
        private static readonly string alphabet = "abcdefghijklmnopqrstuvwxyz0123456789";
        private static readonly int lenghth = alphabet.Length;
        public static string Encode(int i)
        {
            if (i == 0) return alphabet[0].ToString();

            StringBuilder sb = new StringBuilder();

            while (i > 0)
            {
                sb.Append(alphabet[i % lenghth]);
                i = i / lenghth;
            }
            return sb.ToString();
        }
    }
}

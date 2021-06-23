using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Services
{
    public static class TextEncoder
    {
        public static string Encode(string str, int Key = 3)
        {
            return new(str.Select(c => (char)(c + Key)).ToArray());
        }

        public static string Decode(string str, int Key = 3)
        {
            return new(str.Select(c => (char)(c - Key)).ToArray());
        }
    }
}

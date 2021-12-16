using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7
{
    class BCoder : ICoder
    {
        private readonly char[] _lowercaseAlpha = 
            Enumerable.Range('a', 'z' - 'a' + 1)
            .Select(i => (Char)i)
            .ToArray();

        private readonly char[] _uppercaseAlpha = 
            Enumerable.Range('A', 'Z' - 'A' + 1)
            .Select(i => (Char)i)
            .ToArray();

        public string Decode(string str)
        {
            return Encode(str);
        }

        public string Encode(string str)
        {
            var query = str.Select(ch =>
            {
                if (!char.IsLetter(ch))
                    return ch;

                int index = Array.IndexOf(_lowercaseAlpha, ch);
                if (index != -1)
                {
                    return _lowercaseAlpha[^(index + 1)];
                }

                index = Array.IndexOf(_uppercaseAlpha, ch);
                if (index != -1)
                {
                    return _uppercaseAlpha[^(index + 1)];
                }

                throw new Exception("It never reach here");
            });

            return new string(query.ToArray());
        }
    }
}

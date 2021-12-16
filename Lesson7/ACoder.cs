using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7
{
    class ACoder : ICoder
    {
        private readonly char[] _lowercaseAlpha = Enumerable.Range('a', 'z' - 'a' + 1).Select(i => (Char) i).ToArray();
        private readonly char[] _uppercaseAlpha = Enumerable.Range('A', 'Z' - 'A' + 1).Select(i => (Char)i).ToArray();

        //тут где то напрашиваются делегаты и одна общая для обоих методов функция
        public string Decode(string str)
        {
            var query = str.Select(ch => 
            {
                if (!char.IsLetter(ch))
                    return ch;

                if (_lowercaseAlpha.First() == ch)
                {
                    return _lowercaseAlpha.Last();
                }
                else if (_uppercaseAlpha.First() == ch)
                {
                    return _uppercaseAlpha.Last();
                }
                else
                {
                    return (char)(ch - 1);
                }
            });

            return new string(query.ToArray());
        }

        public string Encode(string str)
        {
            var query = str.Select(ch =>
            {
                if (!char.IsLetter(ch))
                    return ch;

                if (_lowercaseAlpha.Last() == ch)
                {
                    return _lowercaseAlpha.First();
                }
                else if (_uppercaseAlpha.Last() == ch)
                {
                    return _uppercaseAlpha.First();
                }
                else
                {
                    return (char)(ch + 1);
                }
            });

            return new string(query.ToArray());
        }
    }
}

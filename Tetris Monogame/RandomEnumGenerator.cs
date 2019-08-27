using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_Monogame
{
    static class RandomEnumGenerator
    {
        public static T Generate<T>()
        {
            var availbleEnum = Enum.GetValues(typeof(T));
            var randomEnum = availbleEnum.GetValue(new Random().Next(availbleEnum.Length));
            return (T)randomEnum;
        }
    }
}

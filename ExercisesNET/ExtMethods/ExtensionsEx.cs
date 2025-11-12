using Exercises.Delegates.Sample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesNET.ExtMethods
{
    internal static class ExtensionsEx
    {

        public static string GetFirstOrEmptyIfNullOrEmpty(this IEnumerable<string> source)
        {
            return source == null || !source.Any() ? string.Empty : source.First();
        }

        public static int Increment(this int counter)
        {
            return counter + 1;
        }

        
        public static int CountWords(this string source) => 
            source.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;

        public static T ToEnum<T>(this string value, bool ignorecase) where T : struct //enum  -> int
        {
            if(Enum.TryParse<T>(value, ignorecase,  out T parsed))
            {
                return parsed;
            }

            return default(T);
        }
    }
}

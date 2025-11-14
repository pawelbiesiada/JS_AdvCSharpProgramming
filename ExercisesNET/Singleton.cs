using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesNET
{
    internal class LanguageManager
    {
        private static LanguageManager _instance = null;

        public string CurrentLanguage { get; private set; }
        private static object _lock = new object();

        public static LanguageManager Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new LanguageManager();
                    }
                }
                return _instance;

            }
        }

        private LanguageManager()
        {
            CurrentLanguage = "PL";
        }
        public void SetLanguage(string language)
        {
            CurrentLanguage = language;
        }

        public CultureInfo GetLanguage()
        {
            return CultureInfo.GetCultureInfo(CurrentLanguage);
        }
    }


    abstract class Singleton<T>
    {
        private static T _instance;

        //public string CurrentLanguage { get; private set; }
        private static object _lock = new object();

        public static T Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = default(T);
                    }
                }
                return _instance;

            }
        }

    }
}


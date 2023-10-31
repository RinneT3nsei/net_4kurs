using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    internal class Singleton
    {
        public class Logger
        {
            private static Logger instance;
            private List<string> log;

            private Logger()
            {
                log = new List<string>();
            }

            public static Logger Instance
            {
                get
                {
                    if (instance == null)
                    {
                        instance = new Logger();
                    }
                    return instance;
                }
            }

            public void AddLog(string message)
            {
                log.Add(message);
            }

            public List<string> GetLog()
            {
                return log;
            }
        }

        public class Settings
        {
            private static Settings instance;
            private Dictionary<string, string> settings;

            private Settings()
            {
                settings = new Dictionary<string, string>();
            }

            public static Settings Instance
            {
                get
                {
                    if (instance == null)
                    {
                        instance = new Settings();
                    }
                    return instance;
                }
            }

            public void SetSetting(string key, string value)
            {
                settings[key] = value;
            }

            public string GetSetting(string key)
            {
                if (settings.ContainsKey(key))
                {
                    return settings[key];
                }
                return null;
            }
        }
    }
}

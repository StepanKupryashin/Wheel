using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wheel
{
    public class AppState
    {
        // стейт приложения - словарь (key-value) ключ - строка, значение - динамическое значение(мало ли что)
        private static Dictionary<string, dynamic> _state = new Dictionary<string, dynamic>();

        public static dynamic Get(string key)
        {
            if (_state.ContainsKey(key)) return _state[key];
            return false;
        }

        public static void Delete(string key)
        {
            _state.Remove(key);
        }

        public static void Clear()
        {
            _state.Clear();
        }

        public static Dictionary<string, dynamic> All()
        {
            return _state;
        }

        public static void Add(string key, dynamic value)
        {
            if (_state.ContainsKey(key)) return;
            
            _state[key] = value;
        }

    }
}

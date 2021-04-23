using System;
using System.Text;
using Newtonsoft.Json;

namespace Utils
{
    public static class Crypt
    {
        private static string s_part1 = "VfeiZELeJOIF6YB4VGqutM79nMAcT3bjHADwAnIvffgJ8XLck2oIxumWMWsiQiAfb6oJ2HIUWWYnBYAac927zldLEw8LLBzwcv8lPju0qtwe6l4HK2S9TM8cLxtrLup5";
        private static string s_part2 = "AgNruNYZgGmpAuK1KJo4ihCMNoGd3mLcd3WVQglPXacI4jixkJsFBmQDG2PiBYgwSVi7dYnyHAtMEsnpzaF5Tu3fZQOqnkObExgp6WhEl76U7Qi7YHc2s31wykDf8FWIovbkKAwIlrVjpLYD9DBIjrDISCr6i7rNvnRXR01Wvr975EUdyyHytrAm4M2fytqQP1hMqTAM4ZuMqPd8l9nh8cDVlxwUuDiaEXkaoVWPMftkFuPS7MYLYAdDjLyIbSTH";
        
        public static string Encode(object inputObj)
        {
            var json = JsonConvert.SerializeObject(inputObj);
            var tmp = Convert.ToBase64String(Encoding.UTF8.GetBytes(json));
            var coded = $"{s_part1}{tmp}{s_part2}";
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(coded));
        }

        public static T Decode<T>(string input)
        {
            var tmp = Convert.FromBase64String(input);
            var decodedPart1 = Encoding.Default.GetString(tmp).Replace(s_part1, string.Empty);
            var decodedPart2 = decodedPart1.Replace(s_part2, string.Empty);
            var bytes = Convert.FromBase64String(decodedPart2);
            return JsonConvert.DeserializeObject<T>(Encoding.Default.GetString(bytes));
        }
    }
}

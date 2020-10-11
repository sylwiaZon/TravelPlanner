using Newtonsoft.Json;

namespace TravelPlanner.Core.Triposo
{
    public class LanguageInfo
    {
        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("original_language")]
        public string OriginalLanguage { get; set; }

        [JsonProperty("translation_provider")]
        public string TranslationProvider { get; set; }
    }
}

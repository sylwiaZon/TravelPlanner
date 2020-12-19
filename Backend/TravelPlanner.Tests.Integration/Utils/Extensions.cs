using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TravelPlanner.Tests.Integration.Utils
{
    public static class Extensions
    {
        public static StringContent AsJson(this object o)
            => new StringContent(JsonConvert.SerializeObject(o), Encoding.UTF8, "application/json");
        
        public static async Task<T> ToObject<T>(this HttpResponseMessage r)
            => JsonConvert.DeserializeObject<T>(await r.Content.ReadAsStringAsync());
    }
}
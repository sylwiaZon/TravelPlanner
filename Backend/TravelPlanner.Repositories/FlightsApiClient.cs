using System;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TravelPlanner.Core.Flights;

namespace TravelPlanner.Repositories
{
    public class FlightsApiClient
    {
        private readonly HttpClient Client;
        private readonly string Path = "https://api.lufthansa.com/v1/";
        private static string Token;
        private string ClientId;
        private string ClientSecret;

        public FlightsApiClient() 
        {
            Client = new HttpClient();
            
            ClientId = Environment.GetEnvironmentVariable("LUFTHANSA_ID");
            ClientSecret = Environment.GetEnvironmentVariable("LUFTHANSA_SECRET");
        }

        public async Task<Token> GetToken()
        {
            var request = new HttpRequestMessage(HttpMethod.Post, Path + "oauth/token");

            var requestContent = string.Format("client_id={0}&client_secret={1}&grant_type={2}", ClientId, ClientSecret, "client_credentials");
            request.Content = new StringContent(requestContent, Encoding.UTF8, "application/x-www-form-urlencoded");

            var responseMessage = await Client.SendAsync(request);

            if (responseMessage.IsSuccessStatusCode)
            {
                return await responseMessage.Content.ReadAsAsync<Token>();
            }
            return null;
        }

        public async Task<FlightsSchedule> GetSchedule(string origin, string destination, string date)
        {
            await SetToken();

            var responseMessage = await Client.GetAsync(Path + "operations/schedules/" + origin + "/" + destination + "/" + date + "?directFlights=0");
            if (responseMessage.IsSuccessStatusCode)
            {
                return await responseMessage.Content.ReadAsAsync<FlightsSchedule>();
            }
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                Token = null;
                return await GetSchedule(origin, destination, date);
            }
            return null;
        }

        public async Task<FlightStatusResponse> GetFlightStatus(string flightNumber, string date)
        {
            await SetToken();

            var responseMessage = await Client.GetAsync(Path + "operations/flightstatus/" + flightNumber + "/" + date);
            if (responseMessage.IsSuccessStatusCode)
            {
                return await responseMessage.Content.ReadAsAsync<FlightStatusResponse>();
            }
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                Token = null;
                return await GetFlightStatus(flightNumber, date);
            }
            return null;
        }

        public async Task<NearestAirport> GetNearestAirports(float latitude, float longitude)
        {
            await SetToken();
            var endpointPath = Path + "references/airports/nearest/" + latitude.ToString("G", CultureInfo.InvariantCulture) + "," + longitude.ToString("G", CultureInfo.InvariantCulture);
            var responseMessage = await Client.GetAsync(endpointPath);
            if (responseMessage.IsSuccessStatusCode)
            {
                return await responseMessage.Content.ReadAsAsync<NearestAirport>();
            }
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                Token = null;
                return await GetNearestAirports(latitude, longitude);
            }
            return null;
        }

        private async Task SetToken()
        {
            if (Token != null)
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            else
            {
                var tokenResponse = await GetToken();
                Token = tokenResponse.AccessToken;
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            }
        }

    }
}

namespace CoreTravels.Services
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class GeoCoordService
    {
        private IConfigurationRoot _config;
        private ILogger<GeoCoordService> _logger;

        public GeoCoordService(ILogger<GeoCoordService> logger, IConfigurationRoot config)
        {
            _logger = logger;
            _config = config;
        }
        
        public async Task<GeoCoordsResult> GetCoords(string name)
        {
            var result = new GeoCoordsResult
            {
                Success = false,
                Message = "Failed to get coordinates"
            };

            var apiKey = "AIzaSyBP12XhHVgXbH3fLTr5sknpn-ZvQDwiIgE";
            var encodedName = WebUtility.UrlEncode(name);
            var url = $"https://maps.googleapis.com/maps/api/geocode/json?address={encodedName}&key={apiKey}";

            var client = new HttpClient();
            var json = await client.GetStringAsync(url);

            try
            {
                JObject jObj = JObject.Parse(json);

                JArray results = jObj["results"] as JArray;

                JToken firstResult = results.First;
                JToken location = firstResult["geometry"]["location"];

                result.Latitude = Convert.ToDouble(location["lat"].ToString());
                result.Longitude = Convert.ToDouble(location["lng"].ToString());
                result.Success = true;
                result.Message = "Success";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }

            return result;
        }
    }
}

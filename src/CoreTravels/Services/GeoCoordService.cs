using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CoreTravels.Services
{
    public class GeoCoordService
    {
        private ILogger<GeoCoordService> _logger;

        public GeoCoordService(ILogger<GeoCoordService> logger)
        {
            _logger = logger;
        }
        
        public GeoCoordsResult GetCoords(string name)
        {
            var result = new GeoCoordsResult
            {
                Success = false,
                Message = "Failed to get coordinates"
            };

            var apiKey = string.Empty;
            var encodedName = WebUtility.UrlEncode(name);
            var url = $"http://dev.virtualearth.net/REST/v1/Locations?q={encodedName}&key={apiKey}";
        }
    }
}

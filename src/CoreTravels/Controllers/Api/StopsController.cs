namespace CoreTravels.Controllers.Api
{
    using AutoMapper;
    using Models;
    using Services;
    using ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;

    [Route("/api/trips/{idTrip}/stop")]
    public class StopsController : Controller
    {
        private GeoCoordService _coordService;
        private ILogger<StopsController> _logger;
        private IMapper _mapper;
        private ICoreTravelsRepository _repository;

        public StopsController(ICoreTravelsRepository repository, ILogger<StopsController> logger, IMapper mapper, GeoCoordService coordService)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _coordService = coordService;
        }

        [HttpGet]
        public IActionResult Get(int idTrip)
        {
            try
            {
                var trip = _repository.GetTripById(idTrip);

                return Ok(_mapper.Map<StopViewModel>(trip.Stops));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(ModelState);
            }
        }

        public IActionResult Post(int idTrip, [FromBody]StopViewModel vm)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var newStop = _mapper.Map<Stop>(vm);

                    var result = _coordService.GetCoords(newStop.Name);

                    if (result.Result.Success)
                    {
                        newStop.Latitude = result.Result.Latitude;
                        newStop.Longitude = result.Result.Longitude;

                        _repository.AddStop(idTrip, newStop);

                        return Created($"/api/trips/{idTrip}/stops/{newStop.Id}", _mapper.Map<StopViewModel>(newStop));
                    }
                    else
                    {
                        _logger.LogError(result.Result.Message);
                    }
                }

                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(ModelState);
            }
        }
    }
}

using AutoMapper;
using CoreTravels.Models;
using CoreTravels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreTravels.Controllers.Api
{
    public class TripsController : Controller
    {
        private ILogger<TripsController> _logger;
        private IMapper _mapper;
        private ICoreTravelsRepository _repository;

        public TripsController(ICoreTravelsRepository repository, IMapper mapper, ILogger<TripsController> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("api/trips")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<TripViewModel>>(_repository.GetAllTrips()));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(ModelState);
            }
        }

        [HttpPost("api/trips")]
        public IActionResult Post([FromBody]TripViewModel trip)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newTrip = _mapper.Map<Trip>(trip);

                    _repository.AddTrip(newTrip);
                    return Created($"api/Trips/{trip.Name}", trip);
                }

                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest("Failed When Insert into DB");
            }
        }
    }
}

using AutoMapper;
using CoreTravels.Models;
using CoreTravels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreTravels.Controllers.Api
{
    [Route("/api/trips/{tripName}/stop")]
    public class StopsController : Controller
    {
        private ILogger<StopsController> _logger;
        private IMapper _mapper;
        private ICoreTravelsRepository _repository;

        public StopsController(ICoreTravelsRepository repository, ILogger<StopsController> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get(string tripName)
        {
            try
            {
                var trip = _repository.GetTripByName(tripName);

                return Ok(_mapper.Map<StopViewModel>(trip.Stops));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(ModelState);
            }
        }

        public IActionResult Post(string tripName, [FromBody]StopViewModel vm)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var newStop = _mapper.Map<Stop>(vm);

                    _repository.AddStop(tripName, newStop);

                    return Created($"/api/trips/{tripName}/stops/{newStop.Name}", _mapper.Map<StopViewModel>(newStop));
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

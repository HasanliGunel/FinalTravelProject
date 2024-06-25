using Business.Abstract;
using Entities.Concrete.TableModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TravelWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationController : ControllerBase
    {
        private readonly IDestinationService _destinationServer;

        public DestinationController(IDestinationService destinationServer)
        {
            _destinationServer = destinationServer;
        }

        [HttpGet("GetDestinations")]
        public IActionResult GetDestinations()
        {
            var result = _destinationServer.GetAll();

            if (result.IsSuccess)
                return Ok(result);
            return BadRequest();
        }
        //[HttpPost("AddDestination")]
        //public IActionResult AddDestination(Destination destination)
        //{

        //}
        

        
    }
}

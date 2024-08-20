using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkAhead.Business.Interfaces;

namespace ParkAhead.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReservationController : ControllerBase
	{
        private readonly IReservationService _service;
        public ReservationController(IReservationService service)
        {
            _service = service;
        }
    }
}

using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservationCase.Models;

namespace ReservationCase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }
        [HttpPost]
        public IActionResult CheckReservation(RequestModel request)
        {
            if (request == null) return BadRequest();
            var response = _ticketService.CheckReservation(request);
            return Ok(response);
            
        }
    }
}

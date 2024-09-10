using Microsoft.Azure.Functions.Worker;
using ParkAhead.Business.Interfaces;

namespace ParkAhead.TimerTrigger
{
    public class CheckReservations
    {
        private readonly IReservationService _service;

        public CheckReservations(IReservationService service)
        {
            _service = service;
        }

        [Function("CheckReservations")]
        public void Run([TimerTrigger("* * * * *")] TimerInfo myTimer)
        {
            _service.CheckReservations();
        }
    }
}

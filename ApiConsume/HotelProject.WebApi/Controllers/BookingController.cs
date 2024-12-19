    using HotelProject.BusinessLayer.Abstract;
    using HotelProject.EntityLayer.Concrete;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    namespace HotelProject.WebApi.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class BookingController : ControllerBase
        {
            private readonly IBookingService  _bookingService;

            public BookingController(IBookingService bookingService)
            {
                _bookingService = bookingService;
            }

            [HttpGet]
            public IActionResult BookingList()
            {
                var values = _bookingService.TGetList();
                return Ok(values);
            }
            [HttpPost]
            public IActionResult AddBooking(Booking service)
            {
                _bookingService.TInsert(service);
                return Ok();
            }

            [HttpDelete("{id}")]
            public IActionResult DeleteBooking(int id)
            {
                var values = _bookingService.TGetById(id);
                _bookingService.TDelete(values);
                return Ok();
            }

            [HttpPut]
            public IActionResult UpdateBooking(Booking service)
            {
                _bookingService.TUpdate(service);
                return Ok();
            }

            [HttpGet("{id}")]
            public IActionResult GetBooking(int id)
            {
                var values = _bookingService.TGetById(id);
                return Ok(values);
            }

        [HttpGet("Last6Bookings")]

        public IActionResult GetLast6Bookings()
        {
            var values = _bookingService.TGetLast6Booking();
            return Ok(values);
        }

        }
    }

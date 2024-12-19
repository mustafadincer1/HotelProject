using HotelProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardWidgetsController : ControllerBase
    {
        private readonly IStaffService _staffService;
        private readonly IBookingService _bookingService;
        private readonly IAppUserService _appUserService;
        private readonly IRoomService _roomService;

        public DashboardWidgetsController(IStaffService staffService, IBookingService bookingService, IAppUserService appUserService, IRoomService roomService)
        {
            _staffService = staffService;
            _bookingService = bookingService;
            _appUserService = appUserService;
            _roomService = roomService;
        }

        [HttpGet("StaffCount")]

        public IActionResult GetStaffCount() {
            
            var value = _staffService.TGetStaffCount();
            return Ok(value);
        
        }

        [HttpGet("BookingCount")]

        public IActionResult GetBookingCount() { 
            var value =  _bookingService.TGetBookingCount();
            return Ok(value);
        
        }

        [HttpGet("UserCount")]

        public IActionResult GetUserCount()
        {
            var value = _appUserService.TGetUserCount();
            return Ok(value);

        }

        [HttpGet("RoomCount")]

        public IActionResult GetRoomCount()
        {
            var value = _roomService.TGetRoomCount();
            return Ok(value);

        }
    }
}

using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.RoomDto;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Room2Controller : ControllerBase
    {
        private readonly IRoomService _service;
        private readonly IMapper _mapper;

        public Room2Controller(IRoomService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index() {
            var values = _service.TGetList();
            return Ok(values);
        }

        [HttpPost]
        
        public IActionResult AddRoom(RoomAddDto addDto) {
            
            if (!ModelState.IsValid)
            {
                return BadRequest();

            }
            var values = _mapper.Map<Room>(addDto);
            _service.TInsert(values);
     
            return Ok();

        }

        [HttpPut]
        public IActionResult UpdateRoom(RoomUpdateDto updateDto) {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values = _mapper.Map<Room>(updateDto);
            _service.TUpdate(values);
            return Ok();    

        }
    }
    
}

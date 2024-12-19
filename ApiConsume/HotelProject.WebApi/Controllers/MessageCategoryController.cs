using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageCategoryController : ControllerBase
    {
        private readonly IMessageCategoryService _messageCategoryService;

        public MessageCategoryController(IMessageCategoryService messageCategoryService)
        {
            _messageCategoryService = messageCategoryService;
        }

        [HttpGet]
        public IActionResult MessageCategoryList()
        {
            var values = _messageCategoryService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddMessageCategory(MessageCategory MessageCategory)
        {
            _messageCategoryService.TInsert(MessageCategory);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteMessageCategory(int id)
        {
            var values = _messageCategoryService.TGetById(id);
            _messageCategoryService.TDelete(values);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateMessageCategory(MessageCategory MessageCategory)
        {
            _messageCategoryService.TUpdate(MessageCategory);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetMessageCategory(int id)
        {
            var values = _messageCategoryService.TGetById(id);
            return Ok(values);
        }
    }
}

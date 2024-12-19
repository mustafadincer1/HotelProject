using HotelProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserService _appUserService;

        public AppUserController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        //[HttpGet]
        //public IActionResult AppUserListWithWorkLocation()
        //{
        //    var values = _appUserService.TUserListWithWorkLocation();
        //    return Ok(values);
        //}

        [HttpGet]
        public IActionResult AppUserList()
        {
            var values = _appUserService.TGetList();
            return Ok(values);
        }
        //[HttpPost]
        //public IActionResult AddAppUser(AppUser AppUser)
        //{
        //    _appUserService.TInsert(AppUser);
        //    return Ok();
        //}

        //[HttpDelete]
        //public IActionResult DeleteAppUser(int id)
        //{
        //    var values = _appUserService.TGetById(id);
        //    _appUserService.TDelete(values);
        //    return Ok();
        //}

        //[HttpPut]
        //public IActionResult UpdateAppUser(AppUser AppUser)
        //{
        //    _appUserService.TUpdate(AppUser);
        //    return Ok();
        //}

        //[HttpGet("{id}")]
        //public IActionResult GetAppUser(int id)
        //{
        //    var values = _appUserService.TGetById(id);
        //    return Ok(values);
        //}
    }
}

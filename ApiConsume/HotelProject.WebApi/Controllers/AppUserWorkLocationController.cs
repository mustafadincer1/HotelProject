using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserWorkLocationController : ControllerBase
    {
        private readonly IAppUserService _appUserService;

        public AppUserWorkLocationController(IAppUserService appUserService)
        {
            this._appUserService = appUserService;
        }
        [HttpGet]
        public ActionResult Index()
        {
            //var values = _appUserService.TUserListWithWorkLocations();
            var context = new Context();
            var values = context.Users.Include(x => x.WorkLocation).Select(Y => new AppUserWorkLocationViewModel
            {
                Name = Y.Name,
                Surname = Y.Surname,
                WorkLocationID = Y.WorkLocationID,
                WorkLocationName = Y.WorkLocation.WorkLocationName,
                City = Y.City,
                Country = Y.Country,
                Gender = Y.Gender,
                ImageUrl = Y.ImageUrl,
            }).ToList();
            return Ok(values);
        }
    }
}

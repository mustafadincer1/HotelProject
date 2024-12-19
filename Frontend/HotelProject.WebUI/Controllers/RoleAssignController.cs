using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Models.Role;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class RoleAssignController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public RoleAssignController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var roles = _roleManager.Roles.ToList();
            var userRoles = await _userManager.GetRolesAsync(user);
            var roleAssignViewModels = roles.Select(role => new RoleAssignViewModel
            {
                RoleID = role.Id,
                RoleName = role.Name,
                RoleExist = userRoles.Contains(role.Name)
            }).ToList();

            TempData["user"] = user.Id;
            return View(roleAssignViewModels);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> roleAssignViewModel)
        {
            // Ensure TempData contains "user" and it can be cast to int
            if (TempData.ContainsKey("user") && TempData["user"] is int userId)
            {
                // Find the user by ID, assuming Id is of type int
                var user = _userManager.Users.FirstOrDefault(x => x.Id == userId);

                // Ensure user is not null
                if (user != null)
                {
                    foreach (var role in roleAssignViewModel)
                    {
                        if (role.RoleExist)
                        {
                            await _userManager.AddToRoleAsync(user, role.RoleName);
                        }
                        else
                        {
                            await _userManager.RemoveFromRoleAsync(user, role.RoleName);
                        }
                    }
                    return RedirectToAction("Index");
                }
                else
                {
   
                
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

    }
}


﻿using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Models.Role;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var values = _roleManager.Roles.ToList();
            return View(values);
        }

        [HttpGet]

        public IActionResult AddRole() { 
            return View();
        
        }
        [HttpPost]
        public async Task <IActionResult> AddRole(AddRoleViewModel addRoleViewModel)
        {
            AppRole role = new AppRole()
            {
                Name= addRoleViewModel.RoleName
            };
            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {

                return RedirectToAction("Index");
            }
            return View();

        }
        [HttpGet]
        public async Task<IActionResult> DeleteRole(int id) { 
            
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
             await _roleManager?.DeleteAsync(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
          
        public IActionResult UpdateRole(int id) {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            UpdateRoleViewModel updateRoleViewModel = new UpdateRoleViewModel()
            {
                RoleID = value.Id,
                RoleName = value.Name,

            };
            return View(updateRoleViewModel);

        }

        [HttpPost]

        public async Task<IActionResult >UpdateRole(UpdateRoleViewModel model)
        {
            var value = _roleManager.Roles.FirstOrDefault(x=> x.Id == model.RoleID);
            value.Name = model.RoleName;    
            await _roleManager.UpdateAsync(value);
            return RedirectToAction("Index");

        }
    }
}

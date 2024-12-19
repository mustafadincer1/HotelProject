﻿using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.ContactDto;
using HotelProject.WebUI.Dtos.MessageCategoryDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {

       
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("http://localhost:5140/api/MessageCategory");
        
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultMessageCategoryDto>>(jsonData);
            List<SelectListItem> values2 = (from item in values
                                            select new SelectListItem { 
                                                Text = item.MessageCategoryName,
                                                Value = item.MessageCategoryID.ToString()
                                            }).ToList();
            ViewBag.Values = values2;
            return View();

        }
        [HttpGet]
        public PartialViewResult SendMessage()
        {

            return PartialView();
        }


        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateContactDto createContactDto)
        {

            createContactDto.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createContactDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("http://localhost:5140/api/Contact", content);

            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index", "Default");
            }

            ModelState.AddModelError("", "Bir hata oluştu, lütfen tekrar deneyin.");
            return View();
        }
    }
}

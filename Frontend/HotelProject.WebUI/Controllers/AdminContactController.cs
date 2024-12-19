using HotelProject.WebUI.Dtos.ContactDto;
using HotelProject.WebUI.Dtos.SendMessageDto;
using HotelProject.WebUI.Dtos.ServiceDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class AdminContactController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public AdminContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Inbox()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5140/api/Contact"); 
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client.GetAsync("http://localhost:5140/api/Contact/GetContactCount"); 
            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client.GetAsync("http://localhost:5140/api/SendMessage/GetSendMessageCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<InboxContactDto>>(jsonData);
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                ViewBag.ContactCount = jsonData2;
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                ViewBag.SendMessageCount = jsonData3;
                return View(values);
            }

            return View();
        }

        public async Task<IActionResult> Sendbox()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5140/api/SendMessage");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSendboxDto>>(jsonData);
                return View(values);
            }

            return View();
        }
        public async Task<IActionResult> MessageDetailsBySendbox(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5140/api/SendMessage/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetMessageByIDDto>(jsonData);
                return View(values);
            }

            return View();
        }

        public async Task<IActionResult> MessageDetailsByInbox(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5140/api/Contact/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<InboxContactDto>(jsonData);
                return View(values);
            }

            return View();
        }




        public PartialViewResult SideBarAdminContactPartial()
        {
            return PartialView();
        }

        public PartialViewResult SideBarAdminContactCategoryPartial()
        {
            return PartialView();
        }
        [HttpGet]
        public PartialViewResult AddSendMessage()
        {
            return PartialView();
        }


        [HttpPost]

        public async Task<IActionResult> AddSendMessage(CreateSendMessage createSendMessage )
        {
            createSendMessage.SenderName = "admin";
            createSendMessage.SenderMail = "admin@gmail.com";

 
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(createSendMessage);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var responseMessage = await client.PostAsync("http://localhost:5140/api/SendMessage", content);

                if (responseMessage.IsSuccessStatusCode)
                {

                    return RedirectToAction("SendBox");
                }else {
                ModelState.AddModelError("", "Misafir eklenirken bir hata oluştu, lütfen tekrar deneyin.");
                return View(createSendMessage);
            }

              
            }
        
        }

    }


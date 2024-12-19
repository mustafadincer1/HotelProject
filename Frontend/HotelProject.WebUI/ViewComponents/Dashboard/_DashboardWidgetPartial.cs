using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardWidgetPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardWidgetPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task< IViewComponentResult >InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5140/api/DashboardWidgets/StaffCount");
            var staffCount = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.staffCount = staffCount;
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client.GetAsync("http://localhost:5140/api/DashboardWidgets/BookingCount");
            var bookingCount = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.bookingCount = bookingCount;
            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client.GetAsync("http://localhost:5140/api/DashboardWidgets/UserCount");
            var UserCount = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.appUserCount = UserCount;
            var client4 = _httpClientFactory.CreateClient();
            var responseMessage4 = await client.GetAsync("http://localhost:5140/api/DashboardWidgets/RoomCount");
            var roomCount = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.roomCount = roomCount;
            return View();
        }
    }
}

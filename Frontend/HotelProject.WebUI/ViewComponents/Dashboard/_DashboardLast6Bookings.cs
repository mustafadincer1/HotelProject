using HotelProject.WebUI.Dtos.BookingDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardLast6Bookings : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<_DashboardLast6Bookings> _logger;

        public _DashboardLast6Bookings(IHttpClientFactory httpClientFactory, ILogger<_DashboardLast6Bookings> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<IViewComponentResult> InvokeAsync()  // Renamed to InvokeAsync for clarity
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5140/api/Booking/Last6Bookings");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLast6BookingDto>>(jsonData);
                return View(values);
            }
            else
            {
                _logger.LogError($"Failed to fetch bookings. Status Code: {responseMessage.StatusCode}");
            }

            return View(new List<ResultLast6BookingDto>());  // Pass an empty list to the view
        }
    }
}

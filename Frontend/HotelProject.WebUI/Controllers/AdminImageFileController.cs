using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class AdminImageFileController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        {
            var stram = new MemoryStream();
            await file.CopyToAsync(stram);
            var bytes = stram.ToArray();
            ByteArrayContent byteArrayContent = new ByteArrayContent(bytes);
            byteArrayContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);
            MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
            multipartFormDataContent.Add(byteArrayContent,"file",file.FileName);   
            HttpClient httpClient = new HttpClient();
            await httpClient.PostAsync($"http://localhost:5140/api/FileImage", multipartFormDataContent);

            return View();
        }
    }
}

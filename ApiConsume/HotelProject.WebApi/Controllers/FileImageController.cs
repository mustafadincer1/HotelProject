using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileImageController : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> UploadImage([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file was uploaded.");
            }

            // Generate a unique file name with its extension
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            // Define the directory path
            var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "images");

            // Ensure the directory exists
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            // Combine the directory path with the file name
            var filePath = Path.Combine(directoryPath, fileName);

            try
            {
                // Write the file to the directory
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return Created("", new { FilePath = filePath });
            }
            catch (Exception ex)
            {
                // Log the exception (use a logging library like Serilog in real projects)
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}

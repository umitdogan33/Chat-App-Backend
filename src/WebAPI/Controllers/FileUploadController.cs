using Application.Common.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile file)
        {
            FileUploadHelper.Upload(file);
            return Ok("Success");
        }
    }
}

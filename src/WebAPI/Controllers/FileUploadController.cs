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
        public async Task<IActionResult> UploadFile([FromForm] List<IFormFile> files)
        {
            foreach (var formFile in files)
            {
                FileUploadHelper.Upload(formFile);
            }

            return Ok("success");
        }
    }
}

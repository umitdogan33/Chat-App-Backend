using Application.Common.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private List<String> datas { get; set; }
        public FileUploadController()
        {
            this.datas = new();
        }
        [HttpPost]
        public async Task<IActionResult> UploadFile([FromForm] List<IFormFile> files)
        {
            foreach (var formFile in files)
            {
                var data = FileUploadHelper.Upload(formFile);
                datas.Add(data);
            }

            return Ok(datas);
        }
    }
}

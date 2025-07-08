using Microsoft.AspNetCore.Mvc;
using ComprehensiveManagementSystem.Services;

namespace ComprehensiveManagementSystem.Controllers
{
    public class CaptchaController : Controller
    {
        private readonly ICaptchaService _captchaService;

        public CaptchaController(ICaptchaService captchaService)
        {
            _captchaService = captchaService;
        }

        [HttpGet]
        public IActionResult GenerateCaptcha(string? id = null)
        {
            var captchaId = id ?? Guid.NewGuid().ToString();
            var captcha = _captchaService.GenerateCaptcha();
            
            // 生成验证码图片
            var imageBytes = _captchaService.GenerateCaptchaImage(captcha, captchaId);
            
            return File(imageBytes, "image/svg+xml");
        }

        [HttpPost]
        public IActionResult Validate([FromBody] CaptchaValidationRequest request)
        {
            var isValid = _captchaService.ValidateCaptcha(request.CaptchaId, request.Captcha);
            
            return Json(new { isValid });
        }
    }

    public class CaptchaValidationRequest
    {
        public string CaptchaId { get; set; } = string.Empty;
        public string Captcha { get; set; } = string.Empty;
    }
}
using Microsoft.Extensions.Caching.Memory;

namespace ComprehensiveManagementSystem.Services
{
    public class SimpleCaptchaService : ICaptchaService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly Random _random;

        public SimpleCaptchaService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
            _random = new Random();
        }

        public string GenerateCaptcha(int length = 4)
        {
            const string chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[_random.Next(s.Length)]).ToArray());
        }

        public byte[] GenerateCaptchaImage(string captchaCode, string captchaId)
        {
            // 存储验证码到缓存
            _memoryCache.Set(captchaId, captchaCode, TimeSpan.FromMinutes(5));

            // 返回一个简单的SVG图片作为验证码图片
            var svg = $@"<svg width='120' height='40' xmlns='http://www.w3.org/2000/svg'>
                <rect width='120' height='40' fill='#f0f0f0' stroke='#ccc'/>
                <text x='20' y='25' font-family='Arial' font-size='18' fill='#333'>{captchaCode}</text>
                <line x1='10' y1='15' x2='110' y2='25' stroke='#999' stroke-width='1'/>
                <line x1='10' y1='25' x2='110' y2='15' stroke='#999' stroke-width='1'/>
            </svg>";

            return System.Text.Encoding.UTF8.GetBytes(svg);
        }

        public bool ValidateCaptcha(string captchaId, string userInput)
        {
            if (string.IsNullOrEmpty(captchaId) || string.IsNullOrEmpty(userInput))
                return false;

            if (_memoryCache.TryGetValue(captchaId, out string? cachedCode))
            {
                _memoryCache.Remove(captchaId); // 验证码只能使用一次
                return string.Equals(cachedCode, userInput, StringComparison.OrdinalIgnoreCase);
            }

            return false;
        }
    }
}
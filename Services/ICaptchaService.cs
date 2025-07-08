namespace ComprehensiveManagementSystem.Services
{
    public interface ICaptchaService
    {
        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <param name="length">验证码长度</param>
        /// <returns>验证码字符串</returns>
        string GenerateCaptcha(int length = 4);

        /// <summary>
        /// 生成验证码图片
        /// </summary>
        /// <param name="captchaCode">验证码文本</param>
        /// <param name="captchaId">验证码ID</param>
        /// <returns>图片字节数组</returns>
        byte[] GenerateCaptchaImage(string captchaCode, string captchaId);

        /// <summary>
        /// 验证验证码
        /// </summary>
        /// <param name="captchaId">验证码ID</param>
        /// <param name="userInput">用户输入的验证码</param>
        /// <returns>是否验证成功</returns>
        bool ValidateCaptcha(string captchaId, string userInput);
    }
}
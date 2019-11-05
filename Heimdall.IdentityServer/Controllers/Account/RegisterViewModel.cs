namespace Heimdall.IdentityServer.Controllers.Account
{
    public class RegisterViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string RepeatPassword { get; set; }
        public string Email { get; set; }
        public bool AgreeToTerms { get; set; }
    }
}

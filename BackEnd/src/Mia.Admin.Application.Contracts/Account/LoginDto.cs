﻿namespace Mia.Admin.Account
{
    public class LoginDto
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string VerificationCode { get; set; } = string.Empty;
    }
}

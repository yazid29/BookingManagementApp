namespace API.DTO.Accounts
{
    public class ChangePasswordDto
    {
        public string Email { get; set; }
        public int Otp { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }
}

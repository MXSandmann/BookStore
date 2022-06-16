namespace UseCases.Users.DTO
{
    public class LoginResultDTO
    {
        public string Token { get; set; }
        public UserDTO User { get; set; }
    }
}

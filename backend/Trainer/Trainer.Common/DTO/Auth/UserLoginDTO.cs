namespace Trainer.Common.DTO.Auth
{
    public sealed class UserLoginDTO
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string AccessToken { get; set; }
        public string FirebaseId { get; set; }
    }
}

namespace WebStore.Domain.DTO.User
{
    public class PasswordHashDTO : IdentityModelDTO
    {
        public string Hash { get; set; }
    }
}
using Microsoft.AspNetCore.Identity;

namespace WebStore.Domain.DTO.User
{
    public class AddLoginDTO : IdentityModelDTO
    {
        public UserLoginInfo UserLoginInfo { get; set; }
    }
}
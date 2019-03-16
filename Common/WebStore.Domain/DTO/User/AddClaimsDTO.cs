using System.Collections.Generic;
using System.Security.Claims;

namespace WebStore.Domain.DTO.User
{
    public class AddClaimsDTO : IdentityModelDTO
    {
        public IEnumerable<Claim> Claims { get; set; }
    }
}
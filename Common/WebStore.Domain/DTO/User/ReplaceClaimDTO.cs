using System.Security.Claims;

namespace WebStore.Domain.DTO.User
{
    public class ReplaceClaimDTO : IdentityModelDTO
    {
        public Claim OldClaim { get; set; }
        public Claim NewClaim { get; set; }
    }
}
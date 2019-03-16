using System;

namespace WebStore.Domain.DTO.User
{
    public class SetLockoutDTO : IdentityModelDTO
    {
        public DateTimeOffset? LockoutEnd { get; set; }
    }
}
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Web.Models.Entities
{
    public class Usuario:IdentityUser<Guid>
    {
        public virtual ICollection<IdentityUserClaim<Guid>> UserClaims { get; set; }
        public virtual ICollection<IdentityUserLogin<Guid>> UserLogins { get; set; }
        public virtual ICollection<IdentityUserToken<Guid>> UserTokens { get; set; }
        public virtual ICollection<UsuarioRole> UserRoles { get; set; }
    }
}

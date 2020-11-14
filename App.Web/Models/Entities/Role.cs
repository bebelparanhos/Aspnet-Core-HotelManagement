using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Web.Models.Entities
{
    public class Role:IdentityRole<Guid>
    {
        public virtual ICollection<UsuarioRole> UserRoles { get; set; }
    }
}

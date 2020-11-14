using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Web.Models.Entities
{
    public class UsuarioRole:IdentityUserRole<Guid>
    {
        public virtual Usuario User { get; set; }
        public virtual Role Role { get; set; }
    }
}

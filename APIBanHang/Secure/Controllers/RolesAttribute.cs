
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace APIBanHang.Secure.SecureControllers
{
    public class RolesAttribute : AuthorizeAttribute
    {
        public RolesAttribute(params string[] roles)
        {
            Roles = roles.ToString();
        }
    }
}
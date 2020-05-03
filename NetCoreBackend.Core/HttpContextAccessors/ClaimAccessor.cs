using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NetCoreBackend.Core.Utilities.IoC;

namespace NetCoreBackend.Core.HttpContextAccessors
{
    public class ClaimAccessor: IClaimAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ClaimAccessor()
        {
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }
        public string GetUserId()
        {
            return _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}

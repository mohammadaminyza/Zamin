using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Zamin.Core.Domain.Events;
using Zamin.EndPoints.Web.Extentions;
using Zamin.Utilities.Services.Users;

namespace Zamin.EndPoints.Web.Services
{
    public class WebUserInfoService : IUserInfoService
    {
        private readonly HttpContext? _httpContext;
        private const string AccessList = "";

        public WebUserInfoService(IHttpContextAccessor httpContextAccessor)
        {
            if ((httpContextAccessor == null || httpContextAccessor.HttpContext == null) && EventUserInfo.UserId == null)
            {
                throw new ArgumentNullException(nameof(httpContextAccessor));
            }

            if (httpContextAccessor != null && httpContextAccessor.HttpContext != null)
                _httpContext = httpContextAccessor.HttpContext;
        }

        public string? GetUserAgent()
        {
            if (_httpContext != null)
                return _httpContext.Request.Headers["User-Agent"];

            if (EventUserInfo.UserAgent != null)
                return EventUserInfo.UserAgent;

            return null;
        }
        public string? GetUserIp()
        {
            if (_httpContext != null)
                return _httpContext.Connection.RemoteIpAddress.ToString();

            if (EventUserInfo.UserIp != null)
                return EventUserInfo.UserIp;

            return null;
        }
        public string? UserId()
        {
            if (_httpContext != null)
                return _httpContext.User?.GetClaim(ClaimTypes.NameIdentifier);

            if (EventUserInfo.UserId != null)
                return EventUserInfo.UserId;

            return null;
        }
        public string? GetUsername() => _httpContext.User?.GetClaim(ClaimTypes.Name);
        public string? GetFirstName() => _httpContext.User?.GetClaim(ClaimTypes.GivenName);
        public string? GetLastName() => _httpContext.User?.GetClaim(ClaimTypes.Surname);
        public bool IsCurrentUser(string userId)
        {
            return string.Equals(UserId().ToString(), userId, StringComparison.OrdinalIgnoreCase);
        }

        public virtual bool HasAccess(string accessKey)
        {
            var result = false;

            if (!string.IsNullOrWhiteSpace(accessKey))
            {
                var accessList = _httpContext.User?.GetClaim(AccessList)?.Split(',').ToList() ?? new List<string>();
                result = accessList.Any(key => string.Equals(key, accessKey, StringComparison.OrdinalIgnoreCase));
            }

            return result;
        }
    }
}

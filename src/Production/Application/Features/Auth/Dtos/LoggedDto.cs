using Core.Security.JWT;

namespace Application.Features.Auth.Dtos
{
    public class LoggedDto
    {
        public AccessToken? AccessToken { get; set; }
    }
}
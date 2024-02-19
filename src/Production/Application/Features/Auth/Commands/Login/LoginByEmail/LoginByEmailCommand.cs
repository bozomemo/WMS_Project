using Application.Features.Auth.Dtos;
using Core.Application.Pipelines.Authorization;
using Domain.Constants;
using MediatR;

namespace Application.Features.Auth.Commands.Login.LoginByEmail
{
    public class LoginByEmailCommand : IRequest<LoggedDto>
    {
        public string Email { get; set; }

        public string IpAddress { get; set; }

        public string Password { get; set; }
    }
}
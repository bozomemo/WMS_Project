using Application.Features.Auth.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Commands.AuthRefreshToken
{
    public class RefreshTokenCommand : IRequest<RefreshTokenDto>
    {
        public string? RefreshToken { get; set; }

        public string? IpAddress {  get; set; }
    }
}

﻿using Core.Security.Entities;
using Core.Security.JWT;

namespace Application.Features.Auth.Dtos
{
    public class LoggedDto
    {
        public AccessToken? AccessToken { get; set; }

        public RefreshToken? RefreshToken { get; set; }
    }
}
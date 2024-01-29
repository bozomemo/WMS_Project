using Application.Features.Users.Dtos;
using MediatR;

namespace Application.Features.Users.Commands.CreateUserCommand
{
    public class CreateUserCommand : IRequest<UserDto>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set;}
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

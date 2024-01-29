using Application.Features.Users.Dtos;
using Application.Features.Users.Rules;
using Application.Features.Users.Validators;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Hashing;
using Domain.Entities;
using MediatR;

namespace Application.Features.Users.Commands.CreateUserCommand
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly UserValidator _userValidator;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserRepository userRepository, UserValidator userValidator, IMapper mapper)
        {
            _userRepository = userRepository;
            _userValidator = userValidator;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            UsersRules.IsUserValid(_userValidator,request);

            byte[] hash, salt;

            HashingHelper.CreatePasswordHash(request.Password, out hash, out salt);

            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Username = request.Username,
                Email = request.Email,
                PasswordHash = hash,
                PasswordSalt = salt
            };

            var createdUser = await _userRepository.AddAsync(user);

            var userDto = _mapper.Map<UserDto>(createdUser);

            return userDto;

        }
    }
}

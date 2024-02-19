using Application.Features.Users.Dtos;
using Application.Features.Users.Rules;
using Application.Features.Users.Validators;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.UpdateUserCommand
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly UpdateUserValidator _validator;

        public UpdateUserCommandHandler(UpdateUserValidator validator, IMapper mapper, IUserRepository userRepository)
        {
            _validator = validator;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            UsersRules.IsUpdateUserCommandValid(_validator, request);

            var user = await _userRepository.GetAsync(x => x.Id == request.Id) ?? throw new BusinessException(AuthConstants.USER_DOESNT_EXIST);

            _mapper.Map(request, user);

            var updatedUser = await _userRepository.UpdateAsync(user);

            var userDto = _mapper.Map<UserDto>(updatedUser);

            return userDto;
        }
    }
}

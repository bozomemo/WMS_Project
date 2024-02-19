using Application.Features.Users.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Queries.GetAllActiveUsers
{
    public class GetAllActiveUsersQueryHandler : IRequestHandler<GetAllActiveUsersQuery, ICollection<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetAllActiveUsersQueryHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<ICollection<UserDto>> Handle(GetAllActiveUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.Query().Where(x => x.IsActive).ToListAsync(cancellationToken: cancellationToken);
            return _mapper.Map<ICollection<UserDto>>(users);
        }
    }
}

using Application.Services.Repositories;
using Core.Security.Entities;

namespace Application.Services.UserService
{
    public class UserManager : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;

        public UserManager(IUserRepository userRepository, IUserOperationClaimRepository userOperationClaimRepository)
        {
            _userRepository = userRepository;
            _userOperationClaimRepository = userOperationClaimRepository;
        }

        public async Task<User?> GetByEmail(string email)
        {
            User? user = await _userRepository.GetAsync(u => u.Email == email);
            return user;
        }

        public async Task<User?> GetByUsername(string username)
        {
            User? user = await _userRepository.GetAsync(u => u.Username == username);
            return user;
        }

        public async Task<User?> GetById(int id)
        {
            User? user = await _userRepository.GetAsync(u => u.Id == id);
            return user;
        }

        public async Task<User> Update(User user)
        {
            User updatedUser = await _userRepository.UpdateAsync(user);
            return updatedUser;
        }
    }
}
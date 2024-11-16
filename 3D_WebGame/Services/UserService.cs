using _3D_WebGame.Configurations;
using _3D_WebGame.DTOs.User;
using _3D_WebGame.Interface;
using _3D_WebGame.Models;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _3D_WebGame.Services {
    public class UserService : IUserService {
        public IUserRepository _iuserRepository { get; set; }
        public IMapper gameMapping { get; set; }

        public UserService(IUserRepository iuserRepository, IMapper iogameMapping) {
            _iuserRepository = iuserRepository;
            gameMapping = iogameMapping;
        }
        public async Task<UserGetDto?> delete(int id) {
            var user = await _iuserRepository.DeleteByIdAsync(id);
            if (user == null) return null;
            return gameMapping.Map<UserGetDto>(user);
        }

        public async Task<List<User>?> getAll() {
            return await _iuserRepository.GetAllAsync();
        }

        public async Task<UserGetDto?> getByAccount(AccountDto accountDto) {
            var user = gameMapping.Map<User>(accountDto);
            var userResult = await _iuserRepository.GetUserByAccountAsync(user);
            if (userResult == null) return null;
            return gameMapping.Map<UserGetDto>(userResult);
        }

        public async Task<UserGetDto?> getById(int id) {
            var user = await _iuserRepository.GetByIdAsync(id);
            if (user == null) return null;
            return gameMapping.Map<UserGetDto>(user);
        }

        public async Task<UserGetDto?> update(UserUpdateDto updateDto) {
            var user = gameMapping.Map<User>(updateDto);
            var userResult = await _iuserRepository.UpdateByIdAsync(user);
            if (userResult == null) return null;
            return gameMapping.Map<UserGetDto>(userResult);
        }

        public async Task<UserGetDto?> create(UserCreateDto accountDto) {
            var user = gameMapping.Map<User>(accountDto);
            var userResult = await _iuserRepository.Create(user);
            if (userResult == null) return null;
            return gameMapping.Map<UserGetDto>(userResult);
        }
    }
}

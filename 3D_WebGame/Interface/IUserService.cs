using _3D_WebGame.DTOs.User;
using _3D_WebGame.Models;

namespace _3D_WebGame.Interface {
    public interface IUserService {
        public Task<List<User>?> getAll();
        public Task<UserGetDto?> getById(int id);
        public Task<UserGetDto?> update(UserUpdateDto updateDto);
        public Task<UserGetDto?> delete(int id);
        public Task<UserGetDto?> getByAccount(AccountDto accountDto);
        public Task<UserGetDto?> create(UserCreateDto accountDto);

    }
}

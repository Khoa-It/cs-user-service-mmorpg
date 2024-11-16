using _3D_WebGame.DTOs.User;
using _3D_WebGame.Models;

namespace _3D_WebGame.Interface {
    public interface IUserRepository{
        Task<User?> GetByIdAsync(int id);
        Task<List<User>> GetAllAsync();
        Task<User?> DeleteByIdAsync(int id);
        Task<User?> GetUserByAccountAsync(User accountDto);
        Task<User?> UpdateByIdAsync(User updateInfo);
        Task<User?> Create(User createInfo);
    }
}

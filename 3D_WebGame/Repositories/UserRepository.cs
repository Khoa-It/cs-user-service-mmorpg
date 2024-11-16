using _3D_WebGame.Configurations;
using _3D_WebGame.DTOs.User;
using _3D_WebGame.Interface;
using _3D_WebGame.Models;
using Microsoft.EntityFrameworkCore;

namespace _3D_WebGame.Repositories {

    public class UserRepository : IUserRepository {
        private readonly GameDbContext _context;
        public UserRepository(GameDbContext context){
            _context = context;
        }

        public async Task<User?> Create(User user) {
            var exists = await _context.users.FirstOrDefaultAsync(
                (us) => us.email == user.email || us.username == user.username
            );
            if (exists != null) return null;
            user.createdDate = DateTime.Now;
            await _context.users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> DeleteByIdAsync(int id) {
            var user = await _context.users.FirstOrDefaultAsync(us => us.userId == id);
            if (user == null) return null;
            _context.users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>> GetAllAsync() {
            return await _context.users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id) {
            return await _context.users.FindAsync(id);
        }

        public async Task<User?> GetUserByAccountAsync(User accountDto) {
            return await _context.users.FirstOrDefaultAsync(
                user => user.email == accountDto.email && user.password == accountDto.password
            );
        }

        public async Task<User?> UpdateByIdAsync(User updateInfo) {
            var user = await _context.users.FindAsync(updateInfo.userId);
            if (user == null) return null;
            var existedEmailOrUsername = await _context.users.FirstOrDefaultAsync(
                us => us.email == updateInfo.email || us.username == updateInfo.username
                );
            if (existedEmailOrUsername != null) return null;
            user.email = updateInfo.email ?? user.email;
            user.username = updateInfo.username ?? user.username;
            user.password = updateInfo.password ?? user.password;
            await _context.SaveChangesAsync();
            return user;
        }
    }
}

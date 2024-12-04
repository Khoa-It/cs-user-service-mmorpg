using _3D_WebGame.Configurations;
using _3D_WebGame.Interface;
using _3D_WebGame.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _3D_WebGame.Repositories {
    public class FriendshipRepository{
        public GameDbContext context { get; set; }
        public FriendshipRepository(GameDbContext iocontext)
        {
            context = iocontext;
        }
        public async Task<List<Friendship>> getAllById(int userId) {
            return await context.friendship.Where(record =>
                record.userId1 == userId || record.userId2 == userId
            ).ToListAsync();
        }

        public async Task<List<Friendship>> getAll() {
            return await context.friendship.ToListAsync();
        }

        public async Task<Friendship> updateStatus(Friendship friendship) {
            var record = await context.friendship.FirstOrDefaultAsync(item => (
                (item.userId1 == friendship.userId1 && item.userId2 == friendship.userId2)
                || (item.userId2 == friendship.userId1 && item.userId1 == friendship.userId2)
            ));
            record.status = friendship.status;
            context.friendship.Update(record);
            await context.SaveChangesAsync();
            return record;
        }

        public async Task<Friendship> add(Friendship friendship) {
            await context.friendship.AddAsync(friendship);
            await context.SaveChangesAsync();
            return friendship;
        }

        public async Task<Friendship> find(int userid1, int userid2) {
            return await context.friendship.FirstOrDefaultAsync(item => (
                (item.userId1 == userid1 && item.userId2 == userid2)
                || (item.userId1 == userid2 && item.userId2 == userid1)
            ));
        }
    }
}

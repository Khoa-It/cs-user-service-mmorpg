using _3D_WebGame.Models;

namespace _3D_WebGame.Interface {
    public interface IFriendshipService {
        public Task<List<Friendship>> getAll(int userId);
        public Task<Friendship> update(int userId1, int userId2);
    }
}

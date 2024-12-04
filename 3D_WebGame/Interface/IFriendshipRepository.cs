using _3D_WebGame;
using _3D_WebGame.Configurations;
using _3D_WebGame.Interface;
using _3D_WebGame.Models;

namespace _3D_WebGame.Interface
{
    public interface IFriendshipRepository
    {
        
        Task<List<Friendship>> getAll(int userId);
        Task<Friendship> updateStatus(Friendship friendship);
    }
}

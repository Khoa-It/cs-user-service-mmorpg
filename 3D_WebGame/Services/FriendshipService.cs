using _3D_WebGame.DTOs.User;
using _3D_WebGame.Interface;
using _3D_WebGame.Models;
using _3D_WebGame.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _3D_WebGame.Services {
    public class FriendshipService {
        public FriendshipRepository friendshipRepository { get; set; }
        public IUserService userService { get; set; }
        public FriendshipService(FriendshipRepository io_ifriendshipRepository, IUserService io_userService) {
            friendshipRepository = io_ifriendshipRepository;
            userService = io_userService;
        }
        public async Task<List<Friendship>> getAllById(int userId) {
            return await friendshipRepository.getAllById(userId);
        }

        public async Task<Friendship> update(int userId1, int userId2) {
            var item = new Friendship() {
                userId1 = userId1,
                userId2 = userId2,
                sender = userId1,
            };
            var friendships = await friendshipRepository.find(userId1, userId2);
            if(friendships == null) {
                item.status = "pending";
                return await friendshipRepository.add(item);
            }
            item.status = "accepted";
            return await friendshipRepository.updateStatus(item);
        }

        public async Task<List<UserGetDto>> getFriends(int userId) {
            var friendships = await friendshipRepository.getAllById(userId);
            var result = new List<UserGetDto>();
            foreach (var item in friendships)
            {
                if (item.status == "accepted"){
                    int queryId = item.userId1 != userId ? item.userId1 : item.userId2;
                    result.Add(await userService.getById(queryId));
                }
            }
            return result;
        }

    }
}

using _3D_WebGame.DTOs.Friendship;
using _3D_WebGame.Models;
using _3D_WebGame.Responses;
using _3D_WebGame.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _3D_WebGame.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class FriendshipController : ControllerBase {
        FriendshipService friendshipService;
        string errorMes = "error - FriendshipController";
        string successMes = "success - FriendshipController";
        public FriendshipController(FriendshipService io_friendshipService) {
            friendshipService = io_friendshipService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getAll(int id){
            var data = await friendshipService.getAllById(id);
            return GameApiResponse.CreateResponse(data, successMes, errorMes);
        }

        [HttpGet("friends/{id}")]
        public async Task<IActionResult> getFriends(int id) {
            var data = await friendshipService.getFriends(id);
            return GameApiResponse.CreateResponse(data, successMes, errorMes);

        }

        [HttpPut]
        public async Task<IActionResult> update(FriendshipUpdateDto friendshipUpdateDto) {
            var data = await friendshipService.update(friendshipUpdateDto.userId1, friendshipUpdateDto.userId2);
            return GameApiResponse.CreateResponse(data, successMes, errorMes);
        }
    }
}

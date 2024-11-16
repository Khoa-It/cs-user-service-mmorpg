using _3D_WebGame.DTOs.User;
using _3D_WebGame.Interface;
using _3D_WebGame.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _3D_WebGame.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase {
        public IUserService iUserService { get; set; }
        public UserController(IUserService outiUserService) {
            iUserService = outiUserService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> getAll() {
            var data = await iUserService.getAll();
            return GameApiResponse.CreateResponse(data, "get all list data success", "list null");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getById(int id) {
            var data = await iUserService.getById(id);
            return GameApiResponse.CreateResponse(data, "find successfull", "not found user");
        }
        [HttpPost("account")]
        public async Task<IActionResult> getByAccount(AccountDto accountDto) {
            var data = await iUserService.getByAccount(accountDto);
            return GameApiResponse.CreateResponse(data, "get user by account success", "not found account");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> delete(int id) {
            var data = await iUserService.delete(id);
            return GameApiResponse.CreateResponse(data, "delete user successfull", "not found user to delete");
        }

        [HttpPut]
        public async Task<IActionResult> update(UserUpdateDto userUpdateDto) {
            var data = await iUserService.update(userUpdateDto);
            return GameApiResponse.CreateResponse(data, "update user successfull", "not found user to update");
        }

        [HttpPost]
        public async Task<IActionResult> create(UserCreateDto userCreateDto){
            var data = await iUserService.create(userCreateDto);
            return GameApiResponse.CreateResponse(data, "created user successfull", "error created user");

        }
    }
}

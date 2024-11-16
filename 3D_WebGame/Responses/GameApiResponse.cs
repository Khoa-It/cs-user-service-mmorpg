using Microsoft.AspNetCore.Mvc;

namespace _3D_WebGame.Responses {
    public class GameApiResponse {
        public static IActionResult CreateResponse(object? data, string successMessage, string failureMessage) {
            string message = data != null ? successMessage : failureMessage;
            return new ObjectResult(new { message, data });
        }
    }
}

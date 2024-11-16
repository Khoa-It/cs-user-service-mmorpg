namespace _3D_WebGame.Models {
    public class User {
        public int userId { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime lastLogin { get; set; }
    }
}

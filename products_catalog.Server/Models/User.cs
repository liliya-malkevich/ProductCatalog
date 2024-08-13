namespace products_catalog.Server.Models
{
    public class User
    {
        public int Id { get; set; }
        public string PswdHash { get; set; }
        public int RoleId { get; set; }
        public virtual Role? Role { get; set; }
        public string Email { get; set; }
    }
}

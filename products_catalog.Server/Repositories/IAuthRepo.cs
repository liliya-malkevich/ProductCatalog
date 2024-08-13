namespace products_catalog.Server.Repositories
{
    public interface IAuthRepo
    {
        public Task Login(string email, string password);
    }
}

using products_catalog.Server.Database;
using products_catalog.Server.Models;

namespace products_catalog.Server.Repositories.Impl
{
    public class UserRepo : IBaseRepo<User>
    {
        private ApplicationContext Context;
        public UserRepo(ApplicationContext context)
        {
            Context = context;
        }
        public async Task Create(User user)
        {
            await Context.Users.AddAsync(user);
            await Context.SaveChangesAsync();
        }

        public Task<User> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<User> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(User model)
        {
            throw new NotImplementedException();
        }
    }
}

namespace products_catalog.Server.Repositories
{
    public interface IBaseRepo<TDbModel>
    {
        public Task<IEnumerable<TDbModel>> Get();
        public Task<TDbModel> Get(int id);
        public Task Create(TDbModel model);
        public Task Update(TDbModel model);
        public Task<TDbModel> Delete(int id);
    }
}

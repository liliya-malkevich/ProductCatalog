namespace products_catalog.Server.Repositories
{
    public interface IBaseRepo<TDbModel>
    {
        public IEnumerable<TDbModel> Get();
        public TDbModel Get(int id);
        public void Create(TDbModel model);
        public void Update(TDbModel model);
        public TDbModel Delete(int id);
    }
}

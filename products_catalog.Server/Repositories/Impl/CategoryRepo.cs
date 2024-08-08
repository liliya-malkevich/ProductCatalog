using products_catalog.Server.Database;
using products_catalog.Server.Models;

namespace products_catalog.Server.Repositories.Impl
{
    public class CategoryRepo : IBaseRepo<CategoryItem>
    {
        private ApplicationContext Context;
        public CategoryRepo(ApplicationContext context)
        {
            Context = context;
        }
        public IEnumerable<CategoryItem> Get()
        {
            return Context.Categories;
        }
        public CategoryItem Get(int Id)
        {
            return Context.Categories.Find(Id);
        }

        public void Create(CategoryItem item)
        {
            Context.Categories.Add(item);
            Context.SaveChanges();
        }
        public void Update(CategoryItem item)
        {
            CategoryItem currentItem = Get(item.Id);
            currentItem.Name = item.Name;

            Context.Categories.Update(currentItem);
            Context.SaveChanges();
        }

        public CategoryItem Delete(int Id)
        {
            CategoryItem item = Get(Id);

            if (item != null)
            {
                Context.Categories.Remove(item);
                Context.SaveChanges();
            }

            return item;
        }
    }
}

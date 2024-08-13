using Microsoft.EntityFrameworkCore;
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
        public async Task<IEnumerable<CategoryItem>> Get()
        {
            return await Context.Categories.ToListAsync();
        }
        public async Task<CategoryItem> Get(int Id)
        {
            return await Context.Categories.FindAsync(Id);
        }

        public async Task Create(CategoryItem item)
        {
           await Context.Categories.AddAsync(item);
           await Context.SaveChangesAsync();
        }
        public async Task Update(CategoryItem item)
        {
            CategoryItem currentItem = await Get(item.Id);
            currentItem.Name = item.Name;

            Context.Categories.Update(currentItem);
            await Context.SaveChangesAsync();
        }

        public async Task<CategoryItem> Delete(int Id)
        {
            CategoryItem item = await Get(Id);

            if (item != null)
            {
                Context.Categories.Remove(item);
                await Context.SaveChangesAsync();
            }

            return item;
        }
    }
}

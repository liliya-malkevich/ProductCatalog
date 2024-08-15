using Microsoft.EntityFrameworkCore;
using products_catalog.Server.Database;
using products_catalog.Server.Models;

namespace products_catalog.Server.Repositories.Impl
{
    public class ProductRepo : IBaseRepo<Product>
    {
        private ApplicationContext Context;
        public ProductRepo(ApplicationContext context)
        {
            Context = context;
        }
        public async Task<IEnumerable<Product>> Get()
        {
            return await Context.Products.Include(x => x.CategoryItem).ToListAsync();
        }
        public async Task<Product> Get(int Id)
        {
            return await Context.Products.Include(x => x.CategoryItem).FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task Create(Product item)
        {
            item.CategoryItem = await Context.Categories.SingleAsync(x => x.Id == item.CategoryItemId);
           await Context.Products.AddAsync(item);
            await Context.SaveChangesAsync();
        }
        public async Task Update(Product item)
        {
            Product currentItem = await Get(item.Id);
            currentItem.Name = item.Name;
            currentItem.Price = item.Price;
            currentItem.CategoryItemId = item.CategoryItemId;
            currentItem.Note = item.Note;
            currentItem.NoteSpec = item.NoteSpec;
            currentItem.Description = item.Description;


            Context.Products.Update(currentItem);
            await Context.SaveChangesAsync();
        }

        public async Task<Product> Delete(int Id)
        {
            Product item = await Get(Id);

            if (item != null)
            {
                Context.Products.Remove(item);
                await Context.SaveChangesAsync();
            }

            return item;
        }
    
    }
}

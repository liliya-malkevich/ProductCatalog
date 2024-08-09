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
        public IEnumerable<Product> Get()
        {
            return Context.Products.Include(x => x.CategoryItem);
        }
        public Product Get(int Id)
        {
            return Context.Products.Include(x => x.CategoryItem).FirstOrDefault(x => x.Id == Id);
        }

        public void Create(Product item)
        {
            item.CategoryItem = Context.Categories.Single(x => x.Id == item.CategoryItemId);
            Context.Products.Add(item);
            Context.SaveChanges();
        }
        public void Update(Product item)
        {
            Product currentItem = Get(item.Id);
            currentItem.Name = item.Name;
            currentItem.Price = item.Price;
            currentItem.CategoryItemId = item.CategoryItemId;
            currentItem.Note = item.Note;
            currentItem.NoteSpec = item.NoteSpec;



            Context.Products.Update(currentItem);
            Context.SaveChanges();
        }

        public Product Delete(int Id)
        {
            Product item = Get(Id);

            if (item != null)
            {
                Context.Products.Remove(item);
                Context.SaveChanges();
            }

            return item;
        }
    
    }
}

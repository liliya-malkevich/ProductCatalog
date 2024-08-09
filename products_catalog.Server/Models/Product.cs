using System.Text.Json.Serialization;

namespace products_catalog.Server.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int CategoryItemId { get; set; }
        
        public virtual CategoryItem? CategoryItem { get; set; }
        public string? Description { get; set; }
        public string? Price { get; set; }
        public string? Note { get; set; }
        public string? NoteSpec { get; set; }
    }
}

using Core.Entities.Abstract;

namespace Entities.Concrete.TableModel
{
    public class Tag:BaseEntity
    {
        public string Name {  get; set; }
        public ICollection<Blog> Blogs { get; set; }
        public ICollection<TagBlog> TagBlogs { get; set; } 
    }
}

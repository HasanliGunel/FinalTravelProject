using Core.Entities.Abstract;

namespace Entities.Concrete.TableModel
{
    public class Blog:BaseEntity
    {
        
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhotoUrl {  get; set; }  
        public string Text {  get; set; }
        public bool IsHome {  get; set; }   
        public int CategoryOfBlogID { get; set; }
        public virtual CategoryOfBlog CategoryOfBlog { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public ICollection<TagBlog> TagBlogs { get; } = [];
        
    }
}

using Core.Entities.Abstract;

namespace Entities.Concrete.TableModel
{
    public class TagBlog:BaseEntity
    {
        public int BlogId { get; set; }
        public int TagID { get; set; }
        public Blog Blog { get; set; }
        public Tag Tag { get; set; }
    }
}

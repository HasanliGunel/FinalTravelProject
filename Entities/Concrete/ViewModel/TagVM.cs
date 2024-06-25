using Entities.Concrete.TableModel;

namespace Entities.Concrete.ViewModel
{
    public class TagVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<TagBlogVM> TagBlogVMs { get; set; }
    }
}

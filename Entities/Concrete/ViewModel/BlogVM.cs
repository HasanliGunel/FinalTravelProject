using Entities.Concrete.TableModel;

namespace Entities.Concrete.ViewModel
{
    public class BlogVM
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string PhotoUrl { get; set; }
        public string Text { get; set; }
        public bool IsHome { get; set; }
        public int CategoryOfBlogID { get; set; }
        public ICollection<TagBlogVM> TagBlogVMs { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
}

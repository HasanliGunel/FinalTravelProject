using Entities.Concrete.Dtos;
using Entities.Concrete.TableModel;
using Entities.Concrete.ViewModel;

namespace TravelWebUI.ViewModels
{
    public class BlogViewModel
    {
        public List<TagBlogVM> Blogs { get; set; }
        //public List<TagVM> Tags { get; set; }
        public List<TagVM> Tags { get; set; }
        public List<CategoryOfBlog> categoryOfBlogs { get; set; }
        public BlogVM Blog { get; set; }
        public ICollection<TagBlogVM> Comments {  get; set; }
    }
}

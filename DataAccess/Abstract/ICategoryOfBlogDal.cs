using Core.DataAccess.Abstract;
using Entities.Concrete.TableModel;
using Entities.Concrete.ViewModel;

namespace DataAccess.Abstract
{
    public interface ICategoryOfBlogDal : IBaseRepository<CategoryOfBlog> 
    {
        TagVM GetByIDCategoryWithBlog(int id);
    }



}

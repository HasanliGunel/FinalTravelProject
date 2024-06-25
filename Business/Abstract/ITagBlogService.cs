using Core.Result.Abstract;
using Entities.Concrete.TableModel;
using Entities.Concrete.ViewModel;

namespace Business.Abstract
{
    public interface ITagBlogService
    {
        IDataResult<TagBlogVM> GetByIdBlogWithTags(int id);
        IDataResult<List<TagBlogVM>> GetAllBlogWithTags();
    }
}

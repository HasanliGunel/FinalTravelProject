using Core.Result.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModel;
using Entities.Concrete.ViewModel;

namespace Business.Abstract
{
    public interface ICategoryOfBlogService
    {
        IResult Add(CategoryOfBlogCreateDto dto);
        IResult Update(CategoryOfBlogUpdateDto dto);
        IResult Delete(int id);
        IDataResult<List<CategoryOfBlog>> GetAll();
        IDataResult<CategoryOfBlog> GetbyId(int id);
        IDataResult<TagVM> GetbyIdCategoryWithDetails(int id);
    }
}

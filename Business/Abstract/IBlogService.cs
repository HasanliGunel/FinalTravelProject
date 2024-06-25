using Core.Result.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModel;
using Entities.Concrete.ViewModel;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IBlogService
    {
        IResult Add(BlogCreateDto dto, IFormFile photoUrl, string webRootPath);
        IResult Update(BlogUpdateDto dto, IFormFile photoUrl, string webRootPath);
        IResult Delete(int id);
        IDataResult<List<BlogDto>> GetBlogWithCategoryID();
        IDataResult<List<BlogVM>> GetBlogWithDetails();
        IDataResult<Blog> GetbyId(int id);
        IDataResult<BlogVM> GetbyIdBlogWithDetail(int id);
        
    }
}

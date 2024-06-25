using Core.Result.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModel;
using Entities.Concrete.ViewModel;

namespace Business.Abstract
{
    public interface ITagService
    {
        IResult Add(TagCreateDto dto);
        IResult Update(TagUpdateDto dto);
        IResult Delete(int id);
        IDataResult<List<Tag>> GetAll();
        IDataResult<List<TagVM>> GetAllTagWithDetails();
        IDataResult<Tag> GetbyId(int id);
        IDataResult<TagVM> GetbyIdTagWithDetails(int id);
        //List<BlogDto> GETBlog(int id);
    }
}

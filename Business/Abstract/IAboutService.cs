using Core.Result.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModel;

namespace Business.Abstract
{
    public interface IAboutService
    {
        IResult Add(AboutCreateDto dto);
        IResult Update(AboutUpdateDto dto);
        IDataResult<List<About>> GetAll();
        IDataResult<About> GetbyId(int id);
    }
}

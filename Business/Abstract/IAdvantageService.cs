using Core.Result.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModel;

namespace Business.Abstract
{
    public interface IAdvantageService
    {
        IResult Add(AdvantageCreateDto dto);
        IResult Update(AdvantageUpdateDto dto);
        IResult Delete(int id);
        IDataResult<List<Advantage>> GetAll();
        IDataResult<Advantage> GetbyId(int id);
    }
}

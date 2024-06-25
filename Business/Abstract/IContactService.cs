using Core.Result.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModel;

namespace Business.Abstract
{
    public interface IContactService
    {
        IResult Add(ContactCreateDto dto);
        IResult Update(ContactUpdateDto dto);
        IResult Delete(int id);
        IDataResult<List<Contact>> GetAll();
        IDataResult<Contact> GetbyId(int id);
    }
}

using Core.Result.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModel;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IDestinationService
    {
        IResult Add(DestinationCreateDto dto, IFormFile photoUrl, string webRootPath);
        IResult Update(DestinationUpdateDto dto, IFormFile photoUrl, string webRootPath);
        IResult Delete(int id);
        IDataResult<List<Destination>> GetAll();
        IDataResult<Destination> GetbyId(int id);
    }
}

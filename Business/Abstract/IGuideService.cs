using Core.Result.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModel;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IGuideService
    {
        IResult Add(GuideCreateDto dto, IFormFile photoUrl, string webRootPath);
        IResult Update(GuideUpdateDto dto, IFormFile photoUrl, string webRootPath);
        IResult Delete(int id);
        IDataResult<List<Guide>> GetAll();
        IDataResult<Guide> GetbyId(int id);
    }
}

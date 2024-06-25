using Core.Result.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModel;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IPackageService
    {
        IResult Add(PackageCreateDto dto, IFormFile photoUrl, string webRootPath);
        IResult Update(PackageUpdateDto dto, IFormFile photoUrl, string webRootPath);
        IResult Delete(int id);
        IDataResult<List<PackageDto>> GetPackagesWithDestinationID();
        IDataResult<Package> GetbyId(int id);
    }
}

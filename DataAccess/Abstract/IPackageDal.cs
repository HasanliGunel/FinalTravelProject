using Core.DataAccess.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModel;

namespace DataAccess.Abstract
{
    public interface IPackageDal : IBaseRepository<Package> 
    {
        List<PackageDto> GetPackagesWithDestinations();
    }



}

using Core.Result.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IServiceService
    {
        IResult Add(ServiceCreateDto dto);
        IResult Update(ServiceUpdateDto dto);
        IResult Delete(int id);
        IDataResult<List<Service>> GetAll();
        IDataResult<Service> GetbyId(int id);
    }
}

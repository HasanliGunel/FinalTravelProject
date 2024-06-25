using Core.Result.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IHomeSlideService
    {
        IResult Add(HomeSlideCreateDto dto, IFormFile photoUrl, string webRootPath);
        IResult Update(HomeSlideUpdateDto dto, IFormFile photoUrl, string webRootPath);
        IResult Delete(int id);
        IDataResult<List<HomeSlide>> GetAll();
        IDataResult<HomeSlide> GetbyId(int id);
    }
}

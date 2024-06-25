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
    public interface ITestimonialService
    {
        IResult Add(TestimonialCreateDto dto, IFormFile photoUrl, string webRootPath);
        IResult Update(TestimonialUpdateDto dto, IFormFile photoUrl, string webRootPath);
        IResult Delete(int id);
        IDataResult<List<Testimonial>> GetAll();
        IDataResult<Testimonial> GetbyId(int id);
    }
}

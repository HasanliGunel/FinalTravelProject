using Business.Abstract;
using Business.BaseMessages;
using Business.Validations;
using Core.Extension;
using Core.Result.Abstract;
using Core.Result.Contrete;
using Core.Validation;
using DataAccess.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModel;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class TestimonialManager : ITestimonialService
    {
        private readonly ITestimonialDal _testimonialDal;
        private readonly IValidator<Testimonial> _validator;

        public TestimonialManager(ITestimonialDal testimonialDal, IValidator<Testimonial> validator)
        {
            _testimonialDal = testimonialDal;
            _validator = validator;
        }

        public IResult Add(TestimonialCreateDto dto, IFormFile photoUrl, string webRootPath)
        {
            var model = TestimonialCreateDto.ToTestimonial(dto);
            model.PhotoUrl = PictureHelper.UploadImage(photoUrl, webRootPath);

            var validator = ValidationTool.Validate(new TestimonialValidation(), model, out List<ValidationErrorModel> error);

            if (!validator)
            {
                return new ErrorResult(error.ValidationErrorMessagesWithNewLine());
            }

            _testimonialDal.Add(model);

            return new SuccessResult(UIMessages.ADDED_MESSAGE);
        }
        public IResult Update(TestimonialUpdateDto dto, IFormFile photoUrl, string webRootPath)
        {
            var model = TestimonialUpdateDto.ToTestimonial(dto);

            var existData = GetbyId(model.ID).Data;

            if (photoUrl != null)
                model.PhotoUrl = PictureHelper.UploadImage(photoUrl, webRootPath);

            else
                model.PhotoUrl = existData.PhotoUrl;

            _testimonialDal.Update(model);

            return new SuccessResult(UIMessages.UPDATE_MESSAGE);
        }
        public IResult Delete(int id)
        {
            var data = GetbyId(id).Data;
            data.Deleted = id;

            _testimonialDal.Update(data); 

            return new SuccessResult(UIMessages.Deleted_MESSAGE);
        }

        public IDataResult<Testimonial> GetbyId(int id)
        {
            return new SuccessDataResult<Testimonial>(_testimonialDal.GetbyId(id));
        }

        public IDataResult<List<Testimonial>> GetAll()
        {
            return new SuccessDataResult<List<Testimonial>>(_testimonialDal.GetAll(x => x.Deleted == 0));
        }


    }
}

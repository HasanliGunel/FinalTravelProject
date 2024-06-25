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
    public class HomeSlideManager : IHomeSlideService
    {
        private readonly IHomeSlideDal _homeSlideDal;
        private readonly IValidator<HomeSlide> _validator;

        public HomeSlideManager(IHomeSlideDal homeSlideDal, IValidator<HomeSlide> validator)
        {
            _homeSlideDal = homeSlideDal;
            _validator = validator;
        }
        public IResult Add(HomeSlideCreateDto dto, IFormFile photoUrl, string webRootPath)
        {
            var model = HomeSlideCreateDto.ToHomeSlide(dto);

            model.PhotoUrl = PictureHelper.UploadImage(photoUrl, webRootPath);

            var validator = ValidationTool.Validate(new HomeSlideValidation(), model, out List<ValidationErrorModel> error);
            if (!validator)
            {
                return new ErrorResult(error.ValidationErrorMessagesWithNewLine());
            }

            _homeSlideDal.Add(model);

            

            return new SuccessResult(UIMessages.ADDED_MESSAGE);
        }
        public IResult Update(HomeSlideUpdateDto dto, IFormFile photoUrl, string webRootPath)
        {
            var model = HomeSlideUpdateDto.ToHomeSlide(dto);

            var exixtData = GetbyId(model.ID).Data;
            model.LastUpdateDate = DateTime.Now;    

            if(photoUrl == null)
            {
                model.PhotoUrl = exixtData.PhotoUrl;
            }
            else
                model.PhotoUrl = PictureHelper.UploadImage(photoUrl,webRootPath);

            _homeSlideDal.Update(model);
            return new SuccessResult(UIMessages.UPDATE_MESSAGE);
        }
        public IResult Delete(int id)
        {
            var data = GetbyId(id).Data;

            data.Deleted = id;

            _homeSlideDal.Delete(data); 

            return new SuccessResult(UIMessages.Deleted_MESSAGE);
        }

        public IDataResult<List<HomeSlide>> GetAll()
        {
            return new SuccessDataResult<List<HomeSlide>>(_homeSlideDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<HomeSlide> GetbyId(int id)
        {
            return new SuccessDataResult<HomeSlide>(_homeSlideDal.GetbyId(id));
        }

        
    }
}

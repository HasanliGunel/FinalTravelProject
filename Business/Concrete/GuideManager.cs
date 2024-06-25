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
    public class GuideManager : IGuideService
    {
        private readonly IGuideDal _guideDal;
        private readonly IValidator<Guide> _validator;  

        public GuideManager(IGuideDal guideDal, IValidator<Guide> validator)
        {
            _guideDal = guideDal;
            _validator = validator; 
        }

        public IResult Add(GuideCreateDto dto, IFormFile photoUrl, string webRootPath)
        {
            var model = GuideCreateDto.ToGuide(dto);

            model.PhotoUrl = PictureHelper.UploadImage(photoUrl, webRootPath);

            var validator = ValidationTool.Validate(new GuideValidation(), model, out List<ValidationErrorModel> error);
            if (!validator)
            {
                return new ErrorResult(error.ValidationErrorMessagesWithNewLine());
            }

            _guideDal.Add(model);

            return new SuccessResult(UIMessages.ADDED_MESSAGE);
        }
        public IResult Update(GuideUpdateDto dto, IFormFile photoUrl, string webRootPath)
        {
            var model = GuideUpdateDto.ToGuide(dto);

            var existData = GetbyId(model.ID).Data; ;
            
            if(photoUrl == null)
            {
                model.PhotoUrl = existData.PhotoUrl;
            }
            else
            {
                model.PhotoUrl = PictureHelper.UploadImage(photoUrl, webRootPath);
            }
            model.LastUpdateDate = DateTime.Now;

            _guideDal.Update(model);

            return new SuccessResult(UIMessages.UPDATE_MESSAGE);
        }
        public IResult Delete(int id)
        {
            var data = GetbyId(id).Data;

            data.Deleted = id;
            _guideDal.Update(data);

            return new SuccessResult(UIMessages.Deleted_MESSAGE);   
        }

        public IDataResult<List<Guide>> GetAll()
        {
            return new SuccessDataResult<List<Guide>>(_guideDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<Guide> GetbyId(int id)
        {
            return new SuccessDataResult<Guide>(_guideDal.GetbyId(id));
        }

        
    }
}

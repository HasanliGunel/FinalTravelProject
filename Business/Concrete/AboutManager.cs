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

namespace Business.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;
        private readonly IValidator<About> _validator;
        public AboutManager(IAboutDal aboutDal, IValidator<About> validator)
        {
            _aboutDal = aboutDal;
            _validator = validator;
        }
        public IResult Add(AboutCreateDto dto)
        {
            var model = AboutCreateDto.ToAbout(dto);

            //var validator = _validator.Validate(model);

            //string errorMessage = "";

            //foreach(var item in validator.Errors)
            //{
            //    errorMessage = item.ErrorMessage;
            //}
            var validator = ValidationTool.Validate(new AboutValidation(), model, out List<ValidationErrorModel> error);
            
            if (!validator)
            {
                return new ErrorResult(error.ValidationErrorMessagesWithNewLine());
            }

            _aboutDal.Add(model);

            return new SuccessResult(UIMessages.ADDED_MESSAGE);
        }

        public IDataResult<List<About>> GetAll()
        {
            return new SuccessDataResult<List<About>>(_aboutDal.GetAll());
        }

        public IDataResult<About> GetbyId(int id)
        {
            return new SuccessDataResult<About>(_aboutDal.GetbyId(id));
        }

        public IResult Update(AboutUpdateDto dto)
        {
            var model = AboutUpdateDto.ToAbout(dto);

            model.LastUpdateDate = DateTime.Now;
            _aboutDal.Update(model);

            return new SuccessResult(UIMessages.UPDATE_MESSAGE);
        }
    }
}

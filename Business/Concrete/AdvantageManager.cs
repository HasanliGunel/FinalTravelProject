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
    public class AdvantageManager : IAdvantageService
    {
        private readonly IAdvantageDal _advantageDal;
        private readonly IValidator<Advantage> _validator;
       
        public AdvantageManager(IAdvantageDal advantageDal, IValidator<Advantage> validator)
        {
            _advantageDal = advantageDal;
            _validator = validator;
        }
        public IResult Add(AdvantageCreateDto dto)
        {
            var model = AdvantageCreateDto.ToAdvantage(dto);

            //var validator = _validator.Validate(model);

            //string errorMessage = "";

            //foreach(var item in validator.Errors)
            //{
            //    errorMessage = item.ErrorMessage;
            //}
            var validator = ValidationTool.Validate(new AdvantageValidation(), model, out List<ValidationErrorModel> error);

            if (!validator)
            {
                return new ErrorResult(error.ValidationErrorMessagesWithNewLine());
            }

            _advantageDal.Add(model);

            return new SuccessResult(UIMessages.ADDED_MESSAGE);
        }

        public IResult Update(AdvantageUpdateDto dto)
        {
            var model = AdvantageUpdateDto.ToAdvantage(dto);
            model.LastUpdateDate = DateTime.Now;

            _advantageDal.Update(model);

            return new SuccessResult(UIMessages.UPDATE_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetbyId(id).Data;
            data.Deleted = id;

            _advantageDal.Update(data);

            return new SuccessResult(UIMessages.Deleted_MESSAGE);
        }

        public IDataResult<List<Advantage>> GetAll()
        {
            return new SuccessDataResult<List<Advantage>>(_advantageDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<Advantage> GetbyId(int id)
        {
            return new SuccessDataResult<Advantage>(_advantageDal.GetbyId(id));
        }


    }
}

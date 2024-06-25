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
    public class ServiceManager : IServiceService
    {
        private readonly IServiceDal _serviceDal;
        private readonly IValidator<Service> _validator;
        public ServiceManager(IServiceDal serviceDal, IValidator<Service> validator)
        {
            _serviceDal = serviceDal;
            _validator = validator;
        }
        public IResult Add(ServiceCreateDto dto)
        {
            var model = ServiceCreateDto.ToService(dto);

            var validator = ValidationTool.Validate(new ServiceValidation(), model, out List<ValidationErrorModel> error);

            if (!validator)
            {
                return new ErrorResult(error.ValidationErrorMessagesWithNewLine());
            }
            return new SuccessResult(UIMessages.ADDED_MESSAGE);
        }
        public IResult Update(ServiceUpdateDto dto)
        {
            var model = ServiceUpdateDto.ToService(dto);

            model.LastUpdateDate = DateTime.Now;

            _serviceDal.Update(model);

            return new SuccessResult(UIMessages.UPDATE_MESSAGE);
        }
        public IResult Delete(int id)
        {
            var data = GetbyId(id).Data;

            data.Deleted = id;

            _serviceDal.Update(data);

            return new SuccessResult(UIMessages.Deleted_MESSAGE);
        }

        public IDataResult<List<Service>> GetAll()
        {
            var data = _serviceDal.GetAll();
            return new SuccessDataResult<List<Service>>(_serviceDal.GetAll(x => x.Deleted == 0));

        }

        public IDataResult<Service> GetbyId(int id)
        {
            return new SuccessDataResult<Service>(_serviceDal.GetbyId(id));
        }


    }
}

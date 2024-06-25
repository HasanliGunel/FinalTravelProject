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
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class DestinationManager : IDestinationService
    {
        //DestinationDal _destinationDal = new();
        // validasiyalar burda yazilir.

        private readonly IDestinationDal _destinationDal;
        public DestinationManager(IDestinationDal destinationDal)
        {
            _destinationDal = destinationDal;
        }
        public IResult Add(DestinationCreateDto dto, IFormFile photoUrl, string webRootPath)
        {
            var model = DestinationCreateDto.ToDestination(dto);
            model.PhotoUrl = PictureHelper.UploadImage(photoUrl, webRootPath);

            var validator = ValidationTool.Validate(new DestinationValidation(), model, out List<ValidationErrorModel> error);
            if (!validator)
            {
                return new ErrorResult(error.ValidationErrorMessagesWithNewLine());
            }
            _destinationDal.Add(model);

            return new SuccessResult(UIMessages.ADDED_MESSAGE);
        }
        public IResult Update(DestinationUpdateDto dto, IFormFile photoUrl, string webRootPath)
        {
            var model = DestinationUpdateDto.ToDestination( dto);
            var exisData = GetbyId(model.ID).Data;

            if (photoUrl == null)
            {
                model.PhotoUrl = exisData.PhotoUrl;
            }
            else
            {
                model.PhotoUrl = PictureHelper.UploadImage(photoUrl, webRootPath);
            }
            model.LastUpdateDate = DateTime.Now;

            _destinationDal.Update(model);

            return new SuccessResult(UIMessages.UPDATE_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetbyId(id).Data;
            data.Deleted = id;

            _destinationDal.Update(data);

            return new SuccessResult(UIMessages.Deleted_MESSAGE);
        }

        public IDataResult<List<Destination>> GetAll()
        {
            return new SuccessDataResult<List<Destination>>(_destinationDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<Destination> GetbyId(int id)
        {
            return new SuccessDataResult<Destination>(_destinationDal.GetbyId(id));
        }


    }
}

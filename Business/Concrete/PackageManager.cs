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
    public class PackageManager : IPackageService
    {
        //PackageDal _packageDal = new();

        private readonly IPackageDal _packageDal;
        public PackageManager(IPackageDal packageDal)
        {
            _packageDal = packageDal;
        }
        public IResult Add(PackageCreateDto dto, IFormFile photoUrl, string webRootPath)
        {
            var model = PackageCreateDto.ToPackage(dto);

            model.PhotoUrl = PictureHelper.UploadImage(photoUrl, webRootPath);

            var validator = ValidationTool.Validate(new PackageValidation(), model, out List<ValidationErrorModel> error);

            if (!validator)
            {
                return new ErrorResult(error.ValidationErrorMessagesWithNewLine());
            }
            _packageDal.Add(model);

            return new SuccessResult(UIMessages.ADDED_MESSAGE);
        }

        public IResult Update(PackageUpdateDto dto, IFormFile photoUrl, string webRootPath)
        {
            var model = PackageUpdateDto.ToPackage(dto);
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

            _packageDal.Update(model);

            return new SuccessResult(UIMessages.UPDATE_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetbyId(id).Data;
            data.Deleted = id;

            _packageDal.Update(data);

            return new SuccessResult(UIMessages.Deleted_MESSAGE);
        }


        public IDataResult<Package> GetbyId(int id)
        {
            return new SuccessDataResult<Package>(_packageDal.GetbyId(id));
        }

        public IDataResult<List<PackageDto>> GetPackagesWithDestinationID()
        {
            return new SuccessDataResult<List<PackageDto>>(_packageDal.GetPackagesWithDestinations());
        }
    }
}

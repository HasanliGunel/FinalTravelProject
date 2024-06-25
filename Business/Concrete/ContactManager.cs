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
using static System.Net.Mime.MediaTypeNames;

namespace Business.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;
        private readonly IValidator<Contact> _validator;

        public ContactManager(IContactDal contactDal, IValidator<Contact> validator)
        {
            _contactDal = contactDal;
            _validator = validator;
        }

        public IResult Add(ContactCreateDto dto)
        {
            var model = ContactCreateDto.ToContact(dto);

            var validator = ValidationTool.Validate(new ContactValidation(), model, out List<ValidationErrorModel> error);
            if (!validator)
            {
                return new ErrorResult(error.ValidationErrorMessagesWithNewLine());
            }
            _contactDal.Add(model);
            return new SuccessResult(UIMessages.ADDED_MESSAGE);
        }

        public IResult Update(ContactUpdateDto dto)
        {
            var model = ContactUpdateDto.ToContact(dto);
            model.LastUpdateDate = DateTime.Now;

            _contactDal.Update(model);

            return new SuccessResult(UIMessages.UPDATE_MESSAGE);
        }
        
        public IResult Delete(int id)
        {
            var data = GetbyId(id).Data;
            data.Deleted = id;

            _contactDal.Update(data);

            return new SuccessResult (UIMessages.Deleted_MESSAGE);
        }

        public IDataResult<List<Contact>> GetAll()
        {
            return new SuccessDataResult<List<Contact>>(_contactDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<Contact> GetbyId(int id)
        {
            return new SuccessDataResult<Contact>(_contactDal.GetbyId(id));
        }
    }
}

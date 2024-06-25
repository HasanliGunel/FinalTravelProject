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
using Entities.Concrete.ViewModel;
using FluentValidation;

namespace Business.Concrete
{
    public class TagManager : ITagService
    {
        private readonly ITagDal _tagDal;
        private readonly IValidator<Tag> _tagValidator;

        public TagManager(ITagDal tagDal, IValidator<Tag> tagValidator)
        {
            _tagDal = tagDal;
            _tagValidator = tagValidator;
        }

        public IResult Add(TagCreateDto dto)
        {
            var model = TagCreateDto.ToTag(dto);

            var validator = ValidationTool.Validate(new TagValidation(), model, out List<ValidationErrorModel> error);

            if (!validator)
            {
                return new ErrorResult(error.ValidationErrorMessagesWithNewLine());
            }

            _tagDal.Add(model);

            return new SuccessResult(UIMessages.ADDED_MESSAGE);

        }
        public IResult Update(TagUpdateDto dto)
        {
            var model = TagUpdateDto.ToTag(dto);

            model.LastUpdateDate = DateTime.Now;

            _tagDal.Update(model);

            return new SuccessResult(UIMessages.UPDATE_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetbyId(id).Data;

            data.Deleted = id;

            _tagDal.Update(data);

            return new SuccessResult(UIMessages.Deleted_MESSAGE);
        }

        public IDataResult<List<Tag>> GetAll()
        {
            return new SuccessDataResult<List<Tag>>(_tagDal.GetAll(x=>x.Deleted == 0));
        }

        public IDataResult<Tag> GetbyId(int id)
        {
            return new SuccessDataResult<Tag>(_tagDal.GetbyId(id));
        }

        public IDataResult<List<TagVM>> GetAllTagWithDetails()
        {
            return new SuccessDataResult<List<TagVM>>(_tagDal.GetAllTagWithBlog());
        }

        public IDataResult<TagVM> GetbyIdTagWithDetails(int id)
        {
            return new SuccessDataResult<TagVM>(_tagDal.GetByIDTagWithBlog(id));
        }

        //public List<BlogDto> GETBlog(int id)
        //{
        //    return _tagDal.GETBlog(id);
        //}
    }
}

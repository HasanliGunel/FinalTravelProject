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
    public class CategoryOfBlogManager : ICategoryOfBlogService
    {
        private readonly ICategoryOfBlogDal _categoryOfBlogDal;
        private readonly IValidator<CategoryOfBlog> _validator;

        public CategoryOfBlogManager(ICategoryOfBlogDal categoryOfBlogDal, IValidator<CategoryOfBlog> validator)
        {
            _categoryOfBlogDal = categoryOfBlogDal;
            _validator = validator;
        }
        public IResult Add(CategoryOfBlogCreateDto dto)
        {
            var model = CategoryOfBlogCreateDto.ToCategoryOfBlog(dto);

            var validator = ValidationTool.Validate(new CategoryOfBlogValidation(), model, out List<ValidationErrorModel> error);
            if (!validator)
            {
                return new ErrorResult(error.ValidationErrorMessagesWithNewLine());
            }

            _categoryOfBlogDal.Add(model);

            return new SuccessResult(UIMessages.ADDED_MESSAGE);
        }
        public IResult Update(CategoryOfBlogUpdateDto dto)
        {
            var model = CategoryOfBlogUpdateDto.ToCategoryOfBlog(dto);

            model.LastUpdateDate = DateTime.Now;    

            _categoryOfBlogDal.Update(model);

            return new SuccessResult(UIMessages.UPDATE_MESSAGE);    
        }
        public IResult Delete(int id)
        {
            var data = GetbyId(id).Data;

            data.Deleted = id;

            _categoryOfBlogDal.Update(data);

            return new SuccessResult(UIMessages.Deleted_MESSAGE);   
        }
        public IDataResult<List<CategoryOfBlog>> GetAll()
        {
            return new SuccessDataResult<List<CategoryOfBlog>>(_categoryOfBlogDal.GetAll(x=>x.Deleted == 0));
        }
        

        public IDataResult<CategoryOfBlog> GetbyId(int id)
        {
            return new SuccessDataResult<CategoryOfBlog>(_categoryOfBlogDal.GetbyId(id));   
        }

        public IDataResult<TagVM> GetbyIdCategoryWithDetails(int id)
        {
            return new SuccessDataResult<TagVM>(_categoryOfBlogDal.GetByIDCategoryWithBlog(id));
        }
    }
}

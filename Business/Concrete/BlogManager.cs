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
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class BlogManager:IBlogService
    {
        private readonly IBlogDal _blogDal;
        private readonly IValidator<Blog> _validator;
        private readonly ITagDal _tagDal;
        public BlogManager(IBlogDal blogDal, IValidator<Blog> validator, ITagDal tagDal)
        {
            _blogDal = blogDal;
            _validator = validator;
            _tagDal = tagDal;
        }

        public IResult Add(BlogCreateDto dto, IFormFile photoUrl, string webRootPath)
        {
            var model = BlogCreateDto.ToBlog(dto);

            model.PhotoUrl = PictureHelper.UploadImage(photoUrl, webRootPath);

            //var validator = _validator.Validate(model);


            //string errorMessage = "";

            //foreach (var error in validator.Errors)
            //{
            //    errorMessage = error.ErrorMessage;
            //}

            //if (!validator.IsValid)
            //{
            //    return new ErrorResult(errorMessage);
            //}
            var validator = ValidationTool.Validate(new BlogValidation(), model, out List<ValidationErrorModel> error);
            if (!validator)
            {
                return new ErrorResult(error.ValidationErrorMessagesWithNewLine());
            }
            _blogDal.Add(model);
            _blogDal.AddWithTag(model, dto);

            return new SuccessResult(UIMessages.ADDED_MESSAGE);
        }

        public IResult Update(BlogUpdateDto dto, IFormFile photoUrl, string webRootPath)
        {
            var model = BlogUpdateDto.ToBlog(dto);

            var existData = GetbyId(model.ID).Data;

            if(photoUrl == null)
            {
                model.PhotoUrl = existData.PhotoUrl;
            }
            else
            {
                model.PhotoUrl = PictureHelper.UploadImage(photoUrl, webRootPath);
            }

            model.LastUpdateDate = DateTime.Now;
            _blogDal.Update(model);
            _blogDal.UpdateWithTag(model, dto);

            return new SuccessResult(UIMessages.UPDATE_MESSAGE);    
        }
        public IResult Delete(int id)
        {
            var data = GetbyId(id).Data;

            data.Deleted = id;

            _blogDal.Update(data);

            return new SuccessResult(UIMessages.Deleted_MESSAGE);
        }

        public IDataResult<Blog> GetbyId(int id)
        {
            return new SuccessDataResult<Blog>(_blogDal.GetbyId(id));
        }

        public IDataResult<List<BlogDto>> GetBlogWithCategoryID()
        {
            return new SuccessDataResult<List<BlogDto>>(_blogDal.GetBlogWithCategories());
        }

        public IDataResult<List<BlogVM>> GetBlogWithDetails()
        {
            return new SuccessDataResult<List<BlogVM>>(_blogDal.GetAllBlogWithTag());
        }

        public IDataResult<BlogVM> GetbyIdBlogWithDetail(int id)
        {
            return new SuccessDataResult<BlogVM>(_blogDal.GetByIDBlogWithTag(id));
        }
    }
}

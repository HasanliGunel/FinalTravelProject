using Business.Abstract;
using Core.Result.Abstract;
using Core.Result.Contrete;
using DataAccess.Abstract;
using Entities.Concrete.TableModel;
using Entities.Concrete.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TagBlogManager : ITagBlogService
    {
        private readonly ITagBlogDal _tagBlogDal;

        public TagBlogManager(ITagBlogDal tagBlogDal)
        {
            _tagBlogDal = tagBlogDal;
        }

        public IDataResult<List<TagBlogVM>> GetAllBlogWithTags()
        {
            return new SuccessDataResult<List<TagBlogVM>>(_tagBlogDal.GetAllBlogTag());
        }

        public IDataResult<TagBlog> GetById(int id)
        {

            return new SuccessDataResult<TagBlog>(_tagBlogDal.GetbyId(id));
        }

        public IDataResult<TagBlogVM> GetByIdBlogWithTags(int id)
        {
            return new SuccessDataResult<TagBlogVM>(_tagBlogDal.GetByIDBlogTag(id));
        }
    }
}

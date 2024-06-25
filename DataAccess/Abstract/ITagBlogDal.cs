using Core.DataAccess.Abstract;
using Entities.Concrete.TableModel;
using Entities.Concrete.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ITagBlogDal: IBaseRepository<TagBlog>
    {
        List<TagBlogVM> GetAllBlogTag();

        TagBlogVM GetByIDBlogTag(int id);
    }
}

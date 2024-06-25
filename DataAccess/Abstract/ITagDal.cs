using Core.DataAccess.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModel;
using Entities.Concrete.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ITagDal:IBaseRepository<Tag>
    {
        List<TagVM> GetAllTagWithBlog();

        TagVM GetByIDTagWithBlog(int id);
        //List<BlogDto> GETBlog(int id);
    }
}

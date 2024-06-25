using Core.DataAccess.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModel;
using Entities.Concrete.ViewModel;

namespace DataAccess.Abstract
{
    public interface IBlogDal : IBaseRepository<Blog> 
    {
        List<BlogDto> GetBlogWithCategories();
        void AddWithTag(Blog blog,BlogCreateDto dto);

        void UpdateWithTag(Blog blog,BlogUpdateDto dto);

        List<BlogVM> GetAllBlogWithTag();

        BlogVM GetByIDBlogWithTag(int id);
        //List<BlogDto> GetByIdCategory(int id);
    }



}

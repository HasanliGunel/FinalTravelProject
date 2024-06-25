using Entities.Concrete.TableModel;

namespace Entities.Concrete.Dtos
{
    public class CategoryOfBlogCreateDto
    {
        public string Name { get; set; }

        public static CategoryOfBlog ToCategoryOfBlog(CategoryOfBlogCreateDto dto)
        {
            CategoryOfBlog categoryOfBlog = new CategoryOfBlog()
            {
                Name = dto.Name
            };

            return categoryOfBlog;
        }
    }
}

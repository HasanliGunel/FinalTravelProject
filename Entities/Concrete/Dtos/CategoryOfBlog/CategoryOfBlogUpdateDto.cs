using Entities.Concrete.TableModel;

namespace Entities.Concrete.Dtos
{
    public class CategoryOfBlogUpdateDto
    {
        public int  ID { get; set; }
        public string Name { get; set; }

        public static CategoryOfBlog ToCategoryOfBlog(CategoryOfBlogUpdateDto dto)
        {
            CategoryOfBlog categoryOfBlog = new CategoryOfBlog()
            {
                ID = dto.ID,
                Name = dto.Name,
            };

            return categoryOfBlog;
        }
    }
}

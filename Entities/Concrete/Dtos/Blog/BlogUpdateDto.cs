using Entities.Concrete.TableModel;

namespace Entities.Concrete.Dtos
{
    public class BlogUpdateDto
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public string Text { get; set; }
        public bool IsHome { get; set; }
        public int CategoryOfBlogID { get; set; }
        public int[] tagIds { get; set; }

        public static Blog ToBlog(BlogUpdateDto dto)
        {
            Blog blog = new Blog()
            {
                ID = dto.ID,
                Title = dto.Title,
                Description = dto.Description,
                PhotoUrl = dto.PhotoUrl,
                Text = dto.Text,
                IsHome = dto.IsHome,
                CategoryOfBlogID = dto.CategoryOfBlogID,
            };

            return blog;
        }
    }
}

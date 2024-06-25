using Entities.Concrete.TableModel;

namespace Entities.Concrete.Dtos
{
    public class AboutCreateDto
    {
        public string Description { get; set; }

        public static About ToAbout(AboutCreateDto dto)
        {
            About about = new About()
            {
                Description = dto.Description,  
            };

            return about;
        }
    }
}

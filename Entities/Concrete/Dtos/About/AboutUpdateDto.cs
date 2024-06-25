using Entities.Concrete.TableModel;

namespace Entities.Concrete.Dtos
{
    public class AboutUpdateDto
    {
        public int ID { get; set; }
        public string Description { get; set; }

        public static About ToAbout(AboutUpdateDto dto)
        {
            About about = new About()
            {
                ID = dto.ID,
                Description = dto.Description,
            };

            return about;
        }
    }
}

using Entities.Concrete.TableModel;

namespace Entities.Concrete.Dtos
{
    public class HomeSlideUpdateDto
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }

        public static HomeSlide ToHomeSlide(HomeSlideUpdateDto dto)
        {
            HomeSlide homeSlide = new HomeSlide()
            {
                ID = dto.ID,
                Description = dto.Description,
                PhotoUrl = dto.PhotoUrl
            };

            return homeSlide;
        }
    }
}
